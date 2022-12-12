using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace ProgressOfStudents.Models
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Students> Students { get; set; }

        public DataBaseContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=WIN-4GV8HVV3T62\\SQLEXPRESS;Database=StudentsDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
