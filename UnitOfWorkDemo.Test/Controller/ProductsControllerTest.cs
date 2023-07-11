using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Controllers;
using UnitOfWorkDemo.Core.Interfaces;
using UnitOfWorkDemo.Core.Models;
using UnitOfWorkDemo.Infrastructure;
using UnitOfWorkDemo.Infrastructure.Repositories;
using UnitOfWorkDemo.Services;
using UnitOfWorkDemo.Services.Interfaces;
using UnitOfWorkDemo.Test.MockData;
using Xunit;

namespace UnitOfWorkDemo.Test.Controller
{
    public class ProductsControllerTest
    {


        private readonly Mock<IProductService> _productService;

        public ProductsControllerTest ()
        {
            _productService = new Mock<IProductService>();
          
        }


        [Fact (DisplayName = "GetProduct List_200 Found")]

        public async Task GetProductList_200Found()
        {
         //   var ProductDetailList = GetAllProducts.GetAllProducts();
            _productService.Setup(x => x.GetAllProducts()).ReturnsAsync(ProductDetailMockData.GetAllProducts());
            var productController = new ProductsController(_productService.Object);

            // act 

            var result = await productController.GetProductList();

            // Assert


            _productService.Verify(x =>x.GetAllProducts(), Times.Exactly(1));

            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
           
            

        }


        [Fact]

        public async Task GetProductList_Test204NoContent()
        {
            //   var ProductDetailList = GetAllProducts.GetAllProducts();
            _productService.Setup(x => x.GetAllProducts()).ReturnsAsync(ProductDetailMockData.GetEmptyList());
            var productController = new ProductsController(_productService.Object);

            // act 

            var result = await productController.GetProductList();

            // Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);

        }

        [Fact(DisplayName ="CreateUser Test")]
        public async Task CreateProduct_test201Created()
        {
            // assert
            ProductDetails studentDetails = new ProductDetails();
            _productService.Setup(x => x.CreateProduct(studentDetails)).ReturnsAsync(true);
            var productController = new ProductsController(_productService.Object);


            // act 

            var result = await productController.CreateProduct(studentDetails);

            // assert 
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);

        }

        [Fact(DisplayName  = "Create Bad Request Test")]
        public async Task CreateProduct_test400Created()
        {
            // assert
            ProductDetails studentDetails = new ProductDetails();
            _productService.Setup(x => x.CreateProduct(studentDetails, cancellationToken)).ReturnsAsync(false);
            var productController = new ProductsController(_productService.Object);


            // act 

            var result = await productController.CreateProduct(studentDetails);

            // assert 
            result.GetType().Should().Be(typeof(BadRequestResult));
            (result as BadRequestResult).StatusCode.Should().Be(400);
        }

        [Fact(DisplayName = "Update Product test")]
        public async Task UpdateProduct_test201Updated()
        {

            // Arrange
            ProductDetails studentDetails = new ProductDetails();
            _productService.Setup(x => x.UpdateProduct(studentDetails)).ReturnsAsync(true);
            var productController = new ProductsController(_productService.Object);


            // Act 

            var result =await productController.UpdateProduct(studentDetails);

            // assert
            result.GetType().Should().Be(typeof(OkObjectResult));
             (result as OkObjectResult).StatusCode.Should().Be(200);

        }

        [Fact ( DisplayName = "GetProductById")]
        public async Task GetProductById_200Found()
        {

            // Arrenge
            ProductDetails productDetails = new ProductDetails();
            _productService.Setup(_ => _.GetProductById(productDetails.Id)).ReturnsAsync(productDetails);
            var productController = new ProductsController(_productService.Object);

            // Act

            var result = await productController.GetProductById(productDetails.Id);

            result.GetType().Should().Be(typeof(OkObjectResult));

            (result as OkObjectResult).StatusCode.Should().Be(200);

        }



    }
}
