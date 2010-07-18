using NUnit.Framework;

namespace NotMyself.FluentWix.Tests.Infrastructure
{
  [TestFixture]
  public abstract class Specification
  {
    public abstract void Context();
    public abstract void Because();

    [SetUp]
    public void SetUp()
    {
      Context();
      Because();
    }
    
  }
}