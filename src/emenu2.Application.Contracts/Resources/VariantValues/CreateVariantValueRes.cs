using  emenu2.Application.Contracts.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace emenu2.Application.Contracts.Resources.VariantValues
{
    public class CreateVariantValueRes
    {
        public string ValueEn { get; set; }
        public string ValueAr { get; set; }

        public int VariantId { get; set; }
    }
}
