using Microsoft.EntityFrameworkCore;
using SMSDataAccessLayer.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
    {
    }

    public DbSet<Student> Products { get; set; }
}