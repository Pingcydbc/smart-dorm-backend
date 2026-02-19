namespace SmartDormApi.Models;

public class Room
{
    public int Id { get; set; }
    public string RoomNumber { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public decimal MonthlyRent { get; set; }
    public string Status { get; set; } = string.Empty;
    public Tenant? CurrentTenant { get; set; }
}