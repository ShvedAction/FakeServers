using FakeServers;
using FakeServers.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FakeHttpServerTests
{
    [TestClass]
    public class FakeHttpServerTest : TestsForAnyIFakeServer
    {
        const string FAKE_SERVER_URL = "http://localhost:3000/";

        protected override string ListenedFakeServerURL { get { return FAKE_SERVER_URL; } }


        protected override IFakeServer BuildTestingServer()
        {
            return new FakeHttpServer(ListenedFakeServerURL);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void FakeHttpServer_should_verified_received_request()
        {
            base.any_IFakeServer_should_verified_received_request();
        }

        [TestMethod]
        public void FakeHttpServer_should_return_set_response()
        {
            base.any_IFakeServer_should_return_set_response();
        }

        [TestMethod]
        public void FakeHttpServer_should_stop_without_exception()
        {
            base.any_IFakeServer_should_stop_without_exception();
        }

        [TestMethod]
        public void FakeHttpServer_should_return_set_response_headers()
        {
            base.any_IFakeServer_should_return_set_response_headers();
        }

        [TestMethod]
        public void FakeHttpServer_should_able_to_get_history_of_ricivers_messages()
        {
            base.any_IFakeServer_should_able_to_get_history_of_ricivers_messages();
        }
        
        [TestMethod]
        public void FakeHttpServer_should_return_deffault_message_for_no_mathced_requests()
        {
            base.any_IFakeServer_should_return_deffault_message_for_no_mathced_requests();
        }

    }
}
