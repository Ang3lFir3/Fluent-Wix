using System.Collections.Generic;

namespace NotMyself.FluentWix.MappingModel
{
  public interface IDefaultableEnumerable<T> : IEnumerable<T>
  {
    IEnumerable<T> Defaults { get; }
    IEnumerable<T> UserDefined { get; }
    bool HasUserDefined();
  }
}