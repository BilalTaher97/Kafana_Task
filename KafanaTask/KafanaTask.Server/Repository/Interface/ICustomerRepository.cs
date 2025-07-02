
using KafanaTask.DTOs;
using KafanaTask.Server.Models;

namespace KafanaTask.Repository.Interface
{
    public interface ICustomerRepository
    {
        Task<List<CustomerDto>> GetAllUsersAsync(int page, int pageSize);
        Task<int> usersCount();
        Task<Customer> GetUserById(int Id);
        Task<List<Customer>> GetUsersByIdsAsync(List<int> ids);
        Task DeleteUsersAsync(List<Customer> customers);
        Task<Customer?> UpdateStatusAsync(int id, string statusEn, string statusAr);


    }
}
