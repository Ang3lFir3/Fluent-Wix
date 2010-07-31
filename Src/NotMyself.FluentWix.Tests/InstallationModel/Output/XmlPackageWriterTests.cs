using System;
using System.Xml.Linq;
using NotMyself.FluentWix.InstallationModel.Output;
using NotMyself.FluentWix.MappingModel.ProductBased;
using NotMyself.FluentWix.Tests.Infrastructure;
using NotMyself.FluentWix.Utils;
using NotMyself.FluentWix.Visitors;
using NUnit.Framework;

namespace NotMyself.FluentWix.Tests.InstallationModel.Output
{
    public abstract class with_a_xml_package_writer : Specification
    {
        protected IXmlWriter<PackageMapping> writer;
        protected PackageMapping mapping;

        public override void Context()
        {
            writer = new XmlPackageWriter();
            mapping = new PackageMapping();
        }
    }

    [TestFixture]
    public class given_an_empty_package_mapping : with_a_xml_package_writer
    {
        XContainer result;

        public override void Because()
        {
            result = writer.Write(mapping);
        }

        [Test]
        public void it_should_create_an_XElement()
        {
            result.GetType().Should().Be.EqualTo(typeof (XElement));
        }

        [Test]
        public void it_should_have_the_name_package()
        {
            (result as XElement).Name.LocalName.Should().Be.EqualTo("Package");
        }

        [Test]
        public void it_should_have_an_Id_attribute()
        {
            (result as XElement).Attribute("Id").Should().Not.Be.Null();
        }

        [Test]
        public void it_should_set_the_id_value_to_star_by_default()
        {
            (result as XElement).Attribute("Id").Value.Should().Be.EqualTo("*");
        }
    }

    [TestFixture]
    public class given_a_package_mapping_with_an_Id : with_a_xml_package_writer
    {
        XContainer result;
        protected string the_id = "abc123";

        public override void Because()
        {
            mapping.Id = the_id;
            result = writer.Write(mapping);
        }

        [Test]
        public void it_should_should_set_the_Id_attribute_to_the_id()
        {
            (result as XElement).Attribute("Id").Value.Should().Be.EqualTo(the_id);
        }
    }



    public class XmlPackageWriter :IMappingModelVisitor<PackageMapping>, IXmlWriter<PackageMapping>
    {
        XElement packageElement;

        public XContainer Write(PackageMapping mappingModel)
        {
            packageElement = null;
            mappingModel.AcceptVisitor(this);
            return packageElement;
        }

        public void ProcessMapping(PackageMapping mapping)
        {
            packageElement = new XElement("Package");

            packageElement.WithAtt("Id", mapping.Id);
        }
    }
}