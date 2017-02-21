using FakeServers;
using FakeServers.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace FakeHttpServerTests
{
    public abstract class TestsForAnyIFakeServer
    {
        protected virtual string ListenedFakeServerURL { get;}

        //[ExpectedException(typeof(AssertFailedException))]
        protected  void any_IFakeServer_should_verified_recived_request()
        {
            using (IFakeServer fakeserver = BuildTestingServer())
            {
                fakeserver.ShouldRecived();
                fakeserver.CheckAllReciverConditional();
            }
        }

        protected abstract IFakeServer BuildTestingServer();

        protected void any_IFakeServer_should_return_set_response()
        {
            const string RESPONSE_SEMPLE_BODY = "value of fake server response";
            const string REQUEST_SAMPLE_BODY = "value of request";
            using (IFakeServer fakeserver = BuildTestingServer())
            {
                fakeserver.ShouldRecived().Post(REQUEST_SAMPLE_BODY).Response(RESPONSE_SEMPLE_BODY);
                var response = HttpSender.SendPost(ListenedFakeServerURL, REQUEST_SAMPLE_BODY);
                Assert.AreEqual(RESPONSE_SEMPLE_BODY, response);
            }
        }

        protected void any_IFakeServer_should_return_set_response_headers()
        {
            const string RESPONSE_SEMPLE_BODY = "value of fake server response";
            const string REQUEST_SAMPLE_BODY = "value of request";
            const string EXAMPLE_HEADER_KEY = "Content-Type";
            const string EXAMPLE_HEADER_VALUE = "text/xml";
            string[] exampleResponseHeaders = new string[] { EXAMPLE_HEADER_KEY+": "+ EXAMPLE_HEADER_VALUE };
            using (IFakeServer fakeserver = BuildTestingServer())
            {
                fakeserver.ShouldRecived().Post(REQUEST_SAMPLE_BODY).Response(RESPONSE_SEMPLE_BODY, exampleResponseHeaders);
                WebHeaderCollection responseHeaders = null;
                HttpSender.SendPost(ListenedFakeServerURL, REQUEST_SAMPLE_BODY, out responseHeaders);
                Assert.AreEqual(EXAMPLE_HEADER_VALUE, responseHeaders[EXAMPLE_HEADER_KEY], "Wrong value in actual response headers");
            }
        }

        protected void any_IFakeServer_should_stop_without_exception()
        {
            const string RESPONSE_SEMPLE_BODY = "value of fake server response";
            const string REQUEST_SAMPLE_BODY = "value of request";
            IFakeServer fakeserver = BuildTestingServer();
            fakeserver.ShouldRecived().Post(REQUEST_SAMPLE_BODY).Response(RESPONSE_SEMPLE_BODY);
            var response = HttpSender.SendPost(ListenedFakeServerURL, REQUEST_SAMPLE_BODY);
            Assert.AreEqual(RESPONSE_SEMPLE_BODY, response);

            fakeserver.CheckAllReciverConditional();
            fakeserver.stopServer();
        }
    }
}