using System.Xml.Linq;

namespace FakeServers.ReciverConditionals
{
    public class XMLReciverConditional : ReciverConditional
    {

        public override bool compareReciveResponse(string expectedBody, string actualBody)
        {
            var expectedXML = XElement.Parse(expectedBody);
            var actualXML = XElement.Parse(actualBody);
            return XNode.DeepEquals(expectedXML, actualXML);
        }
        
    }
}