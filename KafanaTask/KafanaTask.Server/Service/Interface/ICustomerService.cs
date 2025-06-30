using KafanaTask.DTOs;
using KafanaTask.Server.Models;

namespace KafanaTask.Service.Interface
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetPagedCustomersAsync(int page, int pageSize);
        Task<Customer?> GetCustomerByIdAsync(int id);
        Task AddCustomerAsync(CustomerDto dto);
        Task UpdateCustomerStatusAsync(int id, string newStatus);
        Task DeleteCustomerAsync(int id);
        Task DeleteCustomersAsync(List<int> ids);
    }
}
