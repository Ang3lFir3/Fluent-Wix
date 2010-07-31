using NotMyself.FluentWix.MappingModel.ProductBased;

namespace NotMyself.FluentWix.Visitors
{
  public interface IMappingModelVisitor<T>
  {
    void ProcessProject(T mapping);
  }
}