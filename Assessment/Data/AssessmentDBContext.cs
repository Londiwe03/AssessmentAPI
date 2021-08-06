using Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Assessment.Data
{
    public class AssessmentDBContext : DbContext, IAssessmentDBContext
    {

        public DbSet<Sentence> Sentences { get; set; }
        public DbSet<Word> Words { get; set; }

        public AssessmentDBContext(DbContextOptions<AssessmentDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SentenceMap());
            modelBuilder.ApplyConfiguration(new WordMap());
        }

    }
}
