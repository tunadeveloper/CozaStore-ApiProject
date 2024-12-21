using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozaStore.DtoLayer.ProductDtos
{
    public class CreateProductDto
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }

        public int CategoryID { get; set; }
    }
}
