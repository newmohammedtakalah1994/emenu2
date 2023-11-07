using emenu2.Domain.Contracts;
using emenu2.Domain.Models;
using emenu2.Domain.Helper;
using emenu2.Domain.Queries;
using emenu2.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emenu2.Persistence
{
    public class ImagesRepository : IImageRepository
    {
        private readonly emenu2DbContext _context;

        public ImagesRepository(emenu2DbContext context)
        {
            _context = context;
        }

        public void AddImage(Image image)
        {
            _context.Add(image);
        }

        public void RemoveImage(Image image)
        {
            _context.Remove(image);
        }


    }
}
