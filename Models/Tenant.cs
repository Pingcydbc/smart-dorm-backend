namespace SmartDormApi.Models
{
    public class Tenant
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime CheckInDate { get; set; } = DateTime.UtcNow;

        public int RoomId { get; set; }
    }
}