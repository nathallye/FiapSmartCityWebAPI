using System;
using System.Text;
using Newtonsoft.Json;

namespace FiapSmartCityClient
{
    class Program
    {
        static void Main(string[] args)
        {
            get();

            getdesserializado();

            post();
            
            postserializado();
            
            Console.Read();
        }

        static void get()
        {
            // Criando um objeto Cliente para conectar com o recurso.
            System.Net.Http.HttpClient client = new HttpClient();

            // Execute o método Get passando a url da API e salvando o resultado.
            // em um objeto do tipo HttpResponseMessage
            System.Net.Http.HttpResponseMessage response =
                client.GetAsync("https://localhost:7188/api/FiapSmartCityWebAPI/ProductType").Result;

            // Verifica se o Status Code é 200.
            if (response.IsSuccessStatusCode)
            {
                // Recupera o conteúdo JSON retornado pela API
                string conteudo = response.Content.ReadAsStringAsync().Result;

                // Imprime o conteúdo na janela Console.
                Console.Write(conteudo.ToString());
            }
        }

        static void post()
        {
            // Criando um objeto Cliente para conectar com o recurso.
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

            // Conteúdo do tipo de produto em JSON.
            String json = "{ 'TypeID': 100, 'TypeDescription': 'Robo de Limpeza', 'Marketed': true }";

            // Convertendo texto para JSON StringContent. 
            StringContent content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

            // Execute o método POST passando a url da API 
            // e envia o conteúdo do tipo StringContent.
            System.Net.Http.HttpResponseMessage response =
                client.PostAsync("https://localhost:7188/api/FiapSmartCityWebAPI/ProductType", content).Result;

            // Verifica que o POST foi executado com sucesso
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Tipo do produto criado com sucesso");
                Console.Write("Link para consulta: " + response.Headers.Location);
            }
        }

        static void getdesserializado()
        {
            // Criando um objeto Cliente para conectar com o recurso
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

            // Execute o método Get passando a url da API e salvando o resultado 
            // em um objeto do tipo HttpResponseMessage
            System.Net.Http.HttpResponseMessage response =
            client.GetAsync("https://localhost:7188/api/FiapSmartCityWebAPI/ProductType").Result;

            // Verifica se o Status Code é 200
            if (response.IsSuccessStatusCode)
            {
                // Recupera o conteúdo JSON retornado pela API
                string content = response.Content.ReadAsStringAsync().Result;

                // Convertendo o conteúdo em uma lista de TipoProduto
                List<ProductType> list =
                    JsonConvert.DeserializeObject<List<ProductType>>(content);

                // Imprime o conteúdo na janela Console
                foreach (var item in list)
                {
                    Console.WriteLine("Descrição:" + item.TypeDescription);
                    Console.WriteLine("Comercializado:" + item.Marketed);
                    Console.WriteLine(" ========== ");
                    Console.WriteLine("");
                }
            }
        }

        static void postserializado()
        {
            // Criando um objeto Cliente para conectar com o recurso
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

            // Conteudo do tipo de produto em JSON
            ProductType type = new ProductType();
            type.TypeID = 101;
            type.TypeDescription = "Grid de Energia Solar";
            type.Marketed = true;

            var json = JsonConvert.SerializeObject(type);

            // Convertendo texto para JSON StringContent 
            StringContent content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

            // Execute o método POST passando a url da API 
            // e envia o conteudo do tipo StringContent
            System.Net.Http.HttpResponseMessage response =
                client.PostAsync("https://localhost:7013/FiapSmartCityWebAPI", content).Result;

            // Verifica que o POST foi executado com sucesso
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Tipo do produto criado com sucesso");
                Console.Write("Link para consulta: " + response.Headers.Location);
            }
        }
    }
}
