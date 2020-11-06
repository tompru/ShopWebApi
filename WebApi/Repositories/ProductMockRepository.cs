
using System.Collections.Generic;
using System.Linq;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class ProductMockRepository : IProductRepository
    {
        private static List<ProductModel> productModelList = new List<ProductModel>
        {
            new ProductModel
            {
                Id = 1,
                Name = "Bike3000",
                Price = 999.98,
                Color = "Red",
                IBAN = "111118887653"
            },
            new ProductModel
            {
                Id = 2,
                Name = "Car62",
                Price = 10809,
                Color = "Black",
                IBAN = "79111187653"
            },
            new ProductModel
            {
                Id = 3,
                Name = "SteelRim Alcar R15",
                Price = 199.99,
                Color = "Silver",
                IBAN = "256118887653"
            },
        };

        public IEnumerable<ProductModel> GetAll()
        {
            return productModelList;
        }

        public ProductModel Get(int productId)
        {
            return productModelList.Where(x => x.Id == productId).FirstOrDefault();
        }

        public AddProductModel Add(AddProductModel addProductModel)
        {
            var productModel = CreateProductModel(addProductModel);
            productModelList.Add(productModel);
            return addProductModel;
        }

        private ProductModel CreateProductModel(AddProductModel addProductModel)
        {
            var productModel = new ProductModel 
            { 
                Id = GenerateProductId(),
                Name = addProductModel.Name,
                Color = addProductModel.Color,
                IBAN = addProductModel.IBAN,
                Price = addProductModel.Price
            };
            return productModel;
        }

        private int GenerateProductId()
        {
            return productModelList.Max(x => x.Id) + 1;
        }

    }
}
