using System.Collections.Generic;
using ProductBundleRecommender.Models.Bundles.Rules;

namespace ProductBundleRecommender.Models.Products.Accounts
{
    public class JuniorSaverAccount : Account
    {
        public override IList<RuleBase> Rules => new List<RuleBase>
        {
            new AgeUnder18()
        };
    }
}