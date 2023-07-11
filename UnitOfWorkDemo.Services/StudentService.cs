using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Core.Interfaces;
using UnitOfWorkDemo.Core.Models;
using UnitOfWorkDemo.Services.Interfaces;

namespace UnitOfWorkDemo.Services
{
    public class StudentService : IStudentService
    {
        public IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateStudent(Student student, CancellationToken cancellationToken)
        {
            if (student is not null)
            {
                await _unitOfWork.Students.Add(student);
                var result = _unitOfWork.Save(cancellationToken);
                if (result.IsCompletedSuccessfully)

                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteStudent(int studentId, CancellationToken cancellationToken)
        {
            if (studentId > 0)
            {
                var StudentDetails = await _unitOfWork.Students.GetById(studentId);
                if (StudentDetails is not null)
                {
                    _unitOfWork.Students.Delete(StudentDetails);
                    var result = _unitOfWork.Save(cancellationToken);
                    if (result.IsCompletedSuccessfully) return true;
                    else return false;
                }

            }
            return false;
        }

        public async Task<IEnumerable<Student>> GetAllStudents(CancellationToken cancellationToken)
        {
            return await _unitOfWork.Students.GetAll();
        }

        public async Task<Student> GetStudentById(int studentId,  CancellationToken cancellationToken)
        {
            if (studentId > 0)
            {
                var StudentDetails = await _unitOfWork.Students.GetById(studentId);
                if (StudentDetails is not null)
                {
                    return StudentDetails;
                }
            }
            return null;
        }

        public async Task<bool> UpdateStudent(Student studentDetails, CancellationToken cancellationToken)
        {
            if (studentDetails != null)
            {
                var student = await _unitOfWork.Students.GetById(studentDetails.StudentId);

                if (student != null)
                {
                    student.StudentName = studentDetails.StudentName;
                    student.Address = studentDetails.Address;

                }

                _unitOfWork.Students.Update(student);
                var result = _unitOfWork.Save(cancellationToken);
                if (result.IsCompletedSuccessfully) return true;
                else return false;


            }
            return false;
        }


        //public async Task<bool> UpdateStudentPatch( JsonPathDocument Student studentDetails)
        //{
        //    if (studentDetails != null)
        //    {
        //        var student = await _unitOfWork.Students.GetById(studentDetails.StudentId);

        //        if (student != null)
        //        {
        //            student.StudentName = studentDetails.StudentName;
        //            student.Address = studentDetails.Address;

        //        }

        //        _unitOfWork.Students.Update(student);
        //        int result = _unitOfWork.Save();
        //        if (result > 0) return true;
        //        else return false;


        //    }
        //    return false;
        //}



    }


    class StudentDto
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Address { get; set; }
    }
}
