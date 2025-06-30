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

      
    }
}
