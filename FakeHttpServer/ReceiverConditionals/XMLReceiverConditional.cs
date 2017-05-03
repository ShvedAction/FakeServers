using System.Xml.Linq;

namespace FakeServers.ReceiverConditionals
{
    public class XMLReceiverConditional : ReceiverConditional
    {

        public override bool compareReceiveResponse(string expectedBody, string actualBody)
        {
            var expectedXML = XElement.Parse(expectedBody);
            var actualXML = XElement.Parse(actualBody);
            return XNode.DeepEquals(expectedXML, actualXML);
        }
        
    }
}
