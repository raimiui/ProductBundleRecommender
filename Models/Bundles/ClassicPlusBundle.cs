using System.Collections.Generic;
using ProductBundleRecommender.Models.Bundles.Rules;
using ProductBundleRecommender.Models.Products;
using ProductBundleRecommender.Models.Products.Accounts;
using ProductBundleRecommender.Models.Products.Cards;

namespace ProductBundleRecommender.Models.Bundles
{
    public class ClassicPlusBundle : Bundle
    {
        public override int Value => 2;

        public override Bundle GetDefault => new ClassicPlusBundle
        {
            Products = new List<Product> {new CurrentAccount(), new DebitCard(), new CreditCard()}
        };

        public override IList<RuleBase> Rules => new List<RuleBase>
        {
            new AgeOver17(),
            new IncomeGt_12000()
        };
    }
}