using System;
using System.Collections.Generic;
using System.Linq;
using WebshopAPI.DB.Entities;
using System.Threading.Tasks;
using WebshopAPI.DTO;
using WebshopAPI.Responses;
using WebshopAPI.Repositories;

namespace WebshopAPI.Services
{

    public interface IOrdersService
    {
        Task<List<OrderResponse>> GetAllOrders();
        Task<OrderResponse> GetById(int OrderId);
        Task<OrderResponse> Create(NewOrder newOrder);
        Task<OrderResponse> Update(int OrderId, UpdateOrder updateOrder);
        Task<bool> Delete(int OrderId);
    }

    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepo _orderRepo;

        public OrdersService(IOrdersRepo OrderRepo)
        {
            _orderRepo = OrderRepo;
        }

        public async Task<List<OrderResponse>> GetAllOrders()
        {
            List<OrderResponse> Orders = new();
            List<Orders> Order = await _orderRepo.GetAllOrders();

            return Orders.Select(i => new OrderResponse
            {
                OrderId = i.OrderId,
                UserId = i.UserId,
                OrderDate = i.OrderDate,
                OrderStatus = i.OrderStatus,
                OrderUser = new OrderUserResponse
                {
                    RoleId = i.OrderUser.RoleId,
                    Email = i.OrderUser.Email,
                    Phone = i.OrderUser.Phone,
                    FirstName = i.OrderUser.FirstName,
                    MiddleName = i.OrderUser.MiddleName,
                    LastName = i.OrderUser.LastName,
                    Address = i.OrderUser.Address,
                    PostalCode = i.OrderUser.PostalCode
                }
            }).ToList();
        }

        public async Task<OrderResponse> GetById(int OrderId)
        {
            Orders Order = await _orderRepo.GetById(OrderId);
            return Order == null ? null : new OrderResponse
            {
                OrderId = Order.OrderId,
                UserId = Order.UserId,
                OrderStatus = Order.OrderStatus,
                OrderUser = new OrderUserResponse
                {
                    RoleId = Order.User.RoleId,
                    Email = Order.User.Email,
                    Phone = Order.User.Phone,
                    FirstName = Order.User.FirstName,
                    MiddleName = Order.User.MiddleName,
                    LastName = Order.User.LastName,
                    Address = Order.User.Address,
                    PostalCode = Order.User.PostalCode
                }
            };
        }

        public async Task<OrderResponse> Create(NewOrder newOrder)
        {
            Orders Order = new Orders
            {
                UserId = newOrder.UserId,
                OrderStatus = newOrder.OrderStatus
            };

            Order = await _orderRepo.Create(Order);

            return Order == null ? null : new OrderResponse
            {
                OrderId = Order.OrderId,
                UserId = Order.UserId,
                OrderStatus = Order.OrderStatus,
                OrderUser = new OrderUserResponse
                {
                    RoleId = Order.User.RoleId,
                    Email = Order.User.Email,
                    Phone = Order.User.Phone,
                    FirstName = Order.User.FirstName,
                    MiddleName = Order.User.MiddleName,
                    LastName = Order.User.LastName,
                    Address = Order.User.Address,
                    PostalCode = Order.User.PostalCode
                }
            };
        }

        public async Task<OrderResponse> Update(int OrderId, UpdateOrder updateOrder)
        {
            Orders Order = new()
            {
                UserId = updateOrder.UserId,
                OrderStatus = updateOrder.OrderStatus
            };
            Order = await _orderRepo.Update(OrderId, Order);

            return Order == null ? null : new OrderResponse
            {
                OrderId = Order.OrderId,
                UserId = Order.UserId,
                OrderStatus = Order.OrderStatus,
                OrderUser = new OrderUserResponse
                {
                    RoleId = Order.User.RoleId,
                    Email = Order.User.Email,
                    Phone = Order.User.Phone,
                    FirstName = Order.User.FirstName,
                    MiddleName = Order.User.MiddleName,
                    LastName = Order.User.LastName,
                    Address = Order.User.Address,
                    PostalCode = Order.User.PostalCode
                }
            };
        }

        public async Task<bool> Delete(int OrderId)
        {
            var result = await _orderRepo.Delete(OrderId);
            return true;
        }

    }
}
