using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakeServers;
using FakeServers.Http;
using FakeServers.ReciverConditionals;

namespace FakeHttpServerTests.ReciverConditionalsTests
{
    /// <summary>
    /// Сводное описание для XMLReciverConditionalTests
    /// </summary>
    [TestClass]
    public class XMLReciverConditionalTest
    {

        private IFakeServer fakeserver;
        private const string SUCCESS_RESPONSE = "Ok";
        private const string LISTNED_HOST = "http://localhost:3030/";

        [TestCleanup]
        public void ShoutDownServer()
        {
            fakeserver.StopServer();
        }

        [TestMethod]
        public void FakeServer_should_able_to_compare_XML_body_with_different_representation()
        {
            const string EXPECTED_XML = "<?xml version=\"1.0\" encoding=\"utf - 8\"?><some-tag>value of some tag</some-tag>";
            const string ACTUAL_XML = "<?xml version=\"1.0\" encoding=\"utf - 8\"?>\n" +
                "                           <!-- some comment -->\n" +
                "                           <some-tag>value of some tag</some-tag>";

            fakeserver = new FakeHttpServer(LISTNED_HOST);

            fakeserver.ShouldRecived(new XMLReciverConditional()).Post(EXPECTED_XML).Response(SUCCESS_RESPONSE);

            string actualResponse = HttpSender.SendPost(LISTNED_HOST, ACTUAL_XML);

            Assert.AreEqual(SUCCESS_RESPONSE, actualResponse, "Wrong response");
            fakeserver.CheckAllReciverConditional();
        }

        [TestMethod]
        public void FakeServer_should_able_to_compare_XML_body_with_ignore_some_node()
        {
            const string EXPECTED_XML = "<?xml version=\"1.0\" encoding=\"utf - 8\"?>\n" +
                "                       <root>\n" +
                "                           <some-tag>value of some tag</some-tag>\n" +
                "                           <ignored-node>#:={Ignore the node}</ignored-node>" +
                "                       </root>";
            const string ACTUAL_XML = "<?xml version=\"1.0\" encoding=\"utf - 8\"?>\n" +
                "                       <root>\n"+
                "                           <ignored-node>some value</ignored-node>\n"+
                "                           <some-tag>value of some tag</some-tag>\n"+
                "                       </root>";

            fakeserver = new FakeHttpServer(LISTNED_HOST);

            //For this fiture should use XMLWithIgnoreNodeRreceiverConditional
            fakeserver.ShouldRecived(new XMLWithIgnoreNodeRreceiverConditional()).Post(EXPECTED_XML).Response(SUCCESS_RESPONSE);

            string actualResponse = HttpSender.SendPost(LISTNED_HOST, ACTUAL_XML);

            Assert.AreEqual(SUCCESS_RESPONSE, actualResponse, "Wrong response");
            fakeserver.CheckAllReciverConditional();
        }
    }
}
