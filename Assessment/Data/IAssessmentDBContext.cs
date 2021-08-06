using Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Assessment.Data
{
    public interface IAssessmentDBContext
    {
        DbSet<Sentence> Sentences { get; }
        DbSet<Word> Words { get; }

        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChanges, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
