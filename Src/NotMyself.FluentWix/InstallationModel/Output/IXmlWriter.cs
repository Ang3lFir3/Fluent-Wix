using System.Xml;

namespace NotMyself.FluentWix.InstallationModel.Output
{
  public interface IXmlWriter<T>
  {
    XmlDocument Write(T installationModel);
  }
}