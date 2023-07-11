using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Core.Interfaces;
using UnitOfWorkDemo.Core.Models;
using UnitOfWorkDemo.Services.Interfaces;

namespace UnitOfWorkDemo.Services
{
    public class ProductService : IProductService
    {
        public IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public async Task<bool> CreateProduct(ProductDetails productDetails, CancellationToken cancellationToken = default)
        {
            if (productDetails != null)
            {
                 await _unitOfWork.Products.Add(productDetails);

               var Result =  await _unitOfWork.Save(cancellationToken);

                if (Result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteProduct(int productId, CancellationToken cancellationToken = default)
        {
            if (productId > 0)
            {
                var productDetails = await _unitOfWork.Products.GetById(productId);
                if (productDetails != null)
                {
                    _unitOfWork.Products.Delete(productDetails);
                    var result = _unitOfWork.Save(cancellationToken);

                    if (result.IsCompletedSuccessfully)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<ProductDetails>> GetAllProducts(CancellationToken cancellationToken = default)
        {
            var productDetailsList = await _unitOfWork.Products.GetAll();
            return productDetailsList;
        }

        public async Task<ProductDetails> GetProductById(int productId, CancellationToken cancellationToken = default)
        {
            if (productId > 0)
            {
                var productDetails = await _unitOfWork.Products.GetById(productId);
                if (productDetails != null)
                {
                    return productDetails;
                }
            }
            return null;
        }

        public async Task<bool> UpdateProduct(ProductDetails productDetails, CancellationToken cancellationToken = default)
        {



            if (productDetails != null)
            {

                using (var transaction = _unitOfWork.BeginTransaction())
                {

                    try
                    {

                        var product = await _unitOfWork.Products.GetById(productDetails.Id);
                        if (product != null)
                        {
                            product.ProductName = productDetails.ProductName;
                            product.ProductDescription = productDetails.ProductDescription;
                            product.ProductPrice = productDetails.ProductPrice;
                            product.ProductStock = productDetails.ProductStock;

                            _unitOfWork.Products.Update(product);

                            var result = await _unitOfWork.Save(cancellationToken);
                            transaction.Commit();
                            if (result > 0)
                                return true;
                            else
                                return false;
                        }
                      
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }
                }
            }
            return false;
        }
    }
}
