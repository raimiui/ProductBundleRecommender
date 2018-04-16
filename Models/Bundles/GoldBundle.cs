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
            Products = new List<Product> {new CurrentPlusAccount(), new DebitCard(), new GoldCreditCard()}
        };

        public override IList<RuleBase> Rules => new List<RuleBase>
        {
            new AgeOver17(),
            new IncomeGt_40000()
        };
    }
}