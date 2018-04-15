using System.Collections.Generic;
using ProductBundleRecommender.Models.Bundles.Rules;
using ProductBundleRecommender.Models.Products;

namespace ProductBundleRecommender.Models.Bundles
{
    public abstract class Bundle
    {
        public abstract int Value { get; }
        public abstract Bundle GetDefault { get; }
        public IList<Product> Products { get; set; }
        public abstract IList<BundleRuleBase> Rules { get; }
    }
}