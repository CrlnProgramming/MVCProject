using Microsoft.EntityFrameworkCore;
using MVCProjectWeb.Models;

namespace MVCProjectWeb.Controllers.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Login> Logins { get; set; }
    }
}
