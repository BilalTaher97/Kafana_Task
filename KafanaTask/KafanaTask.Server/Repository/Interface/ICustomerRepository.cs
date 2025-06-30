
using KafanaTask.Server.Models;

namespace KafanaTask.Repository.Interface
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetPagedAsync(int pageNumber, int pageSize);
        Task<Customer?> GetByIdAsync(int id);
        Task AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(int id);
        Task DeleteMultipleAsync(List<int> ids);
        Task SaveChangesAsync();
    }
}
