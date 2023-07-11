using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Core.Interfaces;
using UnitOfWorkDemo.Infrastructure;
using UnitOfWorkDemo.Infrastructure.Repositories;
using UnitOfWorkDemo.Services;
using UnitOfWorkDemo.Test.MockData;
using Xunit;

namespace UnitOfWorkDemo.Test.Services
{

    [Collection("Database collection")]
    public class TestProductDetailsServices : IClassFixture<ProductService> ,IDisposable
    {

        private DbContextClass _dbContextClass;
        public Mock<IUnitOfWork> _unitOfWork;
        public Mock<IStudentRepository> _studentRepository;
        public Mock<IProductRepository> _prodProductRepository;

     //   public IUnitOfWork _unitOfWork;
        public TestProductDetailsServices()
        {
            var options = new DbContextOptionsBuilder<DbContextClass>().UseInMemoryDatabase(databaseName: "UnitOfWorkDemoDB").Options;
            _dbContextClass = new DbContextClass(options);
            _dbContextClass.Database.EnsureCreated();
            _unitOfWork = new Mock<IUnitOfWork>();
            _prodProductRepository = new Mock<IProductRepository>();
            _studentRepository = new Mock<IStudentRepository>();

         //   _unitOfWork =  unitOfWork;

        }
      
        
        [Fact(DisplayName = "Test Product Service")]
        public async Task GetProductList_CollectionOfProductList()
        {
            // Arrange 



            _unitOfWork.Setup(x => x.Products.GetAll()).ReturnsAsync(ProductDetailMockData.GetAllProducts());



             var productServices = new ProductService(_unitOfWork.Object);
            // var sut = new UnitOfWork(_dbContextClass, (IProductRepository)_prodProductRepository, (IStudentRepository)_studentRepository);


            // act

             var result = await productServices.GetAllProducts();

            // assert



            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).Should().Be(201);

        }

        public void Dispose()
        {
            _dbContextClass.Database.EnsureDeleted();
        }
    }
}
