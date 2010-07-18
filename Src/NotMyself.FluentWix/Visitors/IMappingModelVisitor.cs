using NotMyself.FluentWix.MappingModel.ProductBased;

namespace NotMyself.FluentWix.Visitors
{
  public interface IMappingModelVisitor
  {
    void ProcessProject(ProductMapping productMapping);
  }
}