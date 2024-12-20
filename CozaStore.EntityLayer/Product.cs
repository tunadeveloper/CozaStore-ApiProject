﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozaStore.EntityLayer
{
    public class Product
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
