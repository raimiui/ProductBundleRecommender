using ProductBundleRecommender.Models.Products.Accounts;

namespace ProductBundleRecommender.BLL.Rules.ProductRules
{
    public class Student : ProductRuleBase<StudentAccount>
    {
        public override bool Apply(Models.Products.Accounts.StudentAccount bundle)
        {
            throw new System.NotImplementedException();
        }
    }
}