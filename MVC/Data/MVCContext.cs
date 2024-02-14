using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Data;
public class MVCContext : DbContext
{
    public MVCContext(DbContextOptions<MVCContext> opts) : base(opts)
    {

    }
    public DbSet<User> User { get; set; }
}

