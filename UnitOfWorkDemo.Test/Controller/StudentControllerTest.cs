using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Controllers;
using UnitOfWorkDemo.Core.Models;
using UnitOfWorkDemo.Services.Interfaces;
using UnitOfWorkDemo.Test.MockData;
using Xunit;

namespace UnitOfWorkDemo.Test.Controller
{
    public class StudentControllerTest
    {
        private readonly Mock<IStudentService> _studentServiceMock;

        public StudentControllerTest()
        {
            _studentServiceMock = new Mock<IStudentService>();
        }

        [Fact] 

        public async Task GetAllStudents_200Found()
        {
            // Arrange
            _studentServiceMock.Setup(x => x.GetAllStudents()).ReturnsAsync(StudentMockData.GetAllStudentTest());
            var StudentController = new StudentController(_studentServiceMock.Object);

            // act

            var result = await StudentController.GetAllStudents();

            // Assert
            _studentServiceMock.Verify(x =>x.GetAllStudents(), Times.Exactly(1));
            Assert.NotNull(result);
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).Should().Be(200);
        
        }

    }
}
