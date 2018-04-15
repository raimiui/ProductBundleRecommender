namespace ProductBundleRecommender.BLL.Rules.BundleRules
{
    public abstract class BundleRuleBase<T> where T : Models.Bundles.Bundle
    {
        public abstract bool Execute(T bundle);
    }
}