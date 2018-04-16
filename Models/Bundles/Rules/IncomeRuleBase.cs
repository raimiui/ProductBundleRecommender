namespace ProductBundleRecommender.Models.Bundles.Rules
{
    public abstract class IncomeRuleBase : RuleBase, IAnswerParameter
    {
        public abstract bool Execute(Answers.Answers answers);
    }
}