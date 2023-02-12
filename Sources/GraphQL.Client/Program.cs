using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace GraphQLClient
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            using (var httpClient = new HttpClient())
            {
                // Set the API endpoint
                httpClient.BaseAddress = new Uri("https://localhost:5001/graphql");
                try {
                    // Build the GraphQL query
                    var query = "{ products { id, name, price } }";
                    var content = new StringContent(
                        "{\"query\":\"" + query + "\"}",
                        Encoding.UTF8,
                        "application/json");


                    // Send the request to the API
                    var response =  httpClient.PostAsync("", content).Result;

                    // Read the response
                    var responseString =  response.Content.ReadAsStringAsync().Result;
                    var responseJson = JObject.Parse(responseString);

                    // Print the response
                    Console.WriteLine(responseJson);
                }
                catch(Exception e)
                {
                    Console.WriteLine($"Error {e.Message}");
                }
                
            }


            
        }
    }
}
