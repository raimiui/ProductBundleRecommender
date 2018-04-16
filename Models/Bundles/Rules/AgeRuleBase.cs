namespace ProductBundleRecommender.Models.Bundles.Rules
{
    public abstract class AgeRuleBase : RuleBase, IAnswerParameter
    {
        public abstract bool Execute(Answers.Answers answers);
    }
}