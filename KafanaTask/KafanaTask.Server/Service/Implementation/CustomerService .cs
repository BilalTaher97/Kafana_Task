using KafanaTask.DTOs;
using KafanaTask.Repository.Interface;
using KafanaTask.Server.Models;
using KafanaTask.Service.Interface;


namespace KafanaTask.Service.Implemetnation
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<(List<CustomerDTO> customers, int TotalCount)> GetPaginatedAsync(int page, int pageSize)
        {

            var customers = await _customerRepository.GetAllUsersAsync(page, pageSize);
            var totalCount = await _customerRepository.usersCount();

            return (customers, totalCount);
        }

        public async Task<Customer?> GetUserByIdAsync(int id)
        {
            var customer = await _customerRepository.GetUserById(id);

            if (customer == null || customer.StatusEn != "Active")
                return null;


            return customer;
        }


        public async Task DeleteUsersAsync(List<int> ids)
        {
            var customers = await _customerRepository.GetUsersByIdsAsync(ids);
            if (!customers.Any())
                return;

            await _customerRepository.DeleteUsersAsync(customers);
        }



        public async Task<Customer?> UpdateStatusAsync(int id, string statusEn, string statusAr)
        {
            return await _customerRepository.UpdateStatusAsync(id, statusEn, statusAr);
        }





    }
}
