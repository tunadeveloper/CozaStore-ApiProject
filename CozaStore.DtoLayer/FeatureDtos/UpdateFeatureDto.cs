﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozaStore.DtoLayer.FeatureDtos
{
    public class UpdateFeatureDto
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string ImageURL { get; set; }
    }
}
