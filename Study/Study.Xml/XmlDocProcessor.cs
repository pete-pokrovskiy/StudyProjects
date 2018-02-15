using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Study.Xml
{
    public class XmlDocProcessor
    {
        public XmlDocument CreateXmlDocumentWithDeclaration()
        {
            
            XmlDocument xdoc = new XmlDocument();


            XmlDeclaration declaration = xdoc.CreateXmlDeclaration("1.0", "UTF-16", null);

            var rootElement = xdoc.CreateElement("root");

            rootElement.AppendChild(xdoc.CreateElement("FirstChild"));
            rootElement.AppendChild(xdoc.CreateElement("SecondChild"));
            rootElement.AppendChild(xdoc.CreateElement("ThirdChild"));


            xdoc.AppendChild(rootElement);

            XmlElement root = xdoc.DocumentElement;

            xdoc.InsertBefore(declaration, root);


            return xdoc;

        }

    }
}
