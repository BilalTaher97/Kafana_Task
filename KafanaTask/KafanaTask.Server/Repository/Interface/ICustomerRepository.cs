
using KafanaTask.Server.Models;

namespace KafanaTask.Repository.Interface
{
    public interface ICustomerRepository
    {


        Task<bool> Add(Customer customer);

        Task<Customer> GetCustomerByEmail(string email);

        Task<List<Product>> GetAllProducts();

        Task<List<Order>> GetOrderById(int Id);


        Task<bool> CancelOrder (int Id);

    }
}
