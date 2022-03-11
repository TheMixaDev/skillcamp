using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AZSModule.controller
{
    /// <summary>
    /// Управление подключением
    /// </summary>
    class NetworkController
    {
        public static string URL = "http://localhost:51150/";
        static WebClient webClient = new WebClient { Encoding = Encoding.UTF8 };

        /// <summary>
        /// GET запрос
        /// </summary>
        /// <param name="url">Страница</param>
        /// <returns>Содержимое</returns>
        public static string GET(string url)
        {
            return webClient.DownloadString(url);
        }

        /// <summary>
        /// POST запрос
        /// </summary>
        /// <param name="url">Страница</param>
        /// <param name="data">Данные</param>
        /// <returns>Содержимое</returns>
        public static string POST(string url, string data)
        {
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            var byteArray = Encoding.UTF8.GetBytes(data);

            var requestStream = request.GetRequestStream();
            requestStream.Write(byteArray, 0, byteArray.Length);

            var response = request.GetResponse();
            var reader = new StreamReader(response.GetResponseStream());
            string result = reader.ReadToEnd();
            return result;
        }
    }
}
