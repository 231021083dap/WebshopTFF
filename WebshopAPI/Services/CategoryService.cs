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
            List<CategoryResponse> Categories = new();
            List<Category> Category = await _categoryRepo.GetAllCategories();

            return Categories.Select(i => new CategoryResponse
            {
                CategoryId = i.CategoryId
            }).ToList();
        }
    }
}
