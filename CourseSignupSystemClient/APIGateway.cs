using CourseSignupSystemServer.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;

namespace CourseSignupSystemClient
{
    public class APIGateway
    {
        private HttpClient httpClient = new HttpClient();
        private string url = "https://localhost:7246/api/ChucVus";

        public List<ChucVu> ListChucVus()
        {
            List<ChucVu> chucVus = new List<ChucVu>();
            if(url.Trim().Substring(0,5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var datacol = JsonConvert.DeserializeObject<List<ChucVu>>(result);
                    if (datacol != null)
                        chucVus = datacol;
                }
                else
                {
                    string result = response.Content.ReadAsStringAsync(). Result;
                    throw new Exception("Error Occured at the API Endpoint, Error Info. " + result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Occured at the API Endpoint, Error Info. " + ex.Message);
            }
            finally { }
            return chucVus;
        }
        public ChucVu CreateChucVu(ChucVu chucVu)
        {
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string json = JsonConvert.SerializeObject(chucVu);
            try
            {
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json")).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<ChucVu>(result);
                    if (data != null)
                        chucVu = data;
                }
                else
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error Occured at the API Endpoint, Error Info. " + result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Occured at the API Endpoint, Error Info. " + ex.Message);
            }
            finally { }
            return chucVu;
        }
        public ChucVu GetChucVu(string id)
        {
            ChucVu chucVu = new ChucVu();
            url = url + "/" + id;
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<ChucVu>(result);
                    if (data != null) 
                        chucVu = data;
                }
                else
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error Occured at the API Endpoint, Error Info. " + result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Occured at the API Endpoint, Error Info. " + ex.Message);
            }
            finally { }
            return chucVu;
        }
        public void UpdateChucVu(ChucVu chucVu)
        {
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string id = chucVu.MaCV;
            url = url + "/" + id;
            string json = JsonConvert.SerializeObject(chucVu);
            try
            {
                HttpResponseMessage response = httpClient.PutAsync(url, new StringContent(json, Encoding.UTF8, "application/json")).Result;
                if (!response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error Occured at the API Endpoint, Error Info. " + result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Occured at the API Endpoint, Error Info. " + ex.Message);
            }
            finally { }
            return;
        }

    }
}
