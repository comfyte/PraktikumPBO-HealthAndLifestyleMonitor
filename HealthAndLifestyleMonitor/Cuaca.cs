using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Windows;

namespace HealthAndLifestyleMonitor
{
    public class Cuaca
    {
        private string _apiKey = "d383e9ec57f3ab586ea47d2124225d90";

        public void GetCuaca()
        {
            var client = new RestClient("http://api.openweathermap.org/data/2.5/weather?q=yogyakarta&lang=id&appid=d383e9ec57f3ab586ea47d2124225d90");
            var request = new RestRequest(Method.GET);

            IRestResponse response = client.Execute(request);

            CuacaObject testobje = JsonSerializer.Deserialize<CuacaObject>(response.Content);

            MessageBox.Show(testobje.ToString());
        }
        public bool CekLokasi()
        {
            return true;
        }
    }
}
