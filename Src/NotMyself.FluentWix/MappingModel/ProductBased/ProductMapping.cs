using System;
using System.Linq.Expressions;
using NotMyself.FluentWix.Visitors;

namespace NotMyself.FluentWix.MappingModel.ProductBased
{
  public class ProductMapping : MappingBase
  {
    private readonly AttributeStore<ProductMapping> attributes;

    public ProductMapping()
      : this(new AttributeStore())
    {
    }

    public ProductMapping(AttributeStore store)
    {
      attributes = new AttributeStore<ProductMapping>(store);
    }

    public string Name
    {
      get { return attributes.Get(x => x.Name); }
      set { attributes.Set(x => x.Name, value); }
    }

    public override void AcceptVisitor(IMappingModelVisitor visitor)
    {
      visitor.ProcessProject(this);
    }

    public override bool IsSpecified(string property)
    {
      return attributes.IsSpecified(property);
    }

    public bool HasValue<TResult>(Expression<Func<ProductMapping, TResult>> property)
    {
      return attributes.HasValue(property);
    }
  }
}