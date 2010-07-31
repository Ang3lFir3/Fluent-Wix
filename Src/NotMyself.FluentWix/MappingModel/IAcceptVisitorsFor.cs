using System;
using NotMyself.FluentWix.Visitors;

namespace NotMyself.FluentWix.MappingModel
{
  public interface IAcceptVisitorsFor<T>
  {
    void AcceptVisitor(IMappingModelVisitor<T> visitor);
    bool IsSpecified(string property);
  }
}