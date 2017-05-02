using FakeServers.Http;
using System.IO;
using System.Net;
using System.Text;

namespace FakeServers.ReceiverConditionals
{
    public class ReceiverConditional : IReceiverConditional
    {
        protected string responseBody;
        protected string expectedReceiveBody;
        protected bool isReceivedSuccessRequest;
        protected HttpListenerContext successedContext;
        private string[] responseHeaders;

        public virtual bool compareReceiveResponse(string expectedBody, string actualBody)
        {
            return expectedBody == actualBody;
        }

        public bool CheckResponse(HttpListenerContext requestContext, string actualReceiveBody)
        {
            //выполняется только раз
            if (compareReceiveResponse(expectedReceiveBody, actualReceiveBody) && !isReceivedSuccessRequest)
            {
                //в этом контесте сформируется ответ
                successedContext = requestContext;
                isReceivedSuccessRequest = true;
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
            HttpSender.WriteResponse(successedContext.Response,  responseBody, responseHeaders);
        }

        public bool IsSatisfied()
        {
            return isReceivedSuccessRequest;
        }

        public void SetResponse(string body, string[] headers =null)
        {
            responseBody = body;
            responseHeaders = headers;
        }

        public void SetExceptedRrequest(string body)
        {
            expectedReceiveBody = body;
        }
    }
}
