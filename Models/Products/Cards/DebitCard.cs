using System.Collections.Generic;
using ProductBundleRecommender.Models.Bundles.Rules;

namespace ProductBundleRecommender.Models.Products.Cards
{
    public class DebitCard : Card
    {
        public override IList<RuleBase> Rules => new List<RuleBase>();
    }
}