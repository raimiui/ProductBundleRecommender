﻿using System.Collections.Generic;
using ProductBundleRecommender.Models.Bundles.Rules;

namespace ProductBundleRecommender.Models.Products.Accounts
{
    public class CurrentAccount : Account
    {
        public override IList<RuleBase> Rules => new List<RuleBase>
        {
            new IncomeGt_0(),
            new AgeOver17()
        };
    }
}