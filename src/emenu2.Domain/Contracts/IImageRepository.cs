using emenu2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emenu2.Domain.Contracts
{
    public interface IImageRepository
    {
        void AddImage(Image image);
    }
}
