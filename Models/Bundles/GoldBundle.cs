using System.Collections.Generic;
using ProductBundleRecommender.Models.Bundles.Rules;
using ProductBundleRecommender.Models.Products;
using ProductBundleRecommender.Models.Products.Accounts;
using ProductBundleRecommender.Models.Products.Cards;

namespace ProductBundleRecommender.Models.Bundles
{
    public class GoldBundle : Bundle
    {
        public override int Value => 3;

        public override Bundle GetDefault => new GoldBundle
        {
            Products = new List<Product> {new CurrentAccount(), new DebitCard(), new GoldCard()}
        };

        public override IList<RuleBase> Rules => new List<RuleBase>
        {
            new Over17(),
            new IncomeGt_40000()
        };
    }
}