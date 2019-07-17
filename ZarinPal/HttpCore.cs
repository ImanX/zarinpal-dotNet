using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace ZarinPal
{
    internal class HttpCore
    {
        public string URL { get; set; }
        public Method Method { get; set; }
        public object Raw { get; set; }

        public HttpCore(string URL)
        {
            this.URL = URL;
        }

        public HttpCore()
        {
            //TODO....
        }

        public string Get()
        {

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(URL);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = Method.ToString();

            using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                if (Method == Method.POST)
                {
                    string json = JsonConvert.SerializeObject(Raw);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }

            HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                return result.ToString();
            }
        }
    }
}
