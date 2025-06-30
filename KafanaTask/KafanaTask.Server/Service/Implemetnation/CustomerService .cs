using KafanaTask.DTOs;
using KafanaTask.Repository.Interface;
using KafanaTask.Server.Models;


namespace KafanaTask.Service.Implemetnation
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<Customer>> GetPagedCustomersAsync(int page, int pageSize)
        {
            return await _customerRepository.GetPagedAsync(page, pageSize);
        }

        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }

        public async Task AddCustomerAsync(CustomerDto dto)
        {
            var customer = new Customer
            {
                NameEn = dto.NameEn,
                Email = dto.Email,
                Phone = dto.Phone,
                PasswordHash = dto.PasswordHash, // تأكد من تشفيره قبل التخزين
                ServerDateTime = DateTime.Now,
                DateTimeUtc = DateTime.UtcNow,
                StatusEn = "Active",
                StatusAr = "نشط"
            };

            await _customerRepository.AddAsync(customer);
            await _customerRepository.SaveChangesAsync();
        }

        public async Task UpdateCustomerStatusAsync(int id, string newStatus)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null) return;

            customer.StatusEn = newStatus;
            customer.UpdateDateTimeUtc = DateTime.UtcNow;

            await _customerRepository.UpdateAsync(customer);
            await _customerRepository.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _customerRepository.DeleteAsync(id);
            await _customerRepository.SaveChangesAsync();
        }

        public async Task DeleteCustomersAsync(List<int> ids)
        {
            await _customerRepository.DeleteMultipleAsync(ids);
            await _customerRepository.SaveChangesAsync();
        }
    }
}
