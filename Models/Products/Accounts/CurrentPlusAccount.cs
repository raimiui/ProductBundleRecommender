using System.Collections.Generic;
using ProductBundleRecommender.Models.Bundles.Rules;

namespace ProductBundleRecommender.Models.Products.Accounts
{
    public class CurrentPlusAccount : Account
    {
        public override IList<RuleBase> Rules => new List<RuleBase>
        {
            new IncomeGt_40000(),
            new AgeOver17()
        };
    }
}