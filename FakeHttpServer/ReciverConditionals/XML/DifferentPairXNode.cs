using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace FakeServers.ReciverConditionals.XML
{
    public class DifferentPairXElement
    {
        public DifferentPairXElement(XElement expectedXElement, XElement actualXElement)
        {
            ExpectedXElement = expectedXElement;
            ActualXElement = actualXElement;
        }

        public XElement ActualXElement { get; private set; }
        public XElement ExpectedXElement { get; private set; }
    }
}
