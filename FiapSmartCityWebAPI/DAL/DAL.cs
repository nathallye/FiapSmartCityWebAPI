using FiapSmartCityWebAPI.Models;

namespace FiapSmartCityWebAPI.DAL
{
    public class ProductTypeDAL
    {
        // Lista criada para armezenar uma lista de Tipo de produto simulando o banco de dados
        private static Dictionary<long, ProductType> databaseProductType = new Dictionary<long, ProductType>();
        private static int counterDatabase = 2;

        // Construtor estático serve para criar objetos do Tipo de Produto e Produto
        // Simulando o banco de dados
        static ProductTypeDAL()
        {

            ProductType EnergiaSolar = new ProductType();
            EnergiaSolar.TypeId = 1;
            EnergiaSolar.TypeDescription = "Energia Solar";
            EnergiaSolar.Marketed = true;

            Product FotoVoltatica = new Product();
            FotoVoltatica.ProductId = 800;
            FotoVoltatica.ProductName = "Energia Solar Fotovoltatica";
            FotoVoltatica.Features = @"A tecnologia fotovoltaica (FV) 
                                            converte diretamente os raios 
                                            solares em eletricidade";
            FotoVoltatica.AveragePrice = 4000.00;
            FotoVoltatica.Logotipo = @"data:image/jpeg;base64";
            FotoVoltatica.Active = true;

            //Referência do Novo Produto 
            EnergiaSolar.Add(FotoVoltatica);

            ProductType tinta = new ProductType();
            tinta.TypeId = 2;
            tinta.TypeDescription = "Tinta";
            tinta.Marketed = true;

            //Inserer Registro no Banco
            databaseProductType.Add(1, EnergiaSolar);
            databaseProductType.Add(2, tinta);
        }

        public void Create(ProductType ProductType)
        {
            counterDatabase++;
            ProductType.TypeId = counterDatabase;
            databaseProductType.Add(counterDatabase, ProductType);
        }

        public ProductType GetOne(int TypeId)
        {
            return databaseProductType[TypeId];
        }

        public IList<ProductType> GetAll()
        {
            return new List<ProductType>(databaseProductType.Values);
        }

        public void Delete(int TypeId)
        {
            databaseProductType.Remove(TypeId);
        }

        public void Update(ProductType productType)
        {
            databaseProductType[productType.TypeId] = productType;
        }
    }
}
