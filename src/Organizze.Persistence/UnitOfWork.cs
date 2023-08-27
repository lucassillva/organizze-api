using System.Data;
using Npgsql;

namespace Organizze.Persistence;

public interface IUnitOfWork : IDisposable
{
    NpgsqlConnection Connection { get; }
    Task BeginTransaction();
    Task CommitTransaction();
    Task RollbackTransaction();
    Task AppendToSavePoint();
}

public class UnitOfWork : IUnitOfWork
{
    public NpgsqlConnection Connection { get; }

    private bool _isDisposed;
    private NpgsqlTransaction? _transaction;
    private const string DefaultSavePointName = "default_savepoint";

    public UnitOfWork(NpgsqlConnection connection)
    {
        _isDisposed = false;
        Connection = connection;
    }

    public async Task BeginTransaction()
    {
        _transaction = await Connection.BeginTransactionAsync(IsolationLevel.ReadCommitted);
        await _transaction.SaveAsync(DefaultSavePointName);
    }

    public async Task CommitTransaction()
    {
        if (_transaction != null)
            await _transaction.CommitAsync();
    }

    public async Task RollbackTransaction()
    {
        if (_transaction != null)
            await _transaction.RollbackAsync();
    }

    public async Task AppendToSavePoint()
    {
        if (_transaction != null)
            await _transaction.SaveAsync(DefaultSavePointName);
    }

    public void Dispose()
    {
        if (_isDisposed) return;

        _transaction?.Dispose();
        _transaction = null;
        _isDisposed = true;
        GC.SuppressFinalize(this);
    }

    ~UnitOfWork() => Dispose();
}