using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace emenu2.Resources.Products
{
    
    public  class FilterPagedProductDto :PagedAndSortedResultRequestDto
    {
        public String? NameEn { get; set; }
        public String? NameAr{ get; set; }
    }
}
