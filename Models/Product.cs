using FleskBtocBackend.Models;

namespace FleskBtocBackend.Models
{
   public class Product
{
    public int Id { get; set; }
    public string title { get; set; } = "";
    public string description { get; set; } = "";
    public decimal price { get; set; }
    public string imageUrl { get; set; } = "";
    public int categoryId { get; set; }
    public int quantity { get; set; }
    public string features { get; set; } = "";
    public string brand { get; set; } = "";
    public decimal originalPrice { get; set; }
    public decimal discount { get; set; }
    public int stock { get; set; }
    public decimal shippingDiscount { get; set; }
    public string shippingDestination { get; set; } = "";
    public decimal rating { get; set; }
    public List<string> images { get; set; } = new List<string>();
    public string longDescription { get; set; } = "";
    public string highlights { get; set; } = "";
    public string performance { get; set; } = "";
    public string battery { get; set; } = "";
    public string security { get; set; } = "";
    public string screen { get; set; } = "";
    public string resolution { get; set; } = "";
    public string processor { get; set; } = "";
    public string ram { get; set; } = "";
    public string storage { get; set; } = "";
    public string frontCamera { get; set; } = "";
    public string rearCamera { get; set; } = "";
    public string sim { get; set; } = "";
    public string os { get; set; } = "";
    public string connectivity { get; set; } = "";
    public string sku { get; set; } = "";
    public string gtin { get; set; } = "";
    public string range { get; set; } = "";
    public string model { get; set; } = "";
    public string weight { get; set; } = "";
    public string color { get; set; } = "";

    // Add any additional properties you need
    public int reviewsCount { get; set; }
    public string contactNumber { get; set; } = "";
    public bool express { get; set; }
    public decimal freeShippingThreshold { get; set; }
    public string newCustomerCode { get; set; } = "";
    public decimal newCustomerDiscount { get; set; }
    public decimal newCustomerLimit { get; set; } // Added property
}

    public class Category
{
    public int id { get; set; }
    public string name { get; set; } = "";
    public ICollection<Product> Products { get; set; } = new List<Product>();
}

}

