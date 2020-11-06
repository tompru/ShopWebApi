using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Repositories
{
    public interface IProductRepository
    {
        AddProductModel Add(AddProductModel productModel);
        IEnumerable<ProductModel> GetAll();
        ProductModel Get(int productId);
    }
}