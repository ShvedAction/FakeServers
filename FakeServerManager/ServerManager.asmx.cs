using FakeServers;
using FakeServers.Http;
using FakeServers.ReciverConditionals;
using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace FakeServerManager
{
    /// <summary>
    /// Сводное описание для ServerManager
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class ServerManager : System.Web.Services.WebService
    {
        static Dictionary<long, FakeHttpServer> fakeServers = new Dictionary<long, FakeHttpServer>();
        static Dictionary<long, ConditionalProducer> recivedConditionals = new Dictionary<long, ConditionalProducer>();
        static Dictionary<long, long> reciveConditionalsIdsMatchServerIds = new Dictionary<long, long>();
        static long incrementCounter = -1;

        [WebMethod]
        public long TryUpServer(string ListnedUrl)
        { 
            ++incrementCounter;
            fakeServers[incrementCounter] = new FakeHttpServer(ListnedUrl);
            return incrementCounter;
        }

        [WebMethod]
        public void ShutDownServer(long ServerId)
        {
            try
            {
                fakeServers[ServerId].CheckAllReciverConditional();
            }finally
            {
                fakeServers[ServerId].Dispose();
            }
        }

        /// <summary>
        /// Добавления условия ожидания
        /// </summary>
        /// <param name="ServerId"></param>
        /// <param name="ReciverConditionalType"></param>
        /// <returns></returns>
        [WebMethod]
        public long CreateRecivedConditional(long ServerId, int ReciverConditionalType = 0)
        {
            ++incrementCounter;
            recivedConditionals[incrementCounter] = fakeServers[ServerId].ShouldRecived(RemoteConditionalProducer.CreateReciverConditionalByCode(ReciverConditionalType));
            reciveConditionalsIdsMatchServerIds[incrementCounter] = ServerId;
            return incrementCounter;
        }

        [WebMethod]
        public void TheConditionalShouldBeExpectPostWithRquestBody(long ServerId, long ConditionalId, string ExpectedRequestBody)
        {
            if (reciveConditionalsIdsMatchServerIds[ConditionalId] != ServerId)
                throw new SoapException("ServerId not match the conditionalId", new System.Xml.XmlQualifiedName("BadMatchConditionalId"));
            recivedConditionals[ConditionalId].Post(ExpectedRequestBody);
        }

        [WebMethod]
        public void ForTheConditionalResponseBodyShouldBe(long ServerId, long ConditionalId, string ExpectedResponseBody, string[] responseHeaders = null)
        {
            if (reciveConditionalsIdsMatchServerIds[ConditionalId] != ServerId)
                throw new SoapException("ServerId not match the conditionalId", new System.Xml.XmlQualifiedName("BadMatchConditionalId"));
            recivedConditionals[ConditionalId].Response(ExpectedResponseBody, responseHeaders);
        }

        [WebMethod]
        public string[] GetReciveHistoryForFakeServer(long ServerId)
        {
            if (!fakeServers.ContainsKey(ServerId))
                throw new SoapException("Do not have server with this id: " + ServerId, new System.Xml.XmlQualifiedName("BadMatchConditionalId"));
            return fakeServers[ServerId].GetReciveHistory();
        }
    }
}
