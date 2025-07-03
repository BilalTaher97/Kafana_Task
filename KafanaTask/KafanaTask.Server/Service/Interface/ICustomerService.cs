using KafanaTask.DTOs;
using KafanaTask.Server.Models;

namespace KafanaTask.Service.Interface
{
    public interface ICustomerService
    {

        Task<bool> AddUser(Customer customer);

        Task<string> LoginAsync(string email, string password);

        Task<List<Product>> GetProducts();

        Task<List<Order>> GetOrderById(int Id);


        Task<bool> CancelOrder(int Id);

    }
}
