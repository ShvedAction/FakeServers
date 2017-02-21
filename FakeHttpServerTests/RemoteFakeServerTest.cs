using System;
using FakeServers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakeServers.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace FakeHttpServerTests
{
    [TestClass]
    public class RemoteFakeServerTest : TestsForAnyIFakeServer
    {
        const string LISTENED_FAKE_SERVER_HOST = "http://localhost:4500/";

        protected override string ListenedFakeServerURL { get { return LISTENED_FAKE_SERVER_HOST; } }

        protected string RemotServerManagerHost
        {
            get
            {
                return TestContext.Properties["AspNetDevelopmentServer.FakeServerManager"].ToString() + "ServerManager.asmx";
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

        private IFakeServer SoapRemoteFakeServer;

        protected override IFakeServer BuildTestingServer()
        {
            SoapRemoteFakeServer = SoapHttpRemoteServer.TakeListenHost(ListenedFakeServerURL, RemotServerManagerHost);
            return SoapRemoteFakeServer;
        }

        [TestCleanup]
        public void AfterEachTest()
        {
            SoapRemoteFakeServer.Dispose();
        }

        [TestMethod]
        [AspNetDevelopmentServer("FakeServerManager", "../../../FakeServerManager/", "/")]
        [ExpectedException(typeof(AssertFailedException))]
        public void RemoteFakeServer_should_verified_recived_request()
        {
            base.any_IFakeServer_should_verified_recived_request();
        }

        [TestMethod]
        [AspNetDevelopmentServer("FakeServerManager", "../../../FakeServerManager/", "/")]
        public void RemoteFakeServer_should_return_set_response()
        {
            base.any_IFakeServer_should_return_set_response();
        }

        [TestMethod]
        [AspNetDevelopmentServer("FakeServerManager", "../../../FakeServerManager/", "/")]
        public void RemoteFakeServer_should_stop_without_exception()
        {
            base.any_IFakeServer_should_stop_without_exception();
        }

        [TestMethod]
        [AspNetDevelopmentServer("FakeServerManager", "../../../FakeServerManager/", "/")]
        public void RemoteFakeServer_should_return_set_response_headers()
        {
            base.any_IFakeServer_should_return_set_response_headers();
        }
    }
}
