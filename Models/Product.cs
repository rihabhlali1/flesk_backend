namespace FleskBtocBackend.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string title { get; set; } = "";
        public string description { get; set; } = "";
        public decimal price { get; set; }
        public string imageUrl { get; set; } = "";
        public int CategoryId { get; set; } 
        public int quantity { get; set; }
    }

    public class Category
    {
        public int id { get; set; }
        public string name { get; set; } = "";
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
