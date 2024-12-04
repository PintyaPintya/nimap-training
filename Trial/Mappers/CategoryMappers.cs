using Trial.Models;
using Trial.Models.Entities;

namespace Trial.Mappers
{
    public static class CategoryMappers
    {
        public static Category ToCategory(this AddCategoryDto addCategoryDto)
        {
            return new Category
            {
                Name = addCategoryDto.Name,
            };
        }
    }
}