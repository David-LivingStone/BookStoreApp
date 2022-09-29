using AutoMapper;
using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BookStoreDbContext _Context;
        private readonly IMapper _mapper;

        public OrderRepository(BookStoreDbContext bookStoreDbContext, IMapper imapper)
        {
            _Context = bookStoreDbContext;
            _mapper = imapper;
        }

        public async Task<OrderModel> MakeOrder( OrderModel orderModel)
        {
            
            orderModel.DatePurchased = DateTime.Now.ToString();
            await _Context.OrderBooks.AddAsync(orderModel);
            await _Context.SaveChangesAsync();
            return orderModel;
            
        }

        public async Task<List<OrderModel>>GetAllOrders (OrderModel orderModel)
        {
            var result = await _Context.OrderBooks.ToListAsync();
            return _mapper.Map<List<OrderModel>>(result);
            
        }

        public async Task<OrderModel> order(OrderModel orderModel)
        {

            orderModel.DatePurchased = DateTime.Now.ToString();
            await _Context.OrderBooks.AddAsync(orderModel);
            await _Context.SaveChangesAsync();
            return orderModel;
        }
}
