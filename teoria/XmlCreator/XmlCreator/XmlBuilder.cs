using System.Xml.Linq;

namespace XmlCreator;

public class XmlBuilder
{
    private XDocument doc = new XDocument();
    private XElement root;
    private XElement last;
    public XmlBuilder(string rootTag)
    {
        last = root = new XElement(rootTag);
        doc.Add(root);
    }
    public XmlBuilder add(string tagName, IEnumerator<object> en)
    {
        var el = new XElement(tagName);
        
    }

    public XmlBuilder add(string tagName, string content)
    {
        var el = new XElement(tagName,content);
        last.Add(el);
        last = el;
        return this;
    }

    public XmlBuilder add(string tagName, Action pos)
    {
        
    }
}