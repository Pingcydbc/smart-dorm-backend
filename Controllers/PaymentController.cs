using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartDormApi.Data;
using SmartDormApi.Models;

namespace SmartDormApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PaymentController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost("reject/{id}")]
    public async Task<IActionResult> RejectPayment(int id)
    {
        var payment = await _context.Payments
            .Include(p => p.Invoice)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (payment == null)
            return NotFound("Payment not found");

        // อัปเดตสถานะ payment
        payment.Status = "Rejected";

        // คืนสถานะ invoice ให้ user อัปโหลดใหม่
        payment.Invoice.Status = "Pending";

        await _context.SaveChangesAsync();

        return Ok(new { message = "Rejected successfully" });
    }


    [HttpPost("approve/{id}")]
    public async Task<IActionResult> ApprovePayment(int id)
    {
        var payment = await _context.Payments
            .Include(p => p.Invoice)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (payment == null)
            return NotFound("Payment not found");

        // อัปเดตสถานะ payment
        payment.Status = "Approved";

        // อัปเดตสถานะ invoice
        payment.Invoice.Status = "Paid";

        await _context.SaveChangesAsync();

        return Ok(new { message = "Approved successfully" });
    }

    [HttpGet("pending")]
    public async Task<IActionResult> GetPendingPayments()
    {
        var payments = await _context.Payments
            .Include(p => p.Invoice)
                .ThenInclude(i => i.Room)
            .Where(p => p.Status == "Pending")
            .OrderByDescending(p => p.Id)
            .Select(p => new
            {
                p.Id,
                p.InvoiceId,
                RoomNumber = p.Invoice.Room.RoomNumber,
                TenantName = p.Invoice.Room.CurrentTenant != null ? p.Invoice.Room.CurrentTenant.Name : "ไม่ระบุชื่อ",
                PaymentData = p.PaymentDate,
                TotalAmount = p.Invoice.GrandTotal,
                Amount = p.Invoice.GrandTotal,
                p.SlipUrl,
                p.Status
            })
            .ToListAsync();

        return Ok(payments);
    }


    [HttpPost("upload-slip")]
    public async Task<IActionResult> UploadSlip(
    IFormFile slip,
    [FromForm] int invoiceId)
    {
        if (slip == null || slip.Length == 0)
            return BadRequest("No file uploaded");

        var invoice = await _context.Invoices.FindAsync(invoiceId);
        if (invoice == null)
            return NotFound("Invoice not found");

        // ✅ path จริงในเครื่อง (ต้องอยู่ใน wwwroot)
        var uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "slips");
        Directory.CreateDirectory(uploadDir);

        var fileName = $"{Guid.NewGuid()}_{slip.FileName}";
        var physicalPath = Path.Combine(uploadDir, fileName);

        using (var stream = new FileStream(physicalPath, FileMode.Create))
        {
            await slip.CopyToAsync(stream);
        }

        // ✅ path สำหรับ frontend (URL)
        var slipUrl = $"/uploads/slips/{fileName}";

        var payment = new Payment
        {
            InvoiceId = invoiceId,
            SlipUrl = slipUrl,
            Status = "Pending",
            PaymentDate = DateTime.Now,
        };

        _context.Payments.Add(payment);
        invoice.Status = "WaitingApproval";

        await _context.SaveChangesAsync();

        return Ok(new { message = "Upload success", slipUrl });
    }
}
