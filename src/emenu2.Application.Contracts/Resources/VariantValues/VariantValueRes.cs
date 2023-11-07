using emenu2.Application.Contracts.Resources.Variants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emenu2.Application.Contracts.Resources.VariantValues
{
    public class VariantValueRes
    {
        public int Id { get; set; }
        public string ValueEn { get; set; }
        public string ValueAr { get; set; }

        public int VariantId { get; set; }
        public VariantRes Variant { get; set; }
    }
}

