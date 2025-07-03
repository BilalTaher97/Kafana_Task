namespace KafanaTask.DTOs
{
<<<<<<< HEAD
    public class RegisterCustomerDto
    {
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public IFormFile Photo { get; set; }
        public string Password { get; set; }

        public string GenderInput { get; set; }

        public DateTime? DateOfBirth { get; set; }
=======
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string NameEn { get; set; } = "";
        public string? NameAr { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? StatusEn { get; set; }
        public string? StatusAr { get; set; }
        public string? GenderEn { get; set; }
        public string? GenderAr { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime ServerDateTime { get; set; }
        public DateTime DateTimeUtc { get; set; }
        public DateTime? LastLoginDateTimeUtc { get; set; }
        public DateTime? UpdateDateTimeUtc { get; set; }
        public byte[]? Photo { get; set; }

        public int OrdersCount { get; set; } 

>>>>>>> a2d9b71c87ae60516c30dcab90009942fa165fb0
    }
}
