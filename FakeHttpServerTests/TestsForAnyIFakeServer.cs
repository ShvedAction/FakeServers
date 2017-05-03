using FakeServers;
using FakeServers.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;

namespace FakeHttpServerTests
{
    public abstract class TestsForAnyIFakeServer
    {

        const string RESPONSE_SEMPLE_BODY = "value of fake server response";
        const string REQUEST_SAMPLE_BODY = "value of request";
        protected virtual string ListenedFakeServerURL { get;}

        //[ExpectedException(typeof(AssertFailedException))]
        protected  void any_IFakeServer_should_verified_received_request()
        {
            using (IFakeServer fakeserver = BuildTestingServer())
            {
                fakeserver.ShouldReceived();
                fakeserver.CheckAllReceiverConditional();
            }
        }

        protected abstract IFakeServer BuildTestingServer();

        protected void any_IFakeServer_should_return_set_response()
        {
            using (IFakeServer fakeserver = BuildTestingServer())
            {
                fakeserver.ShouldReceived().Post(REQUEST_SAMPLE_BODY).Response(RESPONSE_SEMPLE_BODY);
                var response = HttpSender.SendPost(ListenedFakeServerURL, REQUEST_SAMPLE_BODY);
                Assert.AreEqual(RESPONSE_SEMPLE_BODY, response);
            }
        }

        protected void any_IFakeServer_should_return_set_response_headers()
        {
            const string EXAMPLE_HEADER_KEY = "Content-Type";
            const string EXAMPLE_HEADER_VALUE = "text/xml";
            string[] exampleResponseHeaders = new string[] { EXAMPLE_HEADER_KEY+": "+ EXAMPLE_HEADER_VALUE };
            using (IFakeServer fakeserver = BuildTestingServer())
            {
                fakeserver.ShouldReceived().Post(REQUEST_SAMPLE_BODY).Response(RESPONSE_SEMPLE_BODY, exampleResponseHeaders);
                WebHeaderCollection responseHeaders = null;
                HttpSender.SendPost(ListenedFakeServerURL, REQUEST_SAMPLE_BODY, out responseHeaders);
                Assert.AreEqual(EXAMPLE_HEADER_VALUE, responseHeaders[EXAMPLE_HEADER_KEY], "Wrong value in actual response headers");
            }
        }

        protected void any_IFakeServer_should_stop_without_exception()
        {
            IFakeServer fakeserver = BuildTestingServer();
            fakeserver.ShouldReceived().Post(REQUEST_SAMPLE_BODY).Response(RESPONSE_SEMPLE_BODY);
            var response = HttpSender.SendPost(ListenedFakeServerURL, REQUEST_SAMPLE_BODY);
            Assert.AreEqual(RESPONSE_SEMPLE_BODY, response);

            fakeserver.CheckAllReceiverConditional();
            fakeserver.StopServer();
        }

        protected void any_IFakeServer_should_able_to_get_history_of_ricivers_messages()
        {
            IFakeServer fakeserver = BuildTestingServer();
            fakeserver.ShouldReceived();
            HttpSender.SendPost(ListenedFakeServerURL, REQUEST_SAMPLE_BODY);
            string[] actualReceiveMessages = fakeserver.GetReceiveHistory();
            Assert.AreEqual(1, actualReceiveMessages.Length, "Wrong count of element for array was returned by method GetReceiveHistory");
            Assert.AreEqual(REQUEST_SAMPLE_BODY, actualReceiveMessages[0], "Wrong content of element for array was returned by method GetReceiveHistory");
            try
            {
                fakeserver.StopServer();
            }
            catch (Exception)
            {
                //Сервер должен сказать что не все запросы пришли. Но в данном тесте это не проверяется.
            }
        }

        protected void any_IFakeServer_should_return_deffault_message_for_no_mathced_requests()
        {
            IFakeServer fakeserver = BuildTestingServer();
            fakeserver.ShouldReceived();
            string actualDeffaultMessage = HttpSender.SendPost(ListenedFakeServerURL, REQUEST_SAMPLE_BODY);
            Assert.AreEqual(AFakeServer.DEFAULT_RESPONSE_BODY, actualDeffaultMessage, "Wrong DeffaultMessage");
            try
            {
                fakeserver.StopServer();
            }
            catch (Exception)
            {
                //Сервер должен сказать что не все запросы пришли. Но в данном тесте это не проверяется.
            }
        }
    }
}
