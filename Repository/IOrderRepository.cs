using BookStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public interface IOrderRepository
    {
        Task<OrderModel> MakeOrder(OrderModel orderModel);
        Task<List<OrderModel>> GetAllOrders(OrderModel orderModel);


    }
}
