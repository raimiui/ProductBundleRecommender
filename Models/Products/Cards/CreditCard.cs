using System.Collections.Generic;
using ProductBundleRecommender.Models.Bundles.Rules;

namespace ProductBundleRecommender.Models.Products.Cards
{
    public class CreditCard : Card
    {
        public override IList<RuleBase> Rules => new List<RuleBase>
        {
            new IncomeGt_12000(),
            new AgeOver17()
        };
    }
}