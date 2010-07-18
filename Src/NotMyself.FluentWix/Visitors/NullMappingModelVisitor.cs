using System;
using NotMyself.FluentWix.MappingModel.ProductBased;

namespace NotMyself.FluentWix.Visitors
{
  public abstract class NullMappingModelVisitor : IMappingModelVisitor
  {
    public virtual void ProcessProject(ProductMapping productMapping)
    { }
  }
}