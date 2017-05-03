using System.Net;

namespace FakeServers.ReceiverConditionals
{
    public interface IReceiverConditional
    {
        bool IsSatisfied();
        /// <summary>
        /// Подходит ли это запрос под это условия
        /// если подходит, условия считаются прошедшими
        /// </summary>
        /// <param name="requestContext">контекст запроса</param>
        /// <returns></returns>
        bool CheckResponse(HttpListenerContext requestContext, string alreadyReadBody);
        void SetExceptedRrequest(string body);
        void SetResponse(string body, string[] headers);

        /// <summary>
        /// Ответ, который нужно отдать в случае успешного прохождения условия
        /// ответ вписывается в контекст успешно принятый в методе CheckResponse
        /// </summary>
        void WriteResponseToContext();
    }
}
