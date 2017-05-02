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
        const string LISTNED_HOST_FAKE_SERVER = "http://localhost:5000/";

        const string REQUST_BODY = "tested value of reuqest body";
        const string RESPONSE_BODY = "tested value of response body";

        [TestMethod]
        [AspNetDevelopmentServer("FakeServerManager", "../../../FakeServerManager/", "/")]
        public void remote_manager_should_able_to_TryUpServer_on_localhost()
        {
            SoapServerManagerWebRef.ServerManager client = new SoapServerManagerWebRef.ServerManager() {
                Url = TestContext.Properties["AspNetDevelopmentServer.FakeServerManager"].ToString()+ "ServerManager.asmx"
            };

            long idServer = client.TryUpServer(LISTNED_HOST_FAKE_SERVER);
            try
            {

                should_listining_the_host(LISTNED_HOST_FAKE_SERVER);
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
            SoapServerManagerWebRef.ServerManager client = new SoapServerManagerWebRef.ServerManager()
            {
                Url = TestContext.Properties["AspNetDevelopmentServer.FakeServerManager"].ToString()+ "ServerManager.asmx"
            };
            long serverId = client.TryUpServer(LISTNED_HOST_FAKE_SERVER);
            try
            {
                long conditionalId = client.CreateRecivedConditional(serverId,0);
                client.TheConditionalShouldBeExpectPostWithRquestBody(serverId, conditionalId, REQUST_BODY);
                client.ForTheConditionalResponseBodyShouldBe(serverId, conditionalId, RESPONSE_BODY, null);

                string actualAnswer = HttpSender.SendPost(LISTNED_HOST_FAKE_SERVER, REQUST_BODY);
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

            long servId = client.TryUpServer(LISTNED_HOST_FAKE_SERVER);
            try
            {
                client.TryUpServer(LISTNED_HOST_FAKE_SERVER);
            }
            finally
            {
                client.ShutDownServer(servId);
            }
        }


        [TestMethod]
        [AspNetDevelopmentServer("FakeServerManager", "../../../FakeServerManager/", "/")]
        [ExpectedException(typeof(SoapException))]
        public void remote_manager_should_throw_soapException_during_call_ShutDownServer_if_some_receiver_conditional_message_is_not_met()
        {
            SoapServerManagerWebRef.ServerManager client = new SoapServerManagerWebRef.ServerManager()
            {
                Url = TestContext.Properties["AspNetDevelopmentServer.FakeServerManager"].ToString() + "ServerManager.asmx"
            };

            long serverId = client.TryUpServer(LISTNED_HOST_FAKE_SERVER);
            try
            {
                long conditionalId = client.CreateRecivedConditional(serverId, 0);
                client.TheConditionalShouldBeExpectPostWithRquestBody(serverId, conditionalId, "example");
            }
            finally
            {
                client.ShutDownServer(serverId);
            }
        }

        [TestMethod]
        [AspNetDevelopmentServer("FakeServerManager", "../../../FakeServerManager/", "/")]
        public void remote_manager_should_able_to_set_return_history_of_all_requests()
        {
            SoapServerManagerWebRef.ServerManager client = new SoapServerManagerWebRef.ServerManager()
            {
                Url = TestContext.Properties["AspNetDevelopmentServer.FakeServerManager"].ToString() + "ServerManager.asmx"
            };

            long serverId = client.TryUpServer(LISTNED_HOST_FAKE_SERVER);
            try
            {
                HttpSender.SendPost(LISTNED_HOST_FAKE_SERVER, REQUST_BODY);
                string[] actualHistoryRequests = client.GetReciveHistoryForFakeServer(serverId);
                Assert.AreEqual(1, actualHistoryRequests.Length, "Wrong count of element for array was returned by method GetReciveHistoryForFakeServer");
                Assert.AreEqual(REQUST_BODY, actualHistoryRequests[0], "Wrong content of element for array was returned by method GetReciveHistoryForFakeServer");
            }
            finally
            {

                client.ShutDownServer(serverId);
            }
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
