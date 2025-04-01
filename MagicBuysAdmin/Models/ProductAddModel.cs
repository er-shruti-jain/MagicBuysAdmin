namespace MagicBuysAdmin.Models
{
    public class ProductAddModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public IFormFile? MainImage { get; set; }
    }
}
