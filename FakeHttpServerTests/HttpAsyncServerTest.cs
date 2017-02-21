using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakeHttpServFakeServers.Httper;

namespace FakeHttpServerTests
{
    [TestClass]
    public class HttpAsyncServerTest
    {

        [TestMethod]
        public void HttpAsyncServer_should_able_to_run_and_to_stop()
        {
            HttpAsyncServer server = new HttpAsyncServer(new string[] { "http://localhost:3030/" }, context => { });
            server.RunServer();
            server.stop();
        }

    }
}
