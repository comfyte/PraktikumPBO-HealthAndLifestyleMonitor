using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Windows;

namespace HealthAndLifestyleMonitor
{
    public class Cuaca
    {
        private CuacaObject _cuacaObject;

        private IRestResponse OpenWeatherMapApiGet(string path)
        {
            string apiKey = "";

            var client = new RestClient($"http://api.openweathermap.org/data/2.5/{path}&appid={apiKey}");
            var request = new RestRequest(Method.GET);

            return client.Execute(request);
        }

        private IRestResponse OpenUvApiGet(string path)
        {
            var client = new RestClient("https://api.openuv.io/api/v1/" + path);
            var request = new RestRequest(Method.GET);

            request.AddHeader("x-access-token", "");

            return client.Execute(request);
        }

        private CuacaObject FetchCuaca(string lokasi)
        {
            try
            {
                // Dapatkan info cuaca
                string weatherPath = $"weather?q={lokasi}&lang=id{GetUnitParameter()}";
                IRestResponse weatherResponse = OpenWeatherMapApiGet(weatherPath);
                CuacaObject cuacaObject = JsonSerializer.Deserialize<CuacaObject>(weatherResponse.Content);

                // Atur format menjadi en-US agar menggunakan tanda titik sebagai pemisah desimal
                string latitude = cuacaObject.coordinate.lat.ToString(CultureInfo.CreateSpecificCulture("en-US"));
                string longitude = cuacaObject.coordinate.lon.ToString(CultureInfo.CreateSpecificCulture("en-US"));

                // Dapatkan info indeks UV
                string uvPath = $"uv?lat={latitude}&lng={longitude}";
                IRestResponse uvResponse = OpenUvApiGet(uvPath);
                cuacaObject.uvIndex = JsonSerializer.Deserialize<UVParentObject>(uvResponse.Content);

                // Asumsikan segala eror yang terjadi disebabkan oleh limit API (indeks UV)
                if (cuacaObject.uvIndex.error != "")
                    MessageBox.Show("Tidak bisa memperoleh data indeks UV karena telah melebihi batas harian penggunaan API OpenUV. (Pesan eror: " + cuacaObject.uvIndex.error + ")",
                        "Request API Gagal", MessageBoxButton.OK, MessageBoxImage.Error);

                return cuacaObject;
            }
            catch
            {
                MessageBox.Show("Gagal memperoleh informasi cuaca", "Galat", MessageBoxButton.OK, MessageBoxImage.Error);
                return new CuacaObject();
            }
        }

        private bool LokasiValid(string lokasi)
        {
            // Lakukan uji coba pengambilan data cuaca
            CuacaObject checkObject = FetchCuaca(lokasi);

            // Check HTTP 200 OK return code
            if (checkObject.httpStatusCode == 200)
            {
                return true;
            }
            return false;
        }

        public void RefreshCuaca()
        {
            _cuacaObject = null;
        }

        public string Lokasi
        {
            get
            {
                if (_cuacaObject == null)
                    _cuacaObject = FetchCuaca(LocationPref);
                return _cuacaObject.location;
            }
        }

        public Uri IkonCuaca
        {
            get
            {
                if (_cuacaObject == null)
                    _cuacaObject = FetchCuaca(LocationPref);

                if (_cuacaObject.weatherInfo.icon == "")
                    return null;

                return new Uri($"http://openweathermap.org/img/wn/{_cuacaObject.weatherInfo.icon}@2x.png");
            }
        }

        public string Deskripsi
        {
            get
            {
                if (_cuacaObject == null)
                    _cuacaObject = FetchCuaca(LocationPref);
                return _cuacaObject.weatherInfo.description;
            }
        }

        public string Suhu
        {
            get
            {
                if (_cuacaObject == null)
                    _cuacaObject = FetchCuaca(LocationPref);

                return _cuacaObject.airConditionInfo.temperature.ToString() +
                    (TemperatureUnitPref == "K" ? " " : " \xb0") + TemperatureUnitPref;
            }
        }

        public string InfoOlahragaText
        {
            get
            {
                if (_cuacaObject == null)
                    _cuacaObject = FetchCuaca(LocationPref);

                if (_cuacaObject.httpStatusCode != 200)
                    return "Gagal memperoleh informasi cuaca.";

                // Cek jika indeks UV tidak membahayakan
                if ((_cuacaObject.uvIndex.result.uv <= 5) &&
                    // Cek jika waktu saat ini belum melewati waktu senja
                    (DateTime.Compare(DateTime.Now, _cuacaObject.uvIndex.result.sunInfo.sunTimes.duskLocalTime) <= 0) &&
                    // Cek jika waktu saat ini telah melewati waktu fajar
                    (DateTime.Compare(DateTime.Now, _cuacaObject.uvIndex.result.sunInfo.sunTimes.dawnLocalTime) >= 0) &&
                    // Cek jika kondisi cuaca tidak buruk (grup kode cuaca 80*)
                    (_cuacaObject.weatherInfo.weatherCode >= 800) && (_cuacaObject.weatherInfo.weatherCode <= 899))
                {
                    return "Waktu yang tepat untuk berolahraga!";
                }
                else
                {
                    return "Saat ini kurang cocok untuk berolahraga.";
                }
            }
        }

        public string WaktuPembaruanText
        {
            get
            {
                if (_cuacaObject.httpStatusCode != 200)
                    return "";

                return "Terakhir diperbarui pada " + HLBase.WaktuSekarang;
            }
        }

        public string UVText
        {
            get
            {
                if (_cuacaObject == null)
                    _cuacaObject = FetchCuaca(LocationPref);

                if (_cuacaObject.uvIndex.result.uv == -1)
                    return "Gagal dalam memperoleh informasi indeks UV.";

                return "Indeks cahaya UV saat ini sekitar " + _cuacaObject.uvIndex.result.uv.ToString() + ".";
            }
        }

        public string LocationPref
        {
            get
            {
                using (var db = new HLDatabaseContext())
                {
                    return db.UserPrefs.Where(w => w.Name == "weather-location").First().StringValue;
                }
            }
            set
            {
                if (LokasiValid(value))
                {
                    using (var db = new HLDatabaseContext())
                    {
                        db.UserPrefs.Where(w => w.Name == "weather-location").First().StringValue = value;
                        db.SaveChanges();
                    }
                    _cuacaObject = null;
                }
                else
                {
                    throw new InvalidOperationException("lokasi-tidak-valid");
                }
            }
        }

        private string GetUnitParameter()
        {
            string unitParam = "&units=";
            using (var db = new HLDatabaseContext())
            {
                switch (TemperatureUnitPref)
                {
                    case "C":
                        unitParam += "metric";
                        break;
                    case "F":
                        unitParam += "imperial";
                        break;
                    default:
                    case "K":
                        unitParam = "";
                        break;
                }
            }
            return unitParam;
        }

        public string TemperatureUnitPref
        {
            get
            {
                using (var db = new HLDatabaseContext())
                {
                    return db.UserPrefs.Where(u => u.Name == "temperature-unit").First().StringValue;
                }
            }
            set
            {
                if (value == "C" || value == "F" || value == "K")
                {
                    using (var db = new HLDatabaseContext())
                    {
                        db.UserPrefs.Where(u => u.Name == "temperature-unit").First().StringValue = value;
                        db.SaveChanges();
                    }
                }
                else
                {
                    throw new InvalidOperationException("satuan-temperatur-tidak-valid");
                }
            }
        }
    }
}
