using ShopMgmt.Domain.Core.IGenericRepository;
using ShopMgmt.Domain.Core.ProductCategorAgg.Dtos;
using ShopMgmt.Domain.Core.ProductCategorAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopMgmt.Domain.Core.ProductCategorAgg.Contracts.IRepositories
{
    public interface IProductCategoryRepository:IRepositoryBase<long,ProductCategory>
    {
        
        
        EditProductCategoryDto GetDetails(long id);
        List<ProductCategorySearchResultDto> Search(ProductCategorySearchDto model);
    }
}
