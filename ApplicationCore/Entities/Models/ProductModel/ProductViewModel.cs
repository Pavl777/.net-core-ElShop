using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities.Models.ProductModel
{
    class ProductViewModel
    {
        public IEnumerable<ProductModel> CatalogItems { get; set; }
    }
}
