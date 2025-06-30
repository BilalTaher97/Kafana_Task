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

        public async Task<List<Customer>> GetPagedAsync(int pageNumber, int pageSize)
        {
            return await _context.Customers
                .OrderByDescending(c => c.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }
        }

        public async Task DeleteMultipleAsync(List<int> ids)
        {
            var customers = await _context.Customers.Where(c => ids.Contains(c.Id)).ToListAsync();
            _context.Customers.RemoveRange(customers);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
