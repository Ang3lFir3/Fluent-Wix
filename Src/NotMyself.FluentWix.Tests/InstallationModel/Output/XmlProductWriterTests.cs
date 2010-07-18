using System;
using System.Xml;
using NotMyself.FluentWix.InstallationModel.Output;
using NotMyself.FluentWix.MappingModel.ProductBased;
using NotMyself.FluentWix.Tests.Infrastructure;
using NUnit.Framework;

namespace NotMyself.FluentWix.Tests.InstallationModel.Output
{
  public abstract class with_a_xml_product_writer : Specification
  {
    protected XmlProductWriter writer;
    protected ProductMapping mapping;

    public override void Context()
    {
      mapping = new ProductMapping();
      writer = new XmlProductWriter();
    }
  }

  [TestFixture]
  public class given_an_empty_product_mapping : with_a_xml_product_writer
  {
    private XmlDocument result;

    public override void Because()
    {
      result = writer.Write(mapping);
    }

    [Test]
    public void it_should_create_an_xml_document()
    {
      result.Should().Not.Be.Null();
    }

    [Test]
    public void it_should_have_a_root_node_of_wix()
    {
      result.FirstChild.Name.Should().Be.EqualTo("Wix");
    }

    [Test]
    public void it_should_have_the_default_wix_namespace()
    {
      result.DocumentElement.GetAttribute("xmlns").Should().Be.EqualTo("http://schemas.microsoft.com/wix/2003/01/wi");
    }

    [Test]
    public void it_should_have_a_single_product_node()
    {
      result.GetElementsByTagName("Product").Count.Should().Be.EqualTo(1);
    }
  }

  [TestFixture]
  public class given_a_named_product_mapping: with_a_xml_product_writer
  {
    private XmlDocument result;

    public override void Context()
    {
      base.Context();
      mapping.Name = "foo";
    }

    public override void Because()
    {
      result = writer.Write(mapping);
    }

    [Test]
    public void it_should_have_a_product_named_foo()
    {
      result.DocumentElement.SelectSingleNode("/Wix/Product").Attributes["Name"].Value.Should().Be.EqualTo("foo");
    }
  }
}