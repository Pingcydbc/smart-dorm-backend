using Microsoft.EntityFrameworkCore;
using SmartDormApi.Models;

namespace SmartDormApi.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Room> Rooms { get; set; }

    public DbSet<Tenant> Tenants { get; set; }

    public DbSet<Invoice> Invoices { get; set; }

    public DbSet<UtilityUsage> UtilityUsages { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Payment> Payments { get; set; }

}