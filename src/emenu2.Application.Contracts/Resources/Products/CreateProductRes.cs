using emenu2.Application.Contracts.Resources.ProductVariants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace emenu2.Application.Contracts.Resources.Products
{
    public class CreateProductRes :EntityDto
    {
        public string? NameEn { get; set; }
        public string? NameAr { get; set; }
        public string? DescEn { get; set; }
        public string? DescAr { get; set; }

        public Guid? ImageId { get; set; }

        public ICollection<CreateProductImageRes>? ProductImages { get; set; }

        public ICollection<CreateProductVariantRes>? ProductVariants { get; set; }

        

    }
}
