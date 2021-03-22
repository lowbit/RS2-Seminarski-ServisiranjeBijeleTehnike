using Flurl.Http;
using SBT.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SBT.Mobile
{
    class APIService
    {
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static int KorisnikId { get; set; }

        private string _route = null;

        //For UWP
        private string _apiUrl = "";

        public APIService(string route)
        {
            _route = route;
            if (Device.RuntimePlatform == Device.UWP)
            {
                _apiUrl = "http://localhost:5000/api";
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                _apiUrl = "http://10.0.2.2:5000/api";
            }
        }
        public async Task<T> Get<T>(string additionalPath = "")
        {
            try
            {
                string url;
                if (additionalPath == "" || additionalPath == null)
                    url = $"{_apiUrl}/{_route}";
                else
                    url = $"{_apiUrl}/{_route}/{additionalPath}";

                var result = await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
                return result;
            }
            catch (FlurlHttpException ex)
            {
                if(ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Niste authentificirani", "OK");
                }
                throw;
            }
        }
        public async Task<T> GetById<T>(object id)
        {
            var result = await $"{_apiUrl}/{_route}/{id}".WithBasicAuth(Username, Password).GetJsonAsync<T>();
            return result;
        }

        public async Task<T> GetParam<T>(string additionalPath, object param)
        {

            string url;
            if (additionalPath == "")
                url = $"{_apiUrl}/{_route}";
            else
                url = $"{_apiUrl}/{_route}/{additionalPath}";

            if (param != null)
            {
                url += "?";
                url += await param.ToQueryString();
            }
            var result = await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            return result;
        }
        public async Task<T> Insert<T>(object request, string additionalPath = "")
        {
            string url;
            try
            {
                if (additionalPath == "")
                    url = $"{_apiUrl}/{_route}";
                else
                    url = $"{_apiUrl}/{_route}/{additionalPath}";

                return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();

            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }
                await Application.Current.MainPage.DisplayAlert("Greška", stringBuilder.ToString(), "OK");
                return default(T);
            }
        }
        public async Task<T> InsertNoAuth<T>(object request, string additionalPath = "")
        {
            string url;
            try
            {
                if (additionalPath == "")
                    url = $"{_apiUrl}/{_route}";
                else
                    url = $"{_apiUrl}/{_route}/{additionalPath}";

                return await url.PostJsonAsync(request).ReceiveJson<T>();

            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }
                await Application.Current.MainPage.DisplayAlert("Greška", stringBuilder.ToString(), "OK");
                return default(T);
            }
        }
        public async Task<T> Update<T>(object request, int _id, string additionalPath = "")
        {
            string url;
            if (additionalPath == "")
                url = $"{_apiUrl}/{_route}/{_id}";
            else
                url = $"{_apiUrl}/{_route}/{additionalPath}/{_id}";

            return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
        }
        public async Task<T> Authenticate<T>(string username, string password)
        {
            try
            {
                var url = $"{_apiUrl}/{_route}/Authenticate/{username},{password}";

                return await url.GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Niste authentificirani", "OK");
                }
                throw;
            }
        }
    }
}
