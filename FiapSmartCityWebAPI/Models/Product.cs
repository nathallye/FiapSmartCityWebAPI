namespace FiapSmartCityWebAPI.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Features { get; set; }
        public double AveragePrice { get; set; }
        public string Logotipo { get; set; }
        public bool Active { get; set; }

        // Referência para classe TipoProduto
        public ProductType ProductTypeId { get; set; }
        
        public Product() 
        { 
        }

        public Product(int productId, string productName, string features, double averagePrice, string logotipo, bool active, ProductType productTypeId)
        {
            ProductId = productId;
            ProductName = productName;
            Features = features;
            AveragePrice = averagePrice;
            Logotipo = logotipo;
            Active = active;
            ProductTypeId = productTypeId;
        }
    }
}
