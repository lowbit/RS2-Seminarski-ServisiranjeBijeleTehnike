using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl;
using SBT.Model;

namespace SBT.WinUI
{
    public class APIService
    {

        public static string Username { get; set; }
        public static string Password { get; set; }

        private string _route = null;
        public APIService(string route)
        {
            _route = route;
        }
        public async Task<T> Get<T>(string additionalPath = "")
        {
            string url;
            if (additionalPath == "")
                url = $"{Properties.Settings.Default.APIUrl}/{_route}";
            else
                url = $"{Properties.Settings.Default.APIUrl}/{_route}/{additionalPath}";

            var result = await url.WithBasicAuth(Username,Password).GetJsonAsync<T>();
            return result;
        }
        public async Task<T> GetById<T>(object id)
        {
            var result = await $"{Properties.Settings.Default.APIUrl}/{_route}/{id}".WithBasicAuth(Username, Password).GetJsonAsync<T>();
            return result;
        }

        public async Task<T> GetParam<T>(string additionalPath, object param)
        {

            string url;
            if (additionalPath == "")
                url = $"{Properties.Settings.Default.APIUrl}/{_route}";
            else
                url = $"{Properties.Settings.Default.APIUrl}/{_route}/{additionalPath}";

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
            if (additionalPath == "")
                url = $"{Properties.Settings.Default.APIUrl}/{_route}";
            else
                url = $"{Properties.Settings.Default.APIUrl}/{_route}/{additionalPath}";
            
            return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
        }
        public async Task<T> Update<T>(object request, int _id, string additionalPath = "")
        {
            string url;
            if (additionalPath == "")
                url = $"{Properties.Settings.Default.APIUrl}/{_route}/{_id}";
            else
                url = $"{Properties.Settings.Default.APIUrl}/{_route}/{additionalPath}/{_id}";

            return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
        }
        public async Task<T> Authenticate<T>(string username, string password)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}/Authenticate/{username},{password}";

            return await url.GetJsonAsync<T>();
        }
    }
}
