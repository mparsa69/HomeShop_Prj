using ShopMgmt.Domain.Core.ProductCategorAgg.Dtos;
using ShopMgmt.Domain.Core.ProductCategorAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace ShopMgmt.Domain.Core.ProductCategorAgg.Contracts.IAppServices
{
    public interface IProductCategoryAppService 
    {
        OperationResult Create(CreateProductCategoryDto model);
        OperationResult Update(EditProductCategoryDto model);
        EditProductCategoryDto GetDetails(long id);
        List<ProductCategorySearchResultDto> Search(ProductCategorySearchDto model);
    }
}
