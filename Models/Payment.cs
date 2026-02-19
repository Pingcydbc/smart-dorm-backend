namespace SmartDormApi.Models;

public class Payment
{
    public int Id { get; set; }

    public int InvoiceId { get; set; }
    public Invoice Invoice { get; set; } = null!; // ✅ เพิ่มบรรทัดนี้

    public string SlipUrl { get; set; } = string.Empty;
    public string Status { get; set; } = "Pending";
    public DateTime PaymentDate { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


}
