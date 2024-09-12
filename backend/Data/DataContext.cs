using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using web_api.Models;

namespace web_api.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        public DbSet<City> Cities { get; set; }
    }
}
