﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozaStore.EntityLayer.Concrete
{
   public class About
    {
        public int AboutID { get; set; }

        public string Title1 { get; set; }
        public string Description1 { get; set; }
        public string ImageURL1 { get; set; }

        public string Title2 { get; set; }
        public string Description2 { get; set; }
        public string ImageURL2 { get; set; }
    }
}
