using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakeServers.ReciverConditionals;
using System.Xml.Linq;
using FakeServers.ReciverConditionals.XML;

namespace FakeHttpServerTests.ReciverConditionalsTests
{
    [TestClass]
    public class XMLWithIgnoreNodeRreceiverConditionalTest
    {
        [TestMethod]
        public void method_compareReciveResponse_of_XMLWithIgnoreNodeRreceiverConditional_should_return_true_for_all_node_match_except_node_with_special_ignored_value()
        {
            string exampleOfActual = "<?xml version=\"1.0\" encoding=\"utf - 8\"?><soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><soap:Body><activateSubscription xmlns=\"http://mts.ru/\"><qwertf>safda</qwertf><subscriberid>1234465</subscriberid><serviceid>100131</serviceid><date>2016-12-17T22:17:34.0100000+03:00</date><requestid>14820022536198913146</requestid></activateSubscription></soap:Body></soap:Envelope>";
            string exampleOfExcepted = "<?xml version =\"1.0\" encoding=\"utf - 8\"?><soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><soap:Body><activateSubscription xmlns=\"http://mts.ru/\"><qwertf>safda</qwertf><subscriberid>1234465</subscriberid><serviceid>100131</serviceid><date>#:={Ignore the node}</date><requestid>14820022536198913146</requestid></activateSubscription></soap:Body></soap:Envelope>";

            XMLWithIgnoreNodeRreceiverConditional comparator = new XMLWithIgnoreNodeRreceiverConditional();
            Assert.IsTrue(comparator.compareReciveResponse(exampleOfExcepted, exampleOfActual), "Node with content:\"#:={Ignore the node}\" should ignored. See matched values in test.");
        }

        [TestMethod]
        public void method_compareReciveResponse_of_XMLWithIgnoreNodeRreceiverConditional_should_return_false_for_not_match_node_in_not_node_with_special_ignored_value()
        {
            string exampleOfActual = "<?xml version=\"1.0\" encoding=\"utf - 8\"?><soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><soap:Body><activateSubscription xmlns=\"http://mts.ru/\"><qwertf>wrong value</qwertf><subscriberid>1234465</subscriberid><serviceid>100131</serviceid><date>2016-12-17T22:17:34.0100000+03:00</date><requestid>14820022536198913146</requestid></activateSubscription></soap:Body></soap:Envelope>";
            string exampleOfExcepted = "<?xml version =\"1.0\" encoding=\"utf - 8\"?><soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><soap:Body><activateSubscription xmlns=\"http://mts.ru/\"><qwertf>safda</qwertf><subscriberid>1234465</subscriberid><serviceid>100131</serviceid><date>#:={Ignore the node}</date><requestid>14820022536198913146</requestid></activateSubscription></soap:Body></soap:Envelope>";

            XMLWithIgnoreNodeRreceiverConditional comparator = new XMLWithIgnoreNodeRreceiverConditional();
            Assert.IsFalse(comparator.compareReciveResponse(exampleOfExcepted, exampleOfActual), "Node with content:\"#:={Ignore the node}\" should ignored. See matched values in test.");
        }

        [TestMethod]
        public void method_compareReciveResponse_of_XMLWithIgnoreNodeRreceiverConditional_should_return_false_for_all_node_match_except_node_with_wrong_special_ignored_value()
        {
            string exampleOfActual = "<?xml version=\"1.0\" encoding=\"utf - 8\"?><soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><soap:Body><activateSubscription xmlns=\"http://mts.ru/\"><qwertf>safda</qwertf><subscriberid>1234465</subscriberid><serviceid>100131</serviceid><date>2016-12-17T22:17:34.0100000+03:00</date><requestid>14820022536198913146</requestid></activateSubscription></soap:Body></soap:Envelope>";
            string exampleOfExcepted = "<?xml version =\"1.0\" encoding=\"utf - 8\"?><soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><soap:Body><activateSubscription xmlns=\"http://mts.ru/\"><qwertf>safda</qwertf><subscriberid>1234465</subscriberid><serviceid>100131</serviceid><date>#:={Wrong Ignore value}</date><requestid>14820022536198913146</requestid></activateSubscription></soap:Body></soap:Envelope>";

            XMLWithIgnoreNodeRreceiverConditional comparator = new XMLWithIgnoreNodeRreceiverConditional();
            Assert.IsFalse(comparator.compareReciveResponse(exampleOfExcepted, exampleOfActual), "Node with content:\"#:={Ignore the node}\" should ignored. See matched values in test.");
        }

