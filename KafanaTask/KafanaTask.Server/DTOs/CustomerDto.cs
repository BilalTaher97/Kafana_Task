namespace KafanaTask.DTOs
{
    public class CustomerDto
    {
        public string NameEn { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string PasswordHash { get; set; } = null!; // مستقبلاً: استقبل plain password وشفّرها بالخدمة
    }
}
