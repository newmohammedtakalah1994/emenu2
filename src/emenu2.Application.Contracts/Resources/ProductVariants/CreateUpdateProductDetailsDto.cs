﻿using System;
using Volo.Abp.Application.Dtos;

namespace emenu2.Application.Contracts.Resources.ProductVariants
{
    public class CreateUpdateProductDetailsDto : EntityDto
    {
        public Guid? VariantValueId { get; set; }
    }
}
