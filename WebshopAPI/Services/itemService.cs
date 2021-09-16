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
    public interface IItemService
    {
        //    //CRUD
        Task<List<ItemResponse>> GetAllItems();
        Task<ItemResponse> GetById(int ItemId);
        Task<ItemResponse> Create(NewItem newItem);
        Task<ItemResponse> Update(int ItemId, UpdateItem updateItem);
        Task<bool> Delete(int ItemId);
    }



    public class ItemService : IItemService
    {
        private readonly IItemRepo _itemRepo;
        private readonly ISubRepo _subRepo;
        //CTOR
        public ItemService(IItemRepo itemRepo, ISubRepo subRepo)
        {
            _itemRepo = itemRepo;
            _subRepo = subRepo;

        }

        public async Task<List<ItemResponse>> GetAllItems()
        {
            List<Item> Item = await _itemRepo.GetAllItems();

            return Item.Select(i => new ItemResponse
            {
                ItemId = i.ItemId,
                ItemName = i.ItemName,
                SubCategoryId = i.SubCategoryId,
                ItemPrice = i.ItemPrice,
                ItemDiscount = i.ItemDiscount,
                ItemAmount = i.ItemAmount,
                ItemStatus = i.ItemStatus,
                SubCategory = new ItemSubResponse
                {
                    SubId = i.SubCategory.SubId,
                    SubName = i.SubCategory.SubName,
                    CategoryId = i.SubCategory.CategoryId
                }
            }).ToList();

        }


        public async Task<ItemResponse> GetById(int ItemId)
        {
            Item item = await _itemRepo.GetById(ItemId);
            
            return item == null ? null : new ItemResponse
            {
                ItemId = item.ItemId,
                ItemName = item.ItemName,
                SubCategoryId = item.SubCategoryId,
                ItemPrice = item.ItemPrice,
                ItemDiscount = item.ItemDiscount,
                ItemAmount = item.ItemAmount,
                ItemStatus = item.ItemStatus,
                SubCategory = new ItemSubResponse
                {
                    SubId = item.SubCategory.SubId,
                    SubName = item.SubCategory.SubName,
                    CategoryId = item.SubCategory.CategoryId
                }
            };
        }

        public async Task<ItemResponse> Create(NewItem newItem)
        {
            Item item = new Item
            {
                ItemName = newItem.ItemName,
                SubCategoryId = newItem.SubCategoryId,
                ItemPrice = newItem.ItemPrice,
                ItemDiscount = newItem.ItemDiscount,
                ItemAmount = newItem.ItemAmount,
                ItemStatus = newItem.ItemStatus
            };
            item = await _itemRepo.Create(item);

            //Turnary operator, hvis værdien er null -> return, hvis værdien IKKE er null -> continue
            return item == null ? null : new ItemResponse
            {
                ItemId = item.ItemId,
                ItemName = item.ItemName,
                SubCategoryId = item.SubCategoryId,
                ItemPrice = item.ItemPrice,
                ItemDiscount = item.ItemDiscount,
                ItemAmount = item.ItemAmount,
                ItemStatus = item.ItemStatus
            };
        }

        public async Task<ItemResponse> Update(int ItemId, UpdateItem updateItem)
        {
            Item item = new()
            {
                ItemName = updateItem.ItemName,
                SubCategoryId = updateItem.SubCategoryId,
                ItemPrice = updateItem.ItemPrice,
                ItemDiscount = updateItem.ItemDiscount,
                ItemAmount = updateItem.ItemAmount,
                ItemStatus = updateItem.ItemStatus

            };
            item = await _itemRepo.Update(ItemId, item);

            if (item != null)
            {
                item.SubCategory = await _subRepo.GetById(item.SubCategoryId);
                return new ItemResponse
                {
                    ItemId = item.ItemId,
                    ItemName = item.ItemName,
                    SubCategoryId = item.SubCategoryId,
                    ItemPrice = item.ItemPrice,
                    ItemDiscount = item.ItemDiscount,
                    ItemAmount = item.ItemAmount,
                    ItemStatus = item.ItemStatus,
                    SubCategory = new ItemSubResponse
                    {
                        SubId = item.SubCategory.SubId,
                        SubName = item.SubCategory.SubName,
                        CategoryId = item.SubCategory.CategoryId
                    }
                };
            }   
            return null;
        }

        public async Task<bool> Delete(int ItemId)
        {
            var result = await _itemRepo.Delete(ItemId);
            return true;
        }
    }
}

