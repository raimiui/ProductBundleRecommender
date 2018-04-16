using System.Collections.Generic;
using ProductBundleRecommender.Models.Bundles.Rules;
using ProductBundleRecommender.Models.Products;
using ProductBundleRecommender.Models.Products.Accounts;
using ProductBundleRecommender.Models.Products.Cards;

namespace ProductBundleRecommender.Models.Bundles
{
    public class ClassicBundle : Bundle
    {
        public override int Value => 1;

        public override Bundle GetDefault => new ClassicBundle
        {
            Products = new List<Product> { new CurrentAccount(), new DebitCard() }
        };

        public override IList<RuleBase> Rules => new List<RuleBase>
        {
            new AgeOver17(),
            new IncomeGt_0()
        };
    }
}