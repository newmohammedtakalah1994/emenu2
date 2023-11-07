﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emenu2.Application.Contracts.Resources.ProductVariants
{
    public class ProductVariantRes
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ICollection<ProductDetailsRes> ProductDetails { get; set; }
        public ICollection<ProductVariantImageRes> ProductVariantImages { get; set; }
    }
}

