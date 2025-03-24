namespace MoviesLibrary.Domain;

public interface IUnitOfWork
{
    Task CommitChangesAsync(CancellationToken cancellationToken = default);
    void CommitChanges();
}