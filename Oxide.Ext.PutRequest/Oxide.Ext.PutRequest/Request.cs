using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Oxide.Ext.PutRequest
{
    class Request
    {
        public string Url;
        public Dictionary<string, string> Headers;
        public Dictionary<string, object> Data;

        public string RunRequest()
        {
            var webRequest = WebRequest.Create(Url);
            webRequest.Method = "PUT";
            webRequest.Timeout = 20000;
            webRequest.ContentType = "application/json";

            foreach (var kvp in Headers)
                webRequest.Headers.Add(kvp.Key + ": " + kvp.Value.ToString());

            var data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(Data));
            webRequest.ContentLength = data.Length;

            using (var stream = webRequest.GetRequestStream())
                stream.Write(data, 0, data.Length);

            string output = "";
            WebResponse response = webRequest.GetResponse();
            Stream recieveStream = response.GetResponseStream();
            using (var sr = new StreamReader(recieveStream, Encoding.UTF8))
            {
                Char[] read = new Char[256];
                int count = sr.Read(read, 0, 256);
                while (count > 0)
                {
                    String str = new String(read, 0, count);
                    output += str;
                    count = sr.Read(read, 0, 256);
                }
            }

            return output;
        }
    }
}
