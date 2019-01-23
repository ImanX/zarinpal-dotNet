using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace ZarinPal
{
    class HttpCore
    {
        public String URL { get; set; }
        public Method Method { get; set; }
        public Object Raw { get; set; }
       

        public HttpCore(String URL){
            this.URL = URL;
        }

        public HttpCore()
        {
            //TODO....
        }


        public String Get()
        {
           
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(this.URL);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = Method.ToString();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
              if(this.Method == Method.POST){
              string json = new JavaScriptSerializer().Serialize(Raw);
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
              }
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                return result.ToString();
            }

        }
        }



        public enum Method
        {
            GET,
            POST
        }

}
