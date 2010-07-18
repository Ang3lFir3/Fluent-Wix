namespace NotMyself.FluentWix.InstallationModel.Output
{
  public interface IXmlWriterServiceLocator
  {
    IXmlWriter<T> GetWriter<T>();
  }
}