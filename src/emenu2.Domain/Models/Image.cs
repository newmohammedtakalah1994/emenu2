
namespace emenu2.Domain.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Image
    {
        public Image()
        {
        }
    
        public int Id { get; set; }
        public byte[] ImageInDb { get; set; }
        public string ImageUrl { get; set; }
    }
}
