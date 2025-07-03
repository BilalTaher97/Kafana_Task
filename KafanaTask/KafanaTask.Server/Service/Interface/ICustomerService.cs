using KafanaTask.DTOs;
using KafanaTask.Server.Models;

namespace KafanaTask.Service.Interface
{
    public interface ICustomerService
    {
<<<<<<< HEAD

        Task<bool> AddUser(Customer customer);

        Task<string> LoginAsync(string email, string password);

        Task<List<Product>> GetProducts();

        Task<List<Order>> GetOrderById(int Id);


        Task<bool> CancelOrder(int Id);

=======
        Task<(List<CustomerDTO> customers, int TotalCount)> GetPaginatedAsync(int page, int pageSize);

        Task<Customer?> GetUserByIdAsync(int id);
        Task DeleteUsersAsync(List<int> ids);
        Task<Customer?> UpdateStatusAsync(int id, string statusEn, string statusAr);
>>>>>>> a2d9b71c87ae60516c30dcab90009942fa165fb0
    }
}
