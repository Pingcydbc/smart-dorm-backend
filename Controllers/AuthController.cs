using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartDormApi.Data;
using SmartDormApi.Models;

namespace SmartDormApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AuthController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel login)
    {
        // ตรวจสอบชื่อผู้ใช้จากตาราง Users
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == login.Username);

        if (user == null || user.PasswordHash != login.Password)
        {
            return Unauthorized("ชื่อผู้ใช้หรือรหัสผ่านไม่ถูกต้อง");
        }

        return Ok(new
        {
            token = "dummy-jwt-token",
            username = user.Username,
            role = user.Role,
            roomId = user.RoomId
        });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] User user)
    {
        // 1. เช็คว่าห้องที่จะจองนั้นว่างอยู่จริงไหม
        var room = await _context.Rooms.FindAsync(user.RoomId);
        if (room == null || room.Status != "Available")
            return BadRequest("ห้องนี้ไม่ว่างหรือไม่มีอยู่จริง");

        // 2. บันทึกผู้ใช้ใหม่ลงในตาราง Users
        _context.Users.Add(user);

        // 3. อัปเดตสถานะห้องให้เป็น 'Occupied' (มีคนจองแล้ว)
        room.Status = "Occupied";

        await _context.SaveChangesAsync();
        return Ok("ลงทะเบียนและจองห้องสำเร็จ");
    }

    // ⚡ เพิ่มฟังก์ชันสำหรับลบ User เมื่อมีการเช็คเอาต์
    [HttpDelete("delete-by-username/{username}")]
    public async Task<IActionResult> DeleteUserByUsername(string username)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

        // ถ้าไม่เจอ User ไม่ต้องแจ้ง Error 404 ให้หน้าบ้านตกใจ ส่ง 200 กลับไปได้เลย
        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        return Ok($"ระบบจัดการบัญชี {username} เรียบร้อยแล้ว");
    }
}

public class LoginModel
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}