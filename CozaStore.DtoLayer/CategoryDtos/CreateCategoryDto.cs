using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozaStore.DtoLayer.CategoryDtos
{
    public class CreateCategoryDto
    {
        public string CategoryName { get; set; }

        public string Title { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
    }
}
