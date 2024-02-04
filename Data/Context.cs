using APIsrl.Models;
using Microsoft.EntityFrameworkCore;

namespace APIsrl.Data
{
    public class ContextDataBase : DbContext
    {
        public ContextDataBase(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<ClientModel> Clients { get; set; }
        public DbSet<MaterialModel> Materials { get; set; }
        public DbSet<ServiceModel> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}
