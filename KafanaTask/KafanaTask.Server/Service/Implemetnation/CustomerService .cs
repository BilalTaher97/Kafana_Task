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

        
    }
}
