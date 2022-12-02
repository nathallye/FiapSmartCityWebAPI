using System;


namespace FiapSmartCityClient.Models
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
    }
}
