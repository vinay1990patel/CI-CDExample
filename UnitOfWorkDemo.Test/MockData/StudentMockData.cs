using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Core.Interfaces;
using UnitOfWorkDemo.Core.Models;

namespace UnitOfWorkDemo.Test.MockData
{
    public class StudentMockData
    {

        IUnitOfWork _unitOfWork;
        public StudentMockData(IUnitOfWork unitOfWork ) {
        
          _unitOfWork = unitOfWork;
        }

        public  static List<Student> GetAllStudentTest()
        {
            
            List<Student> list = new List<Student>()
            {
                new Student () {StudentId =1, StudentName ="s1"},
                new Student () {StudentId =1, StudentName ="s2"},
                new Student () {StudentId =1, StudentName ="s3"}
            };

            return list;
        }
    }
}
