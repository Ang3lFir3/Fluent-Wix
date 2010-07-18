using System;
using NotMyself.FluentWix.Visitors;

namespace NotMyself.FluentWix.MappingModel
{
  public interface IMappingBase
  {
    void AcceptVisitor(IMappingModelVisitor visitor);
    bool IsSpecified(string property);
  }

  public abstract class MappingBase : IMappingBase
  {
    public abstract void AcceptVisitor(IMappingModelVisitor visitor);

    public abstract bool IsSpecified(string property);
  }
}