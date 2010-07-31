using System;
using System.Xml;
using System.Xml.Linq;
using NotMyself.FluentWix.MappingModel.ProductBased;
using NotMyself.FluentWix.Utils;
using NotMyself.FluentWix.Visitors;

namespace NotMyself.FluentWix.InstallationModel.Output
{
  public class XmlProductWriter : IMappingModelVisitor<ProductMapping>, IXmlWriter<ProductMapping>
  {
    private XDocument document;

    public XContainer Write(ProductMapping installationMapping)
    {
      document = null;
      installationMapping.AcceptVisitor(this);
      return document;
    }

    public void ProcessProject(ProductMapping productMapping)
    {
      document = new XDocument();

      var root = document.AddElement("Wix")
        .WithAtt("xmlns", "http://schemas.microsoft.com/wix/2003/01/wi");
      
      var project = root.AddElement("Product");

      if (productMapping.HasValue(x => x.Id))
        project.WithAtt("Id", productMapping.Id.ToString());

      if (productMapping.HasValue(x => x.UpgradeCode))
        project.WithAtt("UpgradeCode", productMapping.UpgradeCode.ToString());
      
      if (productMapping.HasValue(x => x.Name))
        project.WithAtt("Name", productMapping.Name);
      
      if (productMapping.HasValue(x => x.Manufacturer))
        project.WithAtt("Manufacturer", productMapping.Manufacturer);

      if (productMapping.HasValue(x => x.Version))
        project.WithAtt("Version", productMapping.Version.ToString());

      project.AddElement("Package").WithAtt("Id","*");
    }
  }
}