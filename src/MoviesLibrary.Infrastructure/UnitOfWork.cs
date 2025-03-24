using MoviesLibrary.Domain;
using MoviesLibrary.Infrastructure.Data;

namespace MoviesLibrary.Infrastructure;

public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    public async Task CommitChangesAsync(CancellationToken cancellationToken)
    {
        await context.SaveChangesAsync(cancellationToken);
    }

    public void CommitChanges()
    {
        context.SaveChanges();
    }
}