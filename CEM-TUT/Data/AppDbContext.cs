using CEM_TUT.Models;
using Microsoft.EntityFrameworkCore;

namespace CEM_TUT.Data
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) 
        {
            
        }

        public DbSet<Customer> customers { get; set; }

        public DbSet<Feedback> feedbacks { get; set; }

        public DbSet<GeoAlert> geoalerts { get; set; }

        public DbSet<Service> services { get; set; }    

        public DbSet<Models.ServiceProvider> servicesProviders { get; set; }
   

    }
}
