using System;
using NotMyself.FluentWix.Visitors;

namespace NotMyself.FluentWix.MappingModel.ProductBased
{
    public class PackageMapping : IAcceptVisitorsFor<PackageMapping>
    {
        public void AcceptVisitor(IMappingModelVisitor<PackageMapping> visitor)
        {
            throw new NotImplementedException();
        }

        public bool IsSpecified(string property)
        {
            throw new NotImplementedException();
        }

        public string Id { get; set; }
    }
}