﻿using FakeServers;
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
        [ExpectedException(typeof(AssertFailedException))]
        public void FakeHttpServer_should_verified_recived_request()
        {
            base.any_IFakeServer_should_verified_recived_request();
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

    }
}
