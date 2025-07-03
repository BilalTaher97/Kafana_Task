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


        public async Task<bool> Add(Customer customer)
        {
            _context.Customers.Add(customer);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Customer> GetCustomerByEmail(string email)
        {

           return await  _context.Customers.FirstOrDefaultAsync(x => x.Email == email);

            
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<List<Order>> GetOrderById(int Cust_Id)
        {

            return await _context.Orders.Where(O => O.CustomerId == Cust_Id).ToListAsync();


        }

        public async Task<bool> CancelOrder(int Id)
        {

            var Order = await _context.Orders.FirstOrDefaultAsync(Ord => Ord.Id == Id);


            if (Order == null) return false;


            Order.StatusEn = "Inactive";

            Order.StatusAr = "غير نشط";

            _context.Orders.Update(Order);

            if(_context.SaveChanges()  > 0)
            {
                return true;
            }

            return false;
           
        }


    }
}
