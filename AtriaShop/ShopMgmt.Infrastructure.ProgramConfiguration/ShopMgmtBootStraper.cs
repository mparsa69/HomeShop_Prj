using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopMgmt.Domain.ApplicationService.ProductCategoryApp;
using ShopMgmt.Domain.Core.ProductCategorAgg.Contracts.IAppServices;
using ShopMgmt.Domain.Core.ProductCategorAgg.Contracts.IRepositories;
using ShopMgmt.Ifrastructure.Repositories.EfCore.ProductCategoryRepo;
using ShopMgmt.Infrastructure.Database.SqlServer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMgmt.Infrastructure.ProgramConfiguration
{
    public class ShopMgmtBootStraper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IProductCategoryRepository,ProductCategoryRepository>();
            services.AddTransient<IProductCategoryAppService,ProductCategoryAppService>();
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
