using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace Clocker.Models
{
    public class ClockerDbContext : DbContext
    {
       private static IConfiguration? Configuration { get; set; }

        public static void SetConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;
        }
       public ClockerDbContext() { }

        public ClockerDbContext(DbContextOptions<ClockerDbContext> options):base(options) { 

        }

        public DbSet<User> Users { get; set; }  
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if(Configuration !=null)
            {
                var connectionString = Configuration.GetConnectionString("MySQLConnection");
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
            else
            {
                Console.WriteLine("Configuration is Null");
            }
           
        }
    }
}
