using Trial.Models;
using Trial.Models.Entities;

namespace Trial.Mappers
{
    public static class ProductMappers
    {
        public static Product ToProduct(this AddOrUpdateProductDto addProductDto)
        {
            return new Product
            {
                Name = addProductDto.Name,
                CategoryId = addProductDto.CategoryId
            };
        }
    }
}
