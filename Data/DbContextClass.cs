using CQRSDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSDemo.Data
{
    public class DbContextClass: DbContext
    {
        protected IConfiguration Configuration;
        public DbContextClass(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<StudentDetails> Students { get; set; }
    }
}
