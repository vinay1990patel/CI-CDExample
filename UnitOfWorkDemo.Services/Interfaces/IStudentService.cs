using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Core.Models;

namespace UnitOfWorkDemo.Services.Interfaces
{
    public interface IStudentService
    {
        Task<bool> CreateStudent(Student student, CancellationToken cancellationToken);
        Task<IEnumerable< Student>> GetAllStudents(CancellationToken cancellationToken);
        Task <bool> UpdateStudent(Student student, CancellationToken cancellationToken);
        Task<bool> DeleteStudent(int studentId, CancellationToken cancellationToken);
        Task<Student> GetStudentById(int studentId, CancellationToken cancellationToken);
       
    }
}
