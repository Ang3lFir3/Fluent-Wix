using System.Xml;
using System.Xml.Linq;

namespace NotMyself.FluentWix.InstallationModel.Output
{
  public interface IXmlWriter<T>
  {
    XDocument Write(T installationModel);
  }
}