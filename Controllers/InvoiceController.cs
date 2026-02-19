using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartDormApi.Data;
using SmartDormApi.Models;

namespace SmartDormApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InvoiceController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public InvoiceController(ApplicationDbContext context)
    {
        _context = context;
    }

    // 🔍 ดึงบิลล่าสุดของห้อง
    [HttpGet("latest/{roomId}")]
    public async Task<IActionResult> GetLatestInvoice(int roomId)
    {
        var invoice = await _context.Invoices
            .Where(i => i.RoomId == roomId)
            .OrderByDescending(i => i.CreatedAt)
            .FirstOrDefaultAsync();

        if (invoice == null)
            return NotFound("ยังไม่มีบิล");

        return Ok(invoice);
    }

    // 🧾 สร้างบิลใหม่
    [HttpPost("generate")]
    public async Task<IActionResult> GenerateInvoice([FromBody] UtilityUsage usage)
    {
        var room = await _context.Rooms.FindAsync(usage.RoomId);
        if (room == null)
            return NotFound("ไม่พบห้อง");

        // 👉 ดึงบิลล่าสุด
        var lastInvoice = await _context.Invoices
            .Where(i => i.RoomId == usage.RoomId)
            .OrderByDescending(i => i.CreatedAt)
            .FirstOrDefaultAsync();

        int previousElectricity = lastInvoice?.CurrentElectricityMeter ?? 0;
        int previousWater = lastInvoice?.CurrentWaterMeter ?? 0;

        // 👉 ตั้ง previous ให้ usage
        usage.PreviousElectricityMeter = previousElectricity;
        usage.PreviousWaterMeter = previousWater;

        int electricityUnits = usage.CurrentElectricityMeter - previousElectricity;
        int waterUnits = usage.CurrentWaterMeter - previousWater;

        if (electricityUnits < 0 || waterUnits < 0)
            return BadRequest("เลขมิเตอร์ต้องมากกว่าครั้งก่อน");

        decimal electricityAmount = electricityUnits * 5m;
        decimal waterAmount = waterUnits * 10m;

        var invoice = new Invoice
        {
            RoomId = usage.RoomId,

            PreviousElectricityMeter = previousElectricity,
            CurrentElectricityMeter = usage.CurrentElectricityMeter,

            PreviousWaterMeter = previousWater,
            CurrentWaterMeter = usage.CurrentWaterMeter,

            TotalElectricity = electricityAmount,
            TotalWater = waterAmount,
            GrandTotal = room.MonthlyRent + electricityAmount + waterAmount,

            Status = "Pending",
            BillingMonth = DateTime.UtcNow
        };

        _context.UtilityUsages.Add(usage);
        _context.Invoices.Add(invoice);
        await _context.SaveChangesAsync();

        return Ok(new
        {
            message = "สร้างบิลสำเร็จ",
            invoiceId = invoice.Id
        });
    }
}
