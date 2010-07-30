using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace NotMyself.FluentWix.Utils
{
    public static class XmlExtensions
  {
    public static XElement AddElement(this XDocument document, string name)
    {
      var child = new XElement(name);

      document.Add(child);

      return child;
    }
    
    public static XElement AddElement(this XElement element, string name)
    {
        var child = new XElement(name);
        element.Add(child);
        return child;
    }

    public static XmlElement AddElement(this XmlNode element, string name)
    {
      var child = element.OwnerDocument.CreateElement(name);
      element.AppendChild(child);

      return child;
    }

    public static XElement WithAtt(this XElement element, string key, bool value)
    {
      return WithAtt(element, key, value.ToString().ToLowerInvariant());
    }

    public static XElement WithAtt(this XElement element, string key, int value)
    {
      return WithAtt(element, key, value.ToString());
    }

    //public static XmlElement WithAtt(this XmlElement element, string key, TypeReference value)
    //{
    //  return WithAtt(element, key, value.ToString());
    //}

    public static XElement WithAtt(this XElement element, string key, string attValue)
    {
        var attribute = new XAttribute(key, attValue);
        element.Add(attribute);
        return element;
    }

    public static void SetAttributeOnChild(this XmlElement element, string childName, string attName, string attValue)
    {
      XmlElement childElement = element[childName];
      if (childElement == null)
      {
        childElement = element.AddElement(childName);
      }

      childElement.SetAttribute(attName, attValue);
    }

    public static XmlElement WithProperties(this XmlElement element, Dictionary<string, string> properties)
    {
      foreach (var pair in properties)
      {
        element.SetAttribute(pair.Key, pair.Value);
      }

      return element;
    }

    public static void ImportAndAppendChild(this XmlDocument document, XmlDocument toImport)
    {
      var importedNode = document.ImportNode(toImport.DocumentElement, true);

      document.DocumentElement.AppendChild(importedNode);
    }
  }
}