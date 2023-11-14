using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace emenu2.Resources.Products
{
    
    public  class FilterPagedProductDto :PagedAndSortedResultRequestDto
    {
        public string? NameEn { get; set; }
        public string? NameAr{ get; set; }
    }
}
