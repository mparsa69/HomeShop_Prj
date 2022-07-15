using ShopMgmt.Domain.Core.ProductCategorAgg.Contracts.IRepositories;
using ShopMgmt.Domain.Core.ProductCategorAgg.Dtos;
using ShopMgmt.Domain.Core.ProductCategorAgg.Entities;
using ShopMgmt.Ifrastructure.Repositories.EfCore.GenericRepo;
using ShopMgmt.Infrastructure.Database.SqlServer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopMgmt.Ifrastructure.Repositories.EfCore.ProductCategoryRepo
{
   
    public class ProductCategoryRepository : RepositoryBase<long,ProductCategory>,IProductCategoryRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductCategoryRepository(AppDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
        public EditProductCategoryDto GetDetails(long id)
        {
            var result= _dbContext.ProductCategories.Select(x => new EditProductCategoryDto()
            {
                Id = x.Id,
                Description = x.Description,
                Name = x.Name,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug
            }).FirstOrDefault(x => x.Id == id);
            return result;
        }

        public List<ProductCategorySearchResultDto> Search(ProductCategorySearchDto model)
        {
            var query = _dbContext.ProductCategories.Select(x => new ProductCategorySearchResultDto()
            {
                Id = x.Id,
                Picture = x.Picture,
                Name = x.Name,
                CreationDate = x.CreationDate.ToString()
            });
            if (!string.IsNullOrWhiteSpace(model.Name))
            {
                query = query.Where(x => x.Name.Contains(model.Name));
            }
            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
