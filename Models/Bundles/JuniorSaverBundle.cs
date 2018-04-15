using System.Collections.Generic;
using ProductBundleRecommender.Models.Bundles.Rules;
using ProductBundleRecommender.Models.Products;
using ProductBundleRecommender.Models.Products.Accounts;

namespace ProductBundleRecommender.Models.Bundles
{
    public class JuniorSaverBundle : Bundle
    {
        public override int Value => 0;

        public override Bundle GetDefault => new JuniorSaverBundle
        {
            Products = new List<Product> {new JuniorSaverAccount()}
        };

        public override IList<RuleBase> Rules => new List<RuleBase>
        {
            new Under18()
        };
    }
}