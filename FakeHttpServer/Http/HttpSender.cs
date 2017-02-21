using System;
using System.IO;
using System.Net;
using System.Text;

namespace FakeServers.Http
{
    public class HttpSender
    {
        string url;
        string template_name;
        public HttpSender(string url, string templateName)
        {
            this.url = url;
            template_name = templateName;
        }

        public static string SendPost(string url, string body, string[] requestHeaders = null)
        {
            WebHeaderCollection responseHeaders = null;
            return SendPost(url, body, out responseHeaders, requestHeaders);
        }

        public static string SendPost(string url, string body, out WebHeaderCollection responseHeaders, string[] headers = null)
        {
            // Create a request using a URL that can receive a post. 
            WebRequest request = WebRequest.Create(url);
            // Set the Method property of the request to POST.
            request.Method = "POST";
            // Create POST data and convert it to a byte array.
            string postData = body;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "text/xml; charset=utf-8";
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header);
                }
            }
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            try
            {
                WebResponse response = request.GetResponse();

                responseHeaders = response.Headers;
                // Get the stream containing content returned by the server.
                dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Clean up the streams.
                reader.Close();
                dataStream.Close();
                response.Close();
                return responseFromServer;
            }catch(WebException e)
            {
                var response = new StreamReader(e.Response.GetResponseStream()).ReadToEnd();
                throw new Exception(response);
            }
        }
    }
}
