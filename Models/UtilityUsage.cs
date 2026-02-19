namespace SmartDormApi.Models;

public class UtilityUsage
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public DateTime ReadingDate { get; set; } = DateTime.UtcNow;

    // 🔥 ไฟฟ้า
    public int PreviousElectricityMeter { get; set; }
    public int CurrentElectricityMeter { get; set; }
    public int ElectricityUnits => CurrentElectricityMeter - PreviousElectricityMeter;
    public decimal ElectricityAmount => ElectricityUnits * 5m;

    // 💧 น้ำ
    public int PreviousWaterMeter { get; set; }
    public int CurrentWaterMeter { get; set; }
    public int WaterUnits => CurrentWaterMeter - PreviousWaterMeter;
    public decimal WaterAmount => WaterUnits * 10m;
}
