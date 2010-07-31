using System;
using System.Linq.Expressions;
using NotMyself.FluentWix.Visitors;

namespace NotMyself.FluentWix.MappingModel.ProductBased
{
    public class PackageMapping : IAcceptVisitorsFor<PackageMapping>
    {
        readonly AttributeStore<PackageMapping> attributes;
        public string Id
        {
            get { return attributes.Get(x => x.Id); }
            set { attributes.Set(x => x.Id, value); }
        }

        public string Description
        {
            get { return attributes.Get(x => x.Description); }
            set { attributes.Set(x => x.Description, value); } 
        }

        public string Comments
        {
            get { return attributes.Get(x => x.Comments); }
            set { attributes.Set(x => x.Comments, value); }
        }

        public string Keywords
        {
            get { return attributes.Get(x => x.Keywords); }
            set { attributes.Set(x => x.Keywords, value); }
        }

        public string Manufacturer
        {
            get { return attributes.Get(x => x.Manufacturer); }
            set { attributes.Set(x => x.Manufacturer, value); }
        }

        public PackageMapping(): this(new AttributeStore())
        {
        }

        public PackageMapping(AttributeStore store)
        {
            attributes = new AttributeStore<PackageMapping>(store);
            attributes.SetDefault(x => x.Id, "*");
        }

        public void AcceptVisitor(IMappingModelVisitor<PackageMapping> visitor)
        {
            visitor.ProcessMapping(this);
        }

        public bool IsSpecified(string property)
        {
            return attributes.IsSpecified(property);
        }

        public bool HasValue<TResult>(Expression<Func<PackageMapping, TResult>> property)
        {
            return attributes.HasValue(property);
        }
    }
}