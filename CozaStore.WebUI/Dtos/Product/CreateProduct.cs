﻿namespace CozaStore.WebUI.Dtos.Product
{
    public class CreateProduct
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }

        public int CategoryID { get; set; }
    }
}