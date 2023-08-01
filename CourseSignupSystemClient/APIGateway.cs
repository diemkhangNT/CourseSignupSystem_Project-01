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
        private string urlChucVu = "https://localhost:7246/api/ChucVus";
        private string urlBoMon = "https://localhost:7246/api/BoMons";
        private string urlLoaiDiem = "https://localhost:7246/api/LoaiDiems";

        #region Call API Chức vụ
        public List<ChucVu> ListChucVus()
        {
            List<ChucVu> chucVus = new List<ChucVu>();
            if(urlChucVu.Trim().Substring(0,5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(urlChucVu).Result;
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
            if (urlChucVu.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string json = JsonConvert.SerializeObject(chucVu);
            try
            {
                HttpResponseMessage response = httpClient.PostAsync(urlChucVu, new StringContent(json, Encoding.UTF8, "application/json")).Result;
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
                    throw new Exception(result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { }
            return chucVu;
        }
        public ChucVu GetChucVu(string id)
        {
            ChucVu chucVu = new ChucVu();
            urlChucVu = urlChucVu + "/" + id;
            if (urlChucVu.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(urlChucVu).Result;
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
            if (urlChucVu.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string id = chucVu.MaCV;
            urlChucVu = urlChucVu + "/" + id;
            string json = JsonConvert.SerializeObject(chucVu);
            try
            {
                HttpResponseMessage response = httpClient.PutAsync(urlChucVu, new StringContent(json, Encoding.UTF8, "application/json")).Result;
                if (!response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception(result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { }
            return;
        }
        public void DeleteChucVu(string id)
        {
            if (urlChucVu.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            urlChucVu = urlChucVu + "/" + id;
            try
            {
                HttpResponseMessage response = httpClient.DeleteAsync(urlChucVu).Result;
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
        #endregion

        #region Loại điểm
        public List<BoMon> ListBoMons()
        {
            List<BoMon> boMons = new List<BoMon>();
            if (urlBoMon.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(urlBoMon).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var datacol = JsonConvert.DeserializeObject<List<BoMon>>(result);
                    if (datacol != null)
                        boMons = datacol;
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
            return boMons;
        }
        public BoMon CreateBoMon(BoMon boMon)
        {
            if (urlBoMon.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string json = JsonConvert.SerializeObject(boMon);
            try
            {
                HttpResponseMessage response = httpClient.PostAsync(urlBoMon, new StringContent(json, Encoding.UTF8, "application/json")).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<BoMon>(result);
                    if (data != null)
                        boMon = data;
                }
                else
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception(result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { }
            return boMon;
        }
        public BoMon GetBoMon(string id)
        {
            BoMon boMon = new BoMon();
            urlBoMon = urlBoMon + "/" + id;
            if (urlBoMon.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(urlBoMon).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<BoMon>(result);
                    if (data != null)
                        boMon = data;
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
            return boMon;
        }
        public void UpdateBoMon(BoMon boMon)
        {
            if (urlBoMon.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string id = boMon.MaBM;
            urlBoMon = urlBoMon + "/" + id;
            string json = JsonConvert.SerializeObject(boMon);
            try
            {
                HttpResponseMessage response = httpClient.PutAsync(urlBoMon, new StringContent(json, Encoding.UTF8, "application/json")).Result;
                if (!response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception(result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { }
            return;
        }
        public void DeleteBoMon(string id)
        {
            if (urlBoMon.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            urlBoMon = urlBoMon + "/" + id;
            try
            {
                HttpResponseMessage response = httpClient.DeleteAsync(urlBoMon).Result;
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
        #endregion

        #region
        public List<LoaiDiem> ListLoaiDiems()
        {
            List<LoaiDiem> loaiDiems = new List<LoaiDiem>();
            if (urlLoaiDiem.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(urlLoaiDiem).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var datacol = JsonConvert.DeserializeObject<List<LoaiDiem>>(result);
                    if (datacol != null)
                        loaiDiems = datacol;
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
            return loaiDiems;
        }
        public LoaiDiem CreateLoaiDiem(LoaiDiem loaiDiem)
        {
            if (urlLoaiDiem.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string json = JsonConvert.SerializeObject(loaiDiem);
            try
            {
                HttpResponseMessage response = httpClient.PostAsync(urlLoaiDiem, new StringContent(json, Encoding.UTF8, "application/json")).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<LoaiDiem>(result);
                    if (data != null)
                        loaiDiem = data;
                }
                else
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception(result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { }
            return loaiDiem;
        }
        public LoaiDiem GetLoaiDiem(string id)
        {
            LoaiDiem loaiDiem = new LoaiDiem();
            urlLoaiDiem = urlLoaiDiem + "/" + id;
            if (urlLoaiDiem.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(urlLoaiDiem).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<LoaiDiem>(result);
                    if (data != null)
                        loaiDiem = data;
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
            return loaiDiem;
        }
        public void UpdateLoaiDiem(LoaiDiem loaiDiem)
        {
            if (urlLoaiDiem.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string id = loaiDiem.MaLDiem;
            urlLoaiDiem = urlLoaiDiem + "/" + id;
            string json = JsonConvert.SerializeObject(loaiDiem);
            try
            {
                HttpResponseMessage response = httpClient.PutAsync(urlLoaiDiem, new StringContent(json, Encoding.UTF8, "application/json")).Result;
                if (!response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception(result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { }
            return;
        }
        public void DeleteLoaiDiem(string id)
        {
            if (urlLoaiDiem.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            urlLoaiDiem = urlLoaiDiem + "/" + id;
            try
            {
                HttpResponseMessage response = httpClient.DeleteAsync(urlLoaiDiem).Result;
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
        #endregion
    }
}
