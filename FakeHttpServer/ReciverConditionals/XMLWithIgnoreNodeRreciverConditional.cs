using FakeServers.ReciverConditionals.XML;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace FakeServers.ReciverConditionals
{
    public class XMLWithIgnoreNodeRreciverConditional: ReciverConditional
    {

        public override bool compareReciveResponse(string expectedBody, string actualBody)
        {
            XElement expectedXML = XElement.Parse(expectedBody);
            XElement actualXML = XElement.Parse(actualBody);
            return GetDifferentForXElement(actualXML, expectedXML);
        }

        public static bool GetDifferentForXElement(XElement nodeOfActualParse, XElement nodeOfExpectParse)
        {
            if (nodeOfActualParse.Name != nodeOfExpectParse.Name)
                return false;
            if (XNode.DeepEquals(nodeOfActualParse, nodeOfExpectParse))
                return true;
            List<DifferentPairXElement> result = new List<DifferentPairXElement>();
            List<XNode> actualChildNodes = new List<XNode>(nodeOfActualParse.Nodes());

            if (actualChildNodes.Count != new List<XNode>(nodeOfExpectParse.Nodes()).Count)
                return false;

            List<XElement> potentialCandidateExpectedElements = new List<XElement>();

            bool noHaveXElement = true;
            foreach (XNode expecteChildNode in nodeOfExpectParse.Nodes())
            {
                if (expecteChildNode.NodeType == System.Xml.XmlNodeType.Element)
                {
                    XElement expectedEl = (XElement)expecteChildNode;
                    int indexOfMatchedExpecedNode = actualChildNodes.FindIndex(actualNode => {
                        return (expectedEl.Value == "#:={Ignore the node}" && !expectedEl.HasElements) || XNode.DeepEquals(actualNode, expecteChildNode);
                        });
                    if (indexOfMatchedExpecedNode == -1)
                        potentialCandidateExpectedElements.Add(expectedEl);
                    else
                        actualChildNodes.RemoveAt(indexOfMatchedExpecedNode); //чтобы ещё раз не попался
                    noHaveXElement = false;
                }
            }
            if (noHaveXElement)
                return false;
            

            foreach(XElement potentialDiffExpectedElement in potentialCandidateExpectedElements)
            {
                int indexOfRecursiveMatch = actualChildNodes.FindIndex(actual => 
                (actual.NodeType == System.Xml.XmlNodeType.Element) && GetDifferentForXElement((XElement)actual, potentialDiffExpectedElement));
                if (indexOfRecursiveMatch == -1)
                    return false;
                else
                    actualChildNodes.RemoveAt(indexOfRecursiveMatch);
            }
            return true;
        }
    }
}
