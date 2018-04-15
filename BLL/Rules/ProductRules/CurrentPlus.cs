using ProductBundleRecommender.Models.Products.Accounts;

namespace ProductBundleRecommender.BLL.Rules.ProductRules
{
    public class CurrentPlus : ProductRuleBase<CurrentPlusAccount>
    {
        public override bool Apply(Models.Products.Accounts.CurrentPlusAccount bundle)
        {
            throw new System.NotImplementedException();
        }
    }
}