using FakeServers.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System;
using System.Net;
using System.Web.Services.Protocols;

namespace FakeHttpServerTests
{
    /// <summary>
    /// Сводное описание для SoapWebAPIServerManagerTest
    /// </summary>
    [TestClass]
    public class SoapWebAPIServerManagerTest
    {
        //const string HOST_FAKE_SERVER = "http://localhost:5000/";   
        const string HOST_FAKE_SERVER = "http://localhost:5000/";
        const string LISTNED_HOST_FAKE_SERVER = "http://localhost:5000/";

        [TestMethod]
        [AspNetDevelopmentServer("FakeServerManager", "../../../FakeServerManager/", "/")]
        public void remote_manager_should_able_to_TryUpServer_on_localhost()
        {
            const string HOST_FAKE_SERVER_LOCALHOST = "http://localhost:5000/";
            SoapServerManagerWebRef.ServerManager client = new SoapServerManagerWebRef.ServerManager();

            long idServer = client.TryUpServer(LISTNED_HOST_FAKE_SERVER);
            try
            {

                should_listining_the_host(HOST_FAKE_SERVER_LOCALHOST);
            }
            finally
            {
                client.ShutDownServer(idServer);
            }
        }

        private TestContext testContextInstance;
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        [AspNetDevelopmentServer("FakeServerManager", "../../../FakeServerManager/","/")]
        public void remote_manager_should_able_to_set_rquest_and_response_for_concret_request()
        {
            const string REQUST_BODY = "tested value of reuqest body";
            const string RESPONSE_BODY = "tested value of response body";
            SoapServerManagerWebRef.ServerManager client = new SoapServerManagerWebRef.ServerManager()
            {
                Url = TestContext.Properties["AspNetDevelopmentServer.FakeServerManager"].ToString()+ "ServerManager.asmx"
            };
            long serverId = client.TryUpServer(LISTNED_HOST_FAKE_SERVER);
            try
            {
                long conditionalId = client.CreateRecivedConditional(serverId);
                client.TheConditionalShouldBeExpectPostWithRquestBody(serverId, conditionalId, REQUST_BODY);
                client.ForTheConditionalResponseBodyShouldBe(serverId, conditionalId, RESPONSE_BODY, null);

                string actualAnswer = HttpSender.SendPost(HOST_FAKE_SERVER, REQUST_BODY);
                Assert.AreEqual(RESPONSE_BODY, actualAnswer, "Remote fake server shoul answer response like was set by method ForTheConditionalResponseBodyShouldBe");
            }
            finally
            {
                client.ShutDownServer(serverId);
            }
        }


        [TestMethod]
        [AspNetDevelopmentServer("FakeServerManager", "../../../FakeServerManager/", "/")]
        [ExpectedException(typeof(SoapException))]
        public void remote_manager_should_throw_exception_for_call_TryUpServer_with_allready_busy_port()
        {
            SoapServerManagerWebRef.ServerManager client = new SoapServerManagerWebRef.ServerManager()
            {
                Url = TestContext.Properties["AspNetDevelopmentServer.FakeServerManager"].ToString() + "ServerManager.asmx"
            };

            client.TryUpServer(LISTNED_HOST_FAKE_SERVER);

            client.TryUpServer(LISTNED_HOST_FAKE_SERVER);
        }


        [TestMethod]
        [AspNetDevelopmentServer("FakeServerManager", "../../../FakeServerManager/", "/")]
        [ExpectedException(typeof(SoapException))]
        public void remote_manager_should_throw_soapException_during_call_ShutDownServer_if_some_reciver_conditional_message_is_not_met()
        {
            SoapServerManagerWebRef.ServerManager client = new SoapServerManagerWebRef.ServerManager()
            {
                Url = TestContext.Properties["AspNetDevelopmentServer.FakeServerManager"].ToString() + "ServerManager.asmx"
            };

            long serverId = client.TryUpServer(LISTNED_HOST_FAKE_SERVER);
            long conditionalId = client.CreateRecivedConditional(serverId);
            client.TheConditionalShouldBeExpectPostWithRquestBody( serverId, conditionalId, "example");
            client.ShutDownServer(serverId);
        }

        private void should_listining_the_host(string host)
        {
            WebRequest req = WebRequest.Create(host);
            try
            {
                req.GetResponse();
            }
            catch(WebException e)
            {
                Assert.AreEqual(WebExceptionStatus.ProtocolError, e.Status, e.Message);
            }
        }
    }
}
