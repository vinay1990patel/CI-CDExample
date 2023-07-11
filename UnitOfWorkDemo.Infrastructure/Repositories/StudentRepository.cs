using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Core.Interfaces;
using UnitOfWorkDemo.Core.Models;

namespace UnitOfWorkDemo.Infrastructure.Repositories
{
    internal class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(DbContextClass dbContextClass) : base(dbContextClass)
        {


        }
    }
}
