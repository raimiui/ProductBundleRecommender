using System.Collections.Generic;
using ProductBundleRecommender.Models.Bundles.Rules;

namespace ProductBundleRecommender.Models.Products.Accounts
{
    public class StudentAccount : Account
    {
        public override IList<RuleBase> Rules => new List<RuleBase>
        {
            new StudentRule(),
            new AgeOver17()
        };
    }
}