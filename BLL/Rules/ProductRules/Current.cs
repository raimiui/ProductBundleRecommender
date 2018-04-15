using ProductBundleRecommender.Models.Products.Accounts;

namespace ProductBundleRecommender.BLL.Rules.ProductRules
{
    public class Current : ProductRuleBase<CurrentAccount>
    {
        public override bool Apply(Models.Products.Accounts.CurrentAccount bundle)
        {
            throw new System.NotImplementedException();
        }
    }
}