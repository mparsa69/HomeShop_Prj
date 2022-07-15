using ShopMgmt.Domain.Core.ProductCategorAgg.Contracts.IAppServices;
using ShopMgmt.Domain.Core.ProductCategorAgg.Contracts.IRepositories;
using ShopMgmt.Domain.Core.ProductCategorAgg.Dtos;
using ShopMgmt.Domain.Core.ProductCategorAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace ShopMgmt.Domain.ApplicationService.ProductCategoryApp
{
    public class ProductCategoryAppService : IProductCategoryAppService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        public ProductCategoryAppService(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }
        public OperationResult Create(CreateProductCategoryDto model)
        {
            var operation = new OperationResult();
            if (_productCategoryRepository.Exists(x=>x.Name==model.Name))
            {
                return operation.Faild();
            }
            var productCategory = new ProductCategory()
            {
                CreationDate=DateTime.Now,
                Slug=model.Slug.Slugify(),
                Description=model.Description,
                Keywords=model.Keywords,
                MetaDescription=model.MetaDescription,
                Name=model.Name,
                Picture=model.Picture,
                PictureAlt=model.PictureAlt,
                PictureTitle=model.PictureTitle
            };
            model.Slug = model.Slug.Slugify(); 
            _productCategoryRepository.Create(productCategory);
            return operation.Succeded();
        }

        public OperationResult Update(EditProductCategoryDto model)
        {
            var operation = new OperationResult();
            var productCategory = _productCategoryRepository.Get(model.Id);
            if (productCategory == null)    
                return operation.Faild();
            if(_productCategoryRepository.Exists(x=>x.Id!=model.Id&& x.Name==model.Name))
                return operation.Faild();

            productCategory.Slug = model.Slug.Slugify();
            productCategory.Description = model.Description;
            productCategory.Keywords = model.Keywords;
            productCategory.MetaDescription = model.MetaDescription;
            productCategory.Name = model.Name;
            productCategory.Picture = model.Picture;
            productCategory.PictureAlt = model.PictureAlt;
            productCategory.PictureTitle = model.PictureTitle;
            _productCategoryRepository.Update(productCategory);
            return operation.Succeded();
        }

        public EditProductCategoryDto GetDetails(long id)
        {
            return _productCategoryRepository.GetDetails(id);
        }

        public List<ProductCategorySearchResultDto> Search(ProductCategorySearchDto model)
        {
            return _productCategoryRepository.Search(model);
        }

        
    }
}
