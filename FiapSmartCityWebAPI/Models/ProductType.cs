namespace FiapSmartCityWebAPI.Models
{
    public class ProductType
    {
        public int TypeId { get; set; }
        public string TypeDescription { get; set; }
        public bool Marketed { get; set; }

        public List<Product> Products { get; set; }

        public ProductType() 
        {
            Products = new List<Product>();
        }

        // MOCK - Método para adicionar um produto ao Tipo
        public void Add(Product product)
        {
            this.Products.Add(product);
        }

        // MOCK - Método para remover um produto do tipo
        public void Remove(long id)
        {
            Product product = Products.FirstOrDefault(p => p.ProductId == id);

            Products.Remove(product);
        }

        // MOCK - Método para alterar um produto do tipo
        public void Altera(Product product)
        {
            Remove(product.ProductId);
            Add(product);
        }
    }
}
