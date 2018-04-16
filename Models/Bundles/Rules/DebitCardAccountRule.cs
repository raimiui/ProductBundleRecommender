using System;
using System.Linq;
using ProductBundleRecommender.Models.Products.Accounts;

namespace ProductBundleRecommender.Models.Bundles.Rules
{
    public class DebitCardAccountRule : RuleBase, IBundleParameter
    {
        public override string Text => "Bundle must include one of: Current Account, Current Account Plus, Student Account, or Pensioner Account";

        private Type[] _allowedAccounts =
        {
            typeof(CurrentAccount), typeof(CurrentPlusAccount), typeof(StudentAccount), typeof(PensionerAccount)
        };

        public bool Execute(Bundle bundle)
        {
            var account = bundle.Products.FirstOrDefault(p => p.GetType().IsSubclassOf(typeof(Account)));
            return _allowedAccounts.Contains(account?.GetType());
        }
    }
}