using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Welcome.Model;
using Welcome.Others;

namespace DataLayer.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<DatabaseUser> Users { get; set; }
        public DbSet<DatabaseLog> Logs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string solutionFolder = "C:/Users/vasko/OneDrive/TU/Курс 3, Сем 2/ПС/PS_40_Vasil";
            string databaseFile = "Welcome.db";
            string databasePath = Path.Combine(solutionFolder, databaseFile);
            optionsBuilder.UseSqlite($"Data Source={databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatabaseUser>().Property(e => e.Id).ValueGeneratedOnAdd();

            var user1 = new DatabaseUser()
            {
                Id = 1,
                Names = "John Doe",
                Password = "1234",
                Role = UserRolesEnum.ADMIN,
                Expires = DateTime.Now.AddYears(10)
            };
            var user2 = new DatabaseUser()
            {
                Id = 2,
                Names = "Az Azov",
                Password = "123",
                Role = UserRolesEnum.PROFESSOR,
                Expires = DateTime.Now.AddDays(25)
            };
            var user3 = new DatabaseUser()
            {
                Id = 3,
                Names = "asd",
                Password = "asd",
                Role = UserRolesEnum.STUDENT,
                Expires = DateTime.Now.AddMonths(4)
            };
            var user4 = new DatabaseUser()
            {
                Id = 4,
                Names = "Nateg",
                Password = "gad",
                Role = UserRolesEnum.INSPECTOR,
                Expires = DateTime.Now.AddYears(1)
            };
            var user5 = new DatabaseUser()
            {
                Id = 5,
                Names = "Nekuv Drug",
                Password = "321",
                Role = UserRolesEnum.ANONUMOUS,
                Expires = DateTime.Now.AddMonths(2)
            };

            modelBuilder.Entity<DatabaseUser>().HasData(user1, user2, user3, user4, user5);
        }
    }
}
