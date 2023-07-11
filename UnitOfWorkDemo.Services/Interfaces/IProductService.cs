using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Core.Models;

namespace UnitOfWorkDemo.Services.Interfaces
{
    public interface IProductService
    {
        Task<bool> CreateProduct(ProductDetails productDetails, CancellationToken cancellationToken);

        Task<IEnumerable<ProductDetails>> GetAllProducts(CancellationToken cancellationToken);

        Task<ProductDetails> GetProductById(int productId, CancellationToken cancellationToken);

        Task<bool> UpdateProduct(ProductDetails productDetails, CancellationToken cancellationToken);

        Task<bool> DeleteProduct(int productId, CancellationToken cancellationToken);
    }
}
