using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DataGrid
{
    public partial class ApiHelper<T>
    {
        public static HttpClient apiClient = new HttpClient();

        public static void InitializeClient()
        {
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> getMethod(string url)
        {
            try
            {
                HttpResponseMessage response = await apiClient.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.StatusCode + " - " + response.ReasonPhrase);
                }
                string data = await response.Content.ReadAsStringAsync();
                T t = JsonConvert.DeserializeObject<T>(data);
                return t;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<T> postMethod(string url,object o)
        {
            try {
                StringContent stringContent = new StringContent(JsonConvert.SerializeObject(o),Encoding.UTF8, "application/json");
                HttpResponseMessage response = await apiClient.PostAsync(url, stringContent);
                if(!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.StatusCode + " - " + response.ReasonPhrase);
                }
                string data = await response.Content.ReadAsStringAsync();
                T t = JsonConvert.DeserializeObject<T>(data);
                return t;
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }

        public async Task<bool> putMethod(string url, object o)
        {
            try
            {
                StringContent stringContent = new StringContent(JsonConvert.SerializeObject(o), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await apiClient.PutAsync(url, stringContent);
                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<T> deleteMethod(string url)
        {
            try
            {
                HttpResponseMessage response = await apiClient.DeleteAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.StatusCode + " - " +response.ReasonPhrase);
                }
                string data = await response.Content.ReadAsStringAsync();
                T t = JsonConvert.DeserializeObject<T>(data);
                return t;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public ApiHelper ()
        {
            InitializeClient();

        }
    }
}
