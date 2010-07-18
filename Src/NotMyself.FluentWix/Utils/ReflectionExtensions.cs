using System;
using System.Linq.Expressions;
using NotMyself.FluentWix.Mapping;

namespace NotMyself.FluentWix.Utils
{
  public static class ReflectionExtensions
  {
    public static Member ToMember<TMapping, TReturn>(this Expression<Func<TMapping, TReturn>> propertyExpression)
    {
      return ReflectionHelper.GetMember(propertyExpression);
    }
  }
}