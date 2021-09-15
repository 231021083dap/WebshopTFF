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
        private readonly IItemRepo _ItemRepo;
        //CTOR
        public ItemService(IItemRepo ItemRepo)
        {
            _ItemRepo = ItemRepo;

        }

        public async Task<List<ItemResponse>> GetAllItems()
        {
            List<ItemResponse> Items = new();
            List<Item> Item = await _ItemRepo.GetAllItems();
            //lambda
            return Items.Select(i => new ItemResponse
            {
                ItemId = i.ItemId,

            }).ToList();
        }

        public async Task<ItemResponse> GetById(int ItemId)
        {
            Item item = await _ItemRepo.GetById(ItemId);
            return item == null ? null : new ItemResponse
            {
                ItemId = item.ItemId,
                ItemName = item.ItemName,
                ItemSubCategory = item.ItemSubCategory,
                ItemPrice = item.ItemPrice,
                ItemDiscount = item.ItemDiscount,
                ItemAmount = item.ItemAmount

            };
        }

        public async Task<ItemResponse> Create(NewItem newItem)
        {
            Item item = new Item
            {
                ItemName = newItem.ItemName,
                ItemSubCategory = newItem.ItemSubCategory,
                ItemPrice = newItem.ItemPrice,
                ItemDiscount = newItem.ItemDiscount,
                ItemAmount = newItem.ItemAmount

            };
            item = await _ItemRepo.Create(item);

            //Turnary operator, hvis værdien er null -> return, hvis værdien IKKE er null -> continue
            return item == null ? null : new ItemResponse
            {
                ItemId = item.ItemId,
                ItemName = item.ItemName,
                ItemSubCategory = item.ItemSubCategory,
                ItemPrice = item.ItemPrice,
                ItemDiscount = item.ItemDiscount,
                ItemAmount = item.ItemAmount
            };
        }

        public async Task<ItemResponse> Update(int ItemId, UpdateItem updateItem)
        {
            Item Item = new Item
            {

                ItemName = updateItem.ItemName,
                ItemSubCategory = updateItem.ItemSubCategory,
                ItemPrice = updateItem.ItemPrice,
                ItemDiscount = updateItem.ItemDiscount,
                ItemAmount = updateItem.ItemAmount

            };
            Item = await _ItemRepo.Update(ItemId, Item);

            return Item == null ? null : new ItemResponse
            {

                ItemName = Item.ItemName,
                ItemSubCategory = Item.ItemSubCategory,
                ItemPrice = Item.ItemPrice,
                ItemDiscount = Item.ItemDiscount,
                ItemAmount = Item.ItemAmount

            };
        }

        public async Task<bool> Delete(int ItemId)
        {
            var result = await _ItemRepo.Delete(ItemId);
            return true;
        }
    }
}

