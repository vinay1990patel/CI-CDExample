using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Core.Interfaces;

namespace UnitOfWorkDemo.Infrastructure.Repositories
{
    public  class UnitOfWork : IUnitOfWork
    {
        private readonly DbContextClass _dbContext;
        public IProductRepository Products { get; }
        public IStudentRepository Students { get; }

        

        public UnitOfWork(DbContextClass dbContext,
                            IProductRepository productRepository,
                            IStudentRepository studentRepository)
        {
            _dbContext = dbContext;
            Products = productRepository;
            Students = studentRepository;
        }

        public   async Task<int>  Save(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

        IDbTransaction IUnitOfWork.BeginTransaction()
        {
           var transaction = _dbContext.Database.BeginTransaction();

            return transaction.GetDbTransaction();
        }
    }
}
