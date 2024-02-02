using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RareCrew
{
    internal class Model
    {

        public static string getData()
        {
            HttpClientHandler handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.All
            };

            HttpClient _client = new HttpClient();

            string resJSON = null;

            string uri = "https://rc-vault-fap-live-1.azurewebsites.net/api/gettimeentries?code=vO17RnE8vuzXzPJo5eaLLjXjmRW07law99QTD90zat9FfOQJKKUcgQ==";
            //string uri = "https://rc-vault-fap-live-1.azurewebsites.net/api/gettimeentries?code=" + getApiKey();
            try
            {
                using HttpResponseMessage response = _client.GetAsync(uri).Result;
                response.Content.ReadAsStringAsync();
                resJSON = response.Content.ReadAsStringAsync().Result;

            }
            catch (Exception e)
            {
                Console.Error.WriteLine("EXCEPTION while sending get request! " + e.Message);
                throw e;
            }
            return resJSON;
        }

        private static string getApiKey()
        {
            //should read key from the environment variable
            //for simplicity here we load from the .txt file
            string key = null;

            try
            {
                key = File.ReadAllText("../../../key.txt");

            }catch (Exception e)
            {
                Console.Error.WriteLine("EXCEPTION while reading the api key! " + e.Message);
            }

            return key;

        }
    }
}
