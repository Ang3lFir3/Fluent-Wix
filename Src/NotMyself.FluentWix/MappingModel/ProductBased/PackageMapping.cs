using System;
using NotMyself.FluentWix.Visitors;

namespace NotMyself.FluentWix.MappingModel.ProductBased
{
    public class PackageMapping : MappingBase
    {
        public override void AcceptVisitor(IMappingModelVisitor visitor)
        {
            throw new NotImplementedException();
        }

        public override bool IsSpecified(string property)
        {
            throw new NotImplementedException();
        }

        public string Id { get; set; }
    }
}