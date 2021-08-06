using Microsoft.AspNetCore.Mvc;
using Assessment.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using Models;

namespace Assessment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssessmentController : ControllerBase
    {
        private readonly IAssessmentDBContext _dbContext;

        public AssessmentController(IAssessmentDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{wordType}")]
        public async Task<IActionResult> GetWordsByType(string wordType)
        {

            try
            {
                var wordTypeLowerCase = wordType.ToLower();
                var words = await _dbContext.Words.AsNoTracking()
                           .Where(p => p.WordType.Equals(wordTypeLowerCase.Trim()))
                           .Select(x => new
                           {
                               Data = x.Data

                           }).ToArrayAsync();

                return Ok(words);

            }

            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        [HttpGet("history")]
        public async Task<IActionResult> GetExistingSentences()
        {

            try
            {
                var sentences = await _dbContext.Sentences.AsNoTracking()
                               .ToArrayAsync();

                return Ok(sentences);

            }

            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        [HttpPost]
        [Route("sentence")]
        public async Task<IActionResult> Submit([FromBody] Sentence sentence)
        {

            try
            {
                _dbContext.Sentences.Add(sentence);
                var added = await _dbContext.SaveChangesAsync();
                return Ok(added);

            }

            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
    }
}
