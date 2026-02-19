namespace SmartDormApi.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty; // กำหนดค่าเริ่มต้น
    public string PasswordHash { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public int? RoomId { get; set; }
}