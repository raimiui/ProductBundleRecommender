using System.Collections.Generic;
using ProductBundleRecommender.Models.Bundles.Rules;

namespace ProductBundleRecommender.Models.Products.Cards
{
    public class GoldCreditCard : Card
    {
        public override IList<RuleBase> Rules => new List<RuleBase>
        {
            new IncomeGt_40000(),
            new AgeOver17()
        };
    }
}