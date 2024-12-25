namespace CozaStore.WebUI.Dtos.Product
{
    public class GetByIdProductDto
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public string ImageURL2 { get; set; }
        public string ImageURL3 { get; set; }

        public int CategoryID { get; set; }
    }
}
