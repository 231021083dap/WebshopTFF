using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.DB.Entities;
using WebshopAPI.DTO;
using WebshopAPI.Repositories;
using WebshopAPI.Responses;

namespace WebshopAPI.Services
{
    public interface ISubService
    {
        Task<List<SubResponse>> GetAllSubs();
        Task<SubResponse> GetById(int SubId);
        Task<SubResponse> Create(NewSubCategory newSubCategory);
        Task<SubResponse> Update(int SubId, UpdateSubCategory updateSubCategory);
        Task<bool> Delete(int SubId);
    }
    public class SubService : ISubService
    {
        private readonly ISubRepo _subRepo;
        //CTOR
        public SubService(ISubRepo subRepo)
        {
            _subRepo = subRepo;

        }

        public async Task<List<SubResponse>> GetAllSubs()
        {
            List<SubResponse> Subs = new();
            List<SubCategory> Sub = await _subRepo.GetAllSubs();
            //lambda
            return Subs.Select(i => new SubResponse
            {
                SubId = i.SubId,
                SubName = i.SubName,
                CategoryId = i.CategoryId,
                Category = new SubCatResponse
                {
                    CategoryId = i.Category.CategoryId,
                    CategoryName = i.Category.CategoryName
                }

            }).ToList();
        }

        public async Task<SubResponse> GetById(int SubId)
        {
            SubCategory sub = await _subRepo.GetById(SubId);
            return sub == null ? null : new SubResponse
            {
                SubId = sub.SubId,
                SubName = sub.SubName,
                CategoryId = sub.CategoryId,
                Category = new SubCatResponse
                {
                    CategoryId = sub.Category.CategoryId,
                    CategoryName = sub.Category.CategoryName
                }
            };
        }

        public async Task<SubResponse> Create(NewSubCategory newSub)
        {
            SubCategory sub = new()
            {
                SubName = newSub.SubName,
                CategoryId = newSub.CategoryId
            };

            sub = await _subRepo.Create(sub);

            //Turnary operator, hvis værdien er null -> return, hvis værdien IKKE er null -> continue
            return sub == null ? null : new SubResponse
            {
                SubId = sub.SubId,
                SubName = sub.SubName,
                CategoryId = sub.CategoryId,
                Category = new SubCatResponse
                {
                    CategoryId = sub.Category.CategoryId,
                    CategoryName = sub.Category.CategoryName
                }

            };
        }


        public async Task<SubResponse> Update(int SubId, UpdateSubCategory updateSub)
        {
            SubCategory sub = new()
            {

                SubName = updateSub.SubName,
                CategoryId = updateSub.CategoryId

            };
            sub = await _subRepo.Update(SubId, sub);

            return sub == null ? null : new SubResponse
            {
                SubName = sub.SubName,
                CategoryId = sub.CategoryId,
                Category = new SubCatResponse
                {
                    CategoryId = sub.Category.CategoryId,
                    CategoryName = sub.Category.CategoryName
                }
            };
        }

        public async Task<bool> Delete(int SubId)
        {
            var result = await _subRepo.Delete(SubId);
            return true;
        }
    }
}
