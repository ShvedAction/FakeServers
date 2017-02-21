using System.IO;
using System.Net;
using System.Text;

namespace FakeServers.ReciverConditionals
{
    public class ReciverConditional : IReciverConditional
    {
        protected string responseBody;
        protected string expectedReciveBody;
        protected bool isRecivedSuccessRequest;
        protected HttpListenerContext successedContext;
        private string[] responseHeaders;

        public virtual bool compareReciveResponse(string expectedBody, string actualBody)
        {
            return expectedBody == actualBody;
        }

        public bool CheckResponse(HttpListenerContext requestContext)
        {
            var reader = new StreamReader(requestContext.Request.InputStream);
            var actualReciveBody = reader.ReadToEnd();
            //выполняется только раз
            if (compareReciveResponse(expectedReciveBody, actualReciveBody) && !isRecivedSuccessRequest)
            {
                //в этом контесте сформируется ответ
                successedContext = requestContext;
                isRecivedSuccessRequest = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// В сулчае если контекст не установлен успешным вызовом CheckResponse(вернул true)
        /// выкенит исключение NullReferenc
        /// </summary>
        /// <returns>Ответ для HTTPServera</returns>
        public void WriteResponseToContext()
        {
            HttpListenerResponse response = successedContext.Response;
            if (responseHeaders != null)
                foreach (string header in responseHeaders)
                    response.Headers.Add(header);
            Stream stream = response.OutputStream;
            byte[] buffer = Encoding.UTF8.GetBytes(responseBody);
            stream.Write(buffer, 0, buffer.Length);
            stream.Close();
        }

        public bool IsSatisfied()
        {
            return isRecivedSuccessRequest;
        }

        public void SetResponse(string body, string[] headers =null)
        {
            responseBody = body;
            responseHeaders = headers;
        }

        public void SetExceptedRrequest(string body)
        {
            expectedReciveBody = body;
        }
    }
}