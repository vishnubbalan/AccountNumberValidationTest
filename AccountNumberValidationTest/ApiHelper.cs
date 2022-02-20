using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace AccountNumberValidationTest
{
    public class ApiHelper
    {
        public ApiResponce CreateRequest(string bankAccNumber, string URL, string AuthKey)
        {
            ApiRequest requestData = new ApiRequest();
            requestData.bankAccount = bankAccNumber;
            string Data = JsonConvert.SerializeObject(requestData);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers.Add("X-Auth-Key", AuthKey);
            ApiResponce responceObj = new ApiResponce();
            using (Stream webStream = request.GetRequestStream())
            using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
            {
                requestWriter.Write(Data);
            }

            try
            {
                HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
                using (StreamReader responseReader = new StreamReader(webStream))
                {
                    string response = responseReader.ReadToEnd();
                    responceObj = (ApiResponce)JsonConvert.DeserializeObject(response, typeof(ApiResponce));
                    Console.Out.WriteLine(response);
                    HttpStatusCode statusCode = webResponse.StatusCode;
                    Console.WriteLine("Response Code: " + (int)statusCode + " - " + statusCode.ToString());
                }
            }
            catch (WebException e)
            {
                HttpWebResponse webResponse = (HttpWebResponse)e.Response;
                HttpStatusCode statusCode = webResponse.StatusCode;
                Stream dataStream = webResponse.GetResponseStream();
                StreamReader responseReader = new StreamReader(dataStream);
                string response = responseReader.ReadToEnd();
                responceObj = null;
                Console.WriteLine(response);
                Console.WriteLine("Response Code: " + (int)statusCode + " - " + statusCode.ToString());
            }
            return responceObj;
        }
    }

}
