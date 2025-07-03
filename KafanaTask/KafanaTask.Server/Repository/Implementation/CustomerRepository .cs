using KafanaTask.DTOs;
using KafanaTask.Repository.Interface;
using KafanaTask.Server.Models;
using Microsoft.EntityFrameworkCore;


namespace KafanaTask.Repository.Implemetnation
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MyDbContext _context;

        public CustomerRepository(MyDbContext context)
        {
            _context = context;
        }



        public async Task<List<CustomerDTO>> GetAllUsersAsync(int page, int pageSize)
        {
            return await _context.Customers
                .Include(c => c.Orders) // ضروري لعدّ الطلبات
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(c => new CustomerDTO
                {
                    Id = c.Id,
                    NameEn = c.NameEn,
                    NameAr = c.NameAr,
                    Email = c.Email,
                    Phone = c.Phone,
                    StatusEn = c.StatusEn,
                    StatusAr = c.StatusAr,
                    GenderEn = c.GenderEn,
                    GenderAr = c.GenderAr,
                    DateOfBirth = c.DateOfBirth.HasValue? c.DateOfBirth.Value.ToDateTime(TimeOnly.MinValue): null,
                    ServerDateTime = c.ServerDateTime,
                    DateTimeUtc = c.DateTimeUtc,
                    LastLoginDateTimeUtc = c.LastLoginDateTimeUtc,
                    UpdateDateTimeUtc = c.UpdateDateTimeUtc,
                    Photo = c.Photo,
                    OrdersCount = c.Orders.Count
                })
                .ToListAsync();
        }



        public async Task<int> usersCount()
        {
            return await _context.Customers.CountAsync();
        }

        public async Task<Customer?> GetUserById(int Id)
        {
            var currentUser = await _context.Customers.FindAsync(Id);

            return currentUser;
        }

        public async Task<List<Customer>> GetUsersByIdsAsync(List<int> ids)
        {
            return await _context.Customers
                .Include(c => c.Orders)
                .Where(c => ids.Contains(c.Id))
                .ToListAsync();
        }

        public async Task DeleteUsersAsync(List<Customer> customers)
        {
            foreach (var customer in customers)
            {
                _context.Orders.RemoveRange(customer.Orders); 
            }

            _context.Customers.RemoveRange(customers); 
            await _context.SaveChangesAsync();
        }




        public async Task<Customer?> UpdateStatusAsync(int id, string statusEn, string statusAr)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
                return null;

            customer.StatusEn = statusEn;
            customer.StatusAr = statusAr;
            customer.UpdateDateTimeUtc = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return customer;
        }





    }
}
