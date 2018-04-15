using System.Collections.Generic;
using ProductBundleRecommender.Models.Bundles.Rules;
using ProductBundleRecommender.Models.Products;
using ProductBundleRecommender.Models.Products.Accounts;
using ProductBundleRecommender.Models.Products.Cards;

namespace ProductBundleRecommender.Models.Bundles
{
    public class StudentBundle : Bundle
    {
        public override int Value => 0;

        public override Bundle GetDefault => new StudentBundle
        {
            Products = new List<Product> {new StudentAccount(), new DebitCard(), new CreditCard()}
        };

        public override IList<RuleBase> Rules => new List<RuleBase>
        {
            new Over17(),
            new StudentRule()
        };
    }
}