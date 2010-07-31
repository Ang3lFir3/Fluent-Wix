using System;
using System.Linq.Expressions;
using NotMyself.FluentWix.Visitors;

namespace NotMyself.FluentWix.MappingModel.ProductBased
{
  public class ProductMapping : IAcceptVisitorsFor<ProductMapping>
  {
    private readonly AttributeStore<ProductMapping> attributes;

    public ProductMapping()
      : this(new AttributeStore())
    {
    }

    public ProductMapping(AttributeStore store)
    {
      attributes = new AttributeStore<ProductMapping>(store);
      attributes.SetDefault(x => x.Id, Guid.Empty);
    }

    public string Name
    {
      get { return attributes.Get(x => x.Name); }
      set { attributes.Set(x => x.Name, value); }
    }

    public Guid Id
    {
      get { return attributes.Get(x => x.Id); }
      set { attributes.Set(x => x.Id, value); }
    }

    public string Manufacturer
    {
      get { return attributes.Get(x => x.Manufacturer); }
      set { attributes.Set(x => x.Manufacturer, value); }
    }

    public Version Version
    {
      get { return attributes.Get(x => x.Version); }
      set { attributes.Set(x => x.Version, value); }
    }

    public Guid UpgradeCode
    {
      get { return attributes.Get(x => x.UpgradeCode); }
      set { attributes.Set(x => x.UpgradeCode, value); }
    }

    public PackageMapping Package { get; set; }

    public void AcceptVisitor(IMappingModelVisitor<ProductMapping> visitor)
    {
      visitor.ProcessProject(this);
    }

    public bool IsSpecified(string property)
    {
      return attributes.IsSpecified(property);
    }

    public bool HasValue<TResult>(Expression<Func<ProductMapping, TResult>> property)
    {
      return attributes.HasValue(property);
    }
  }
}