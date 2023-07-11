

using System.Data;

namespace UnitOfWorkDemo.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        IStudentRepository Students { get; }

        Task<int> Save(CancellationToken cancellationToken);

        IDbTransaction BeginTransaction();
    }
}
