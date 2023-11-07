using AutoMapper;
using emenu2.Application.Contracts.Resources;
using emenu2.Domain.Helper;
using emenu2.Domain.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace emenu2.Application.Services
{
    public class HelperService : ApplicationService
    {
        private readonly IMapper _mapper;
        public HelperService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public PagedListRes<R> ToPageListResource<T, R>(PagedList<T> pagedList)
        {
            var listRes = _mapper.Map<IEnumerable<T>, IEnumerable<R>>(pagedList.List);

            return new PagedListRes<R>(_mapper.Map<PagingInfo, PagingInfoRes>(pagedList.GetInfo()), listRes.ToList());
        }

    }
}
