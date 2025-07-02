using KafanaTask.DTOs;
using KafanaTask.Server.Models;

namespace KafanaTask.Service.Interface
{
    public interface ICustomerService
    {
        Task<(List<CustomerDto> customers, int TotalCount)> GetPaginatedAsync(int page, int pageSize);

        Task<Customer?> GetUserByIdAsync(int id);
        Task DeleteUsersAsync(List<int> ids);
        Task<Customer?> UpdateStatusAsync(int id, string statusEn, string statusAr);
    }
}
