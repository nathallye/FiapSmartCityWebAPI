using System;

namespace FiapSmartCityClient.Models
{
    public class ProductType
    {
        public int TypeId { get; set; }
        public string TypeDescription { get; set; }
        public bool Marketed { get; set; }

        public List<Product> Products { get; set; }
    }
}
