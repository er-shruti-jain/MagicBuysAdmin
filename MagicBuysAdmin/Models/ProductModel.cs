using System.ComponentModel.DataAnnotations;

namespace MagicBuysAdmin.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public int GST { get; set; }
        public int Total { get; set; }
    }
}
