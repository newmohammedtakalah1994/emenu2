using emenu2.Controllers.Resources.Products;
using emenu2.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emenu2.Controllers.Resources.ProductVariants
{
    public class ProductVariantRes
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ICollection<ProductDetailsRes> ProductDetails { get; set; }
        public ICollection<ProductVariantImageRes> ProductVariantImages { get; set; }
    }
}

