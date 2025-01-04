using BarberBoss.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BarberBoss.Infrastructure.DataAccess;

public class BarberBossDbContext : DbContext
{
    public BarberBossDbContext(DbContextOptions options) : base(options) { }
    
    public DbSet<Invoice> Invoices { get; set; }
}