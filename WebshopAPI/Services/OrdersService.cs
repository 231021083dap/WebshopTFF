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
        private readonly IUserRepo _userRepo;
        public OrdersService(IOrdersRepo OrderRepo, IUserRepo UserRepo)
        {
            _orderRepo = OrderRepo;
            _userRepo = UserRepo;
        }

        public async Task<List<OrderResponse>> GetAllOrders()
        {
            List<Orders> Order = await _orderRepo.GetAllOrders();

            return Order.Select(i => new OrderResponse
            {
                OrderId = i.OrderId,
                UserId = i.UserId,
                OrderStatus = i.OrderStatus,
                User = new OrderUserResponse
                {
                    RoleId = i.User.RoleId,
                    Email = i.User.Email,
                    Phone = i.User.Phone,
                    FirstName = i.User.FirstName,
                    MiddleName = i.User.MiddleName,
                    LastName = i.User.LastName,
                    Address = i.User.Address,
                    PostalCode = i.User.PostalCode
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
                User = new OrderUserResponse
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
            Orders Order = new()
            {
                UserId = newOrder.UserId,
                OrderStatus = newOrder.OrderStatus
            };

            Order = await _orderRepo.Create(Order);

            if (Order != null)
            {

                Order.User = await _userRepo.GetById(Order.UserId);   
                return new OrderResponse
                {
                    OrderId = Order.OrderId,
                    UserId = Order.UserId,
                    OrderStatus = Order.OrderStatus,
                    User = new OrderUserResponse
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
            return null;
        }

        public async Task<OrderResponse> Update(int OrderId, UpdateOrder updateOrder)
        {
            Orders Order = new()
            {
                UserId = updateOrder.UserId,
                OrderStatus = updateOrder.OrderStatus
            };
            Order = await _orderRepo.Update(OrderId, Order);

            if (Order != null)
            {

                Order.User = await _userRepo.GetById(Order.UserId);
                return new OrderResponse
                {
                    OrderId = Order.OrderId,
                    UserId = Order.UserId,
                    OrderStatus = Order.OrderStatus,
                    User = new OrderUserResponse
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
            return null;
        }

            public async Task<bool> Delete(int OrderId)
        {
            var result = await _orderRepo.Delete(OrderId);
            return true;
        }

    }
}
