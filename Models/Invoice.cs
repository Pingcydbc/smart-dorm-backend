namespace SmartDormApi.Models;

public class Invoice
{
    public int Id { get; set; }

    public int RoomId { get; set; }
    public Room Room { get; set; } = null!;

    // 🔢 เลขมิเตอร์
    public int PreviousElectricityMeter { get; set; }
    public int CurrentElectricityMeter { get; set; }

    public int PreviousWaterMeter { get; set; }
    public int CurrentWaterMeter { get; set; }

    // 💰 ค่าใช้จ่าย
    public decimal TotalElectricity { get; set; }
    public decimal TotalWater { get; set; }
    public decimal GrandTotal { get; set; }

    public string Status { get; set; } = "Pending";
    public DateTime BillingMonth { get; set; } = DateTime.UtcNow;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
