using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Core.Models;

namespace UnitOfWorkDemo.Test.MockData
{
    public class ProductDetailMockData
    {
        public static List<ProductDetails> GetAllProducts()
        {
            List<ProductDetails> productDetails = new List<ProductDetails>();
            {
                new ProductDetails { Id = 1, ProductDescription = "This is test", ProductName = "A", ProductPrice = 12, ProductStock = 2 };
                new ProductDetails { Id = 1, ProductDescription = "This is test1", ProductName = "A1", ProductPrice = 13, ProductStock = 3 };
                new ProductDetails { Id = 1, ProductDescription = "This is test2", ProductName = "A2", ProductPrice = 14, ProductStock = 4 };

            };

            return productDetails;
        }

        public static ProductDetails GetProductModel()
        {
            ProductDetails productDetails = new ProductDetails()
            {
                Id = 1, ProductDescription = "This is test", ProductName = "A", ProductPrice = 12, ProductStock = 2 

        };
            return productDetails;

        }


        public static IEnumerable<ProductDetails> GetEmptyList()
        {


            return Enumerable.Empty<ProductDetails>();
        }
    }
}
