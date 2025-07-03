using KafanaTask.DTOs;
using KafanaTask.Repository.Implemetnation;
using KafanaTask.Repository.Interface;
using KafanaTask.Server.JwtSetting;
using KafanaTask.Server.Models;
using KafanaTask.Service.Interface;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace KafanaTask.Service.Implemetnation 
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly string _secretKey;
        public CustomerService(ICustomerRepository customerRepository, IOptions<JwtSettings> jwtSettings)
        {
            _customerRepository = customerRepository;
            _secretKey = jwtSettings.Value.SecretKey;
        }

        public async Task<bool> AddUser(Customer customer)
        {
            return await _customerRepository.Add(customer);
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            var customer = await _customerRepository.GetCustomerByEmail(email);

            if (customer == null)
                return null;

            if (!VerifyPassword(password, customer.PasswordHash))
                return null;

            return GenerateJwtToken(customer);
        }



        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                    builder.Append(b.ToString("x2"));

                return builder.ToString();
            }
        }


        private bool VerifyPassword(string enteredPassword, string storedHash)
        {
            string enteredHash = ComputeSha256Hash(enteredPassword);
            return enteredHash == storedHash;
        }


        private string GenerateJwtToken(Customer customer)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim(ClaimTypes.NameIdentifier, customer.Id.ToString()),
            new Claim(ClaimTypes.Email, customer.Email),
        }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = "yourAppName",    
                Audience = "yourAppUsers", 
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        public async Task<List<Product>> GetProducts()
        {
            return await _customerRepository.GetAllProducts();
        }


        public async Task<List<Order>> GetOrderById(int Id)
        {
            return await _customerRepository.GetOrderById(Id);
        }

        public async Task<bool> CancelOrder(int Id)
        {
            return await _customerRepository.CancelOrder(Id);
        }


    }
}
