using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.DB.Entities;
using WebshopAPI.Repositories;
using WebshopAPI.Responses;

namespace WebshopAPI.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryResponse>> GetAllCategories();
        Task<CategoryResponse> GetById(int CategoryId);
    }

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _categoryRepo;

        public CategoryService(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<List<CategoryResponse>> GetAllCategories()
        {
            List<Category> Category = await _categoryRepo.GetAllCategories();

            return Category.Select(i => new CategoryResponse
            {
                CategoryId = i.CategoryId,
                CategoryName = i.CategoryName,
                SubCategory = i.SubCategory.Select(s => new CategorySubResponse
                {
                    SubId = s.SubId,
                    SubName = s.SubName
                }).ToList()

            }).ToList();
        }

        public async Task<CategoryResponse> GetById(int CategoryId)
        {
            Category category = await _categoryRepo.GetById(CategoryId);
            return category == null ? null : new CategoryResponse
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                SubCategory = category.SubCategory.Select(s => new CategorySubResponse
                {
                    SubId = s.SubId,
                    SubName = s.SubName
                }).ToList()
            };
        }
    }
}
