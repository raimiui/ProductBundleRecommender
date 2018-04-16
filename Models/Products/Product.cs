using System;
using System.Collections.Generic;
using ProductBundleRecommender.Models.Bundles.Rules;

namespace ProductBundleRecommender.Models.Products
{
    public abstract class Product : IComparable<Product>
    {
        public abstract IList<RuleBase> Rules { get; }

        public int CompareTo(Product other)
        {
            return GetType().ToString().CompareTo(other.GetType().ToString());
        }
    }

    public class ProductComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product x, Product y)
        {
            return x.GetType() == y.GetType();
        }

        public int GetHashCode(Product obj)
        {
            return 0;
        }
    }
}
