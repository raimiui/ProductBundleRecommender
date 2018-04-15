using ProductBundleRecommender.Models.Products.Accounts;

namespace ProductBundleRecommender.BLL.Rules.ProductRules
{
    public class Pensioner : ProductRuleBase<PensionerAccount>
    {
        public override bool Apply(Models.Products.Accounts.PensionerAccount bundle)
        {
            throw new System.NotImplementedException();
        }
    }
}