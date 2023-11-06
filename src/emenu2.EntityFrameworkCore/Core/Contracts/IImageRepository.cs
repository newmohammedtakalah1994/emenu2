using emenu2.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emenu2.Core.Contracts
{
    public interface IImageRepository
    {
        void AddImage(Image image);
    }
}
