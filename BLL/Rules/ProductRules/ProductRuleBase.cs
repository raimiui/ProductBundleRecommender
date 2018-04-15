namespace ProductBundleRecommender.BLL.Rules.ProductRules
{
    public abstract class ProductRuleBase<T> where T : Models.Products.Product
    {
        public abstract bool Apply(T bundle);
    }
}