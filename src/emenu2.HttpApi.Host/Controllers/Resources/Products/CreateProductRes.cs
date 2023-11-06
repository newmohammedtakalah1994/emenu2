﻿using emenu2.Controllers.Resources.ProductVariants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace emenu2.Controllers.Resources.Products
{
    public class CreateProductRes
    {
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string DescEn { get; set; }
        public string DescAr { get; set; }

        public int? ImageId { get; set; }

        public ICollection<CreateProductImageRes> ProductImages { get; set; }

        public ICollection<CreateProductVariantRes> ProductVariants { get; set; }

        

    }
}
