using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMgmt.Domain.Core.ProductCategorAgg.Dtos
{
    public class EditProductCategoryDto:CreateProductCategoryDto
    {
        public long Id { get; set; }
    }
}
