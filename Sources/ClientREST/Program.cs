using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using DTOs;
using Newtonsoft.Json;

namespace  ClientREST
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            client.BaseAddress = new Uri("https://localhost:7160/api/v1/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {

                Console.WriteLine("\n\n-------INFO PRODUCTS---------\n");
                // Get all products

                Console.WriteLine("\n\n-------LIST PRODUCTS---------\n");
                var response = client.GetAsync("Products").Result;
                if (response.IsSuccessStatusCode)
                {
                    string products = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine("All products:");
                    Console.WriteLine(JsonConvert.DeserializeObject(products));
                }
                else
                {
                    Console.WriteLine("Error while getting all products");
                }

                Console.WriteLine("\n\n------- PRODUCTS BY ID 2---------\n");
                // Get product by id
                int productId = 2;
                response = client.GetAsync("Products/" + productId).Result;
                if (response.IsSuccessStatusCode)
                {
                    string product = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine("Product with id " + productId + ":");
                    Console.WriteLine(JsonConvert.DeserializeObject(product));
                }
                else
                {
                    Console.WriteLine("Error while getting product with id " + productId);
                }


                Console.WriteLine("\n\n-------NEW PRODUCT---------\n");
                // Insert new product
                var newProduct = new ProductDTO
                {
                    Name = "Product X",
                    Price = 10,
                    Quantity = 12
                };

                response = client.PostAsJsonAsync("Products", newProduct).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("New product inserted");
                }
                else
                {
                    Console.WriteLine("Error while inserting new product");
                }

                Console.WriteLine("\n\n-------DELETE PRODUCT PRODUCT---------\n");
                // Delete product
                productId = 2;
                response = client.DeleteAsync("Products/" + productId).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Product with id " + productId + " deleted");
                }
                else
                {
                    Console.WriteLine("Error while deleting product with id " + productId);
                }


                Console.WriteLine("\n\n---------------------------\n");

                // STOCK
                Console.WriteLine("\n\n-------INFO STOCKS---------\n");
                // Get all STOCKS

                Console.WriteLine("\n\n-------ALL STOCKS---------\n");
                var responseS = client.GetAsync("Stocks").Result;
                if (responseS.IsSuccessStatusCode)
                {
                    string stocks = responseS.Content.ReadAsStringAsync().Result;
                    Console.WriteLine("All stocks:");
                    Console.WriteLine(JsonConvert.DeserializeObject(stocks));
                }
                else
                {
                    Console.WriteLine("Error while getting all stocks");
                }

                Console.WriteLine("\n\n------- STOCKS BY ID ---------\n");
                // Get stock by id
                int stocksId = 2;
                responseS = client.GetAsync("Stocks/" + stocksId).Result;
                if (responseS.IsSuccessStatusCode)
                {
                    string stocks = responseS.Content.ReadAsStringAsync().Result;
                    Console.WriteLine("stocks with id " + stocksId + ":");
                    Console.WriteLine(JsonConvert.DeserializeObject(stocks));
                }
                else
                {
                    Console.WriteLine("Error while getting stocks with id " + stocksId);
                }


                Console.WriteLine("\n\n-------NEW STOCKS---------\n");
                // Insert new stock
                var newStocks = new StockDTO
                {
                    Name = "Product X",
                };

                responseS = client.PostAsJsonAsync("Stocks", newStocks).Result;
                if (responseS.IsSuccessStatusCode)
                {
                    Console.WriteLine("New  Stocks inserted");
                }
                else
                {
                    Console.WriteLine("Error while inserting new Stocks");
                }

                Console.WriteLine("\n\n-------DELETE STOCKS---------\n");
                // Delete stock
                stocksId = 2;
                response = client.DeleteAsync("Stocks/" + stocksId).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Stock with id " + stocksId + " deleted");
                }
                else
                {
                    Console.WriteLine("Error while deleting Stock with id " + stocksId);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}
