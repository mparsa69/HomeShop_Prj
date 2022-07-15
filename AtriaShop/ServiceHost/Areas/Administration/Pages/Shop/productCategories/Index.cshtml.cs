using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopMgmt.Domain.Core.ProductCategorAgg.Contracts.IAppServices;
using ShopMgmt.Domain.Core.ProductCategorAgg.Dtos;

namespace ServiceHost.Areas.Administration.Shop.productCategories
{
    public class IndexModel : PageModel
    {
        public ProductCategorySearchDto SearchModel { get; set; }
        public List<ProductCategorySearchResultDto> ProductCategoriesDto { get; set; }
        private readonly IProductCategoryAppService _ProductCategoryAppService;

        public IndexModel(IProductCategoryAppService productCategoryAppService)
        {
            _ProductCategoryAppService = productCategoryAppService;
        }

        public void OnGet(ProductCategorySearchDto searchModel)
        {
            ProductCategoriesDto = _ProductCategoryAppService.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateProductCategoryDto());
        }
        public JsonResult OnPostCreate(CreateProductCategoryDto model)
        {
            var result = _ProductCategoryAppService.Create(model);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var editProductCategory = _ProductCategoryAppService.GetDetails(id);
            return Partial("./Edit", editProductCategory);
        }
        public JsonResult OnPostEdit(EditProductCategoryDto model)
        {
            var result=_ProductCategoryAppService.Update(model);
            return new JsonResult(result);
        }
    }
}
