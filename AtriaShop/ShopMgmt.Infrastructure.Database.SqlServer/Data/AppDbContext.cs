using Microsoft.EntityFrameworkCore;
using ShopMgmt.Domain.Core.ProductCategorAgg.Entities;
using ShopMgmt.Infrastructure.Database.SqlServer.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMgmt.Infrastructure.Database.SqlServer.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        protected   void OnModelCreateing(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ProductCategoryConfiguration).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
