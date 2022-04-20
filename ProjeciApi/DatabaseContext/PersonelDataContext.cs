using Microsoft.EntityFrameworkCore;
using ProjeciApi.Models;

namespace ProjeciApi.DatabaseContext
{
    public class PersonelDataContext : DbContext
    {

        /*   private string connectionString;

           public PersonelDataContext() : base()
           {
             var builder = new ConfigurationBuilder();
               builder.AddJsonFile("appsettings.json", optional: false);

               var configuration = builder.Build();

               connectionString = configuration.GetConnectionString("PersonelAppConn").ToString();

     }  */
        public PersonelDataContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<Company> Companies { get; set; }
            

    }
}
