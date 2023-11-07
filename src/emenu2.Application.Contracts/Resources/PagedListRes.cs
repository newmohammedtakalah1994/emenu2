using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emenu2.Application.Contracts.Resources
{

    public class PagingInfoRes
    {
        public int TotalItems { get; }
        public int PageNumber { get; }
        public int PageSize { get; }
        public int TotalPages { get; }

        public PagingInfoRes(
           int totalItems, int pageNumber, int pageSize, int totalPages)
        {
            this.TotalItems = totalItems;
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.TotalPages = totalPages;
        }


    }

    public class PagedListRes<R>
    {

        public PagingInfoRes PagingInfo { get; set; }

        public List<R> Items { get; set; }

        public PagedListRes(PagingInfoRes pagingInfo, List<R> _Items)
        {
            this.PagingInfo = pagingInfo;
            this.Items = _Items;
        }
    }


}