        [TestMethod]
        public void method_compareReciveResponse_of_XMLWithIgnoreNodeRreceiverConditional_should_return_false_for_concret_this_example()
        {
            string exampleOfActual = "<?xml version=\"1.0\" encoding=\"utf - 8\"?><soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:soapenc=\"http://schemas.xmlsoap.org/soap/encoding/\" xmlns:tns=\"http://45.13.52.142:8088/Ginllib\" xmlns:types=\"http://45.13.52.142:8088/Ginllib/encodedTypes\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><soap:Body soap:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\"><tns:masdfRfdsBsds><user xsi:type=\"xsd:string\">aasdfa</user><domain xsi:type=\"xsd:string\">aasdfa</domain><site xsi:type=\"xsd:string\">aasdfa</site><pass xsi:type=\"xsd:string\">aasdfa</pass></tns:masdfRfdsBsds></soap:Body></soap:Envelope>";
            string exampleOfExcepted = "<?xml version=\"1.0\" encoding=\"utf - 8\"?><soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:soapenc=\"http://schemas.xmlsoap.org/soap/encoding/\" xmlns:tns=\"http://45.13.52.142:8088/Ginllib\" xmlns:types=\"http://45.13.52.142:8088/Ginllib/encodedTypes\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><soap:Body soap:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\"><tns:sdfsErtdXcvb><Site xsi:type=\"xsd:string\">#:={Ignore the node}</Site></tns:sdfsErtdXcvb></soap:Body></soap:Envelope>";

            XMLWithIgnoreNodeRreceiverConditional comparator = new XMLWithIgnoreNodeRreceiverConditional();
            Assert.IsFalse(comparator.compareReciveResponse(exampleOfExcepted, exampleOfActual), "Node with content:\"#:={Ignore the node}\" should ignored. See matched values in test.");
        }

        [TestMethod]
        public void method_compareReciveResponse_of_XMLWithIgnoreNodeRreceiverConditional_should_return_true_for_concret_this_example()
        {
            string exampleOfActual = "<?xml version=\"1.0\" encoding=\"utf-8\"?><soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:soapenc=\"http://schemas.xmlsoap.org/soap/encoding/\" xmlns:tns=\"http://44.33.55.21:8880/Grdfsg\" xmlns:types=\"http://44.33.55.21:8880/Grdfsg/encodedTypes\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><soap:Body soap:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\"><tns:dfaRdsfVsdfs><Site xsi:type=\"xsd:string\">sdsdfsdf_qq</Site></tns:dfaRdsfVsdfs></soap:Body></soap:Envelope>";
            string exampleOfExcepted = "<?xml version=\"1.0\" encoding=\"utf-8\"?><soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:soapenc=\"http://schemas.xmlsoap.org/soap/encoding/\" xmlns:tns=\"http://44.33.55.21:8880/Grdfsg\" xmlns:types=\"http://44.33.55.21:8880/Grdfsg/encodedTypes\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><soap:Body soap:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\"><tns:dfaRdsfVsdfs><Site xsi:type=\"xsd:string\">#:={Ignore the node}</Site></tns:dfaRdsfVsdfs></soap:Body></soap:Envelope>";

            XMLWithIgnoreNodeRreceiverConditional comparator = new XMLWithIgnoreNodeRreceiverConditional();
            Assert.IsTrue(comparator.compareReciveResponse(exampleOfExcepted, exampleOfActual), "Node with content:\"#:={Ignore the node}\" should ignored. See matched values in test.");
        }
        [TestMethod]
        public void method_compareReciveResponse_of_XMLWithIgnoreNodeRreceiverConditional_should_return_false_for_concret_this_example2()
        {
            string exampleOfActual = "<?xml version=\"1.0\" encoding=\"utf-8\"?><soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:soapenc=\"http://schemas.xmlsoap.org/soap/encoding/\" xmlns:tns=\"http://44.33.55.21:8880/Grdfsg\" xmlns:types=\"http://44.33.55.21:8880/Grdfsg/encodedTypes\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><soap:Body soap:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\"><tns:dfaRdsfVsdfs><Site xsi:type=\"xsd:string\">sdsdfsdf_qq</Site></tns:dfaRdsfVsdfs></soap:Body></soap:Envelope>";
            string exampleOfExcepted = "<?xml version=\"1.0\" encoding=\"utf-8\"?><soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:soapenc=\"http://schemas.xmlsoap.org/soap/encoding/\" xmlns:tns=\"http://44.33.55.21:8880/Grdfsg\" xmlns:types=\"http://44.33.55.21:8880/Grdfsg/encodedTypes\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><soap:Body soap:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\"><tns:qewWedVcx><Site xsi:type=\"xsd:string\">#:={Ignore the node}</Site></tns:qewWedVcx></soap:Body></soap:Envelope>";

            XMLWithIgnoreNodeRreceiverConditional comparator = new XMLWithIgnoreNodeRreceiverConditional();
            Assert.IsFalse(comparator.compareReciveResponse(exampleOfExcepted, exampleOfActual), "Node with content:\"#:={Ignore the node}\" should ignored. See matched values in test.");
        }
    }
}
