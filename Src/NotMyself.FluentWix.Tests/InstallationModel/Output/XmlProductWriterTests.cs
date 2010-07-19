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

    [Test, Ignore("We are locked into the guid type right now and this is not a valid guid.")]
    public void it_should_have_an_auto_assigned_id()
    {
      result.DocumentElement.SelectSingleNode("/Wix/Product").Attributes["Id"].Value.Should().Be.EqualTo("????????-????-????-????-????????????");
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

  [TestFixture]
  public class given_a_uniquely_identified_product_mapping : with_a_xml_product_writer
  {
    private XmlDocument result;

    public override void Context()
    {
      base.Context();

      mapping.Id = Guid.Empty;
    }
    public override void Because()
    {
      result = writer.Write(mapping);
    }

    [Test]
    public void it_should_have_a_product_id()
    {
      result.DocumentElement.SelectSingleNode("/Wix/Product").Attributes["Id"].Value.Should().Be.EqualTo(Guid.Empty.ToString());
    }
  }

  [TestFixture]
  public class given_a_product_mapping_with_a_manufacturer : with_a_xml_product_writer
  {
   private XmlDocument result;

    public override void Context()
    {
      base.Context();

      mapping.Manufacturer = "ACME";
    }
    public override void Because()
    {
      result = writer.Write(mapping);
    }

    [Test]
    public void it_should_have_a_manufacturer()
    {
      result.DocumentElement.SelectSingleNode("/Wix/Product").Attributes["Manufacturer"].Value.Should().Be.EqualTo("ACME");
    }
  }

  [TestFixture]
  public class given_a_product_mapping_with_a_version : with_a_xml_product_writer
  {
    private XmlDocument result;

    public override void Context()
    {
      base.Context();

      mapping.Version = new Version(1,0,0,0);
    }
    public override void Because()
    {
      result = writer.Write(mapping);
    }

    [Test]
    public void it_should_should_have_a_version()
    {
      result.DocumentElement.SelectSingleNode("/Wix/Product").Attributes["Version"].Value.Should().Be.EqualTo("1.0.0.0");
    }
  }

  [TestFixture]
  public class given_a_product_mapping_with_an_upgrade_code : with_a_xml_product_writer
  {
    private XmlDocument result;

    public override void Context()
    {
      base.Context();

      mapping.UpgradeCode = Guid.Empty;
    }
    public override void Because()
    {
      result = writer.Write(mapping);
    }

    [Test]
    public void it_should_should_have_an_upgrade_code()
    {
      result.DocumentElement.SelectSingleNode("/Wix/Product").Attributes["UpgradeCode"].Value.Should().Be.EqualTo(Guid.Empty.ToString());
    }
  }
}