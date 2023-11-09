﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace emenu2.Domain.Models
{
    public class ProductDetails : FullAuditedEntity<Guid>
    {
     //   public int Id { get; set; }
        public Guid? ProductVariantId { get; set; }
        public ProductVariant? ProductVariant { get; set; }

        public Guid? VariantValueId { get; set; }
        public VariantValue? VariantValue { get; set; }
        protected ProductDetails()
        {

        }
        public ProductDetails(Guid id)
         : base(id)
        {

        }

    }
}
