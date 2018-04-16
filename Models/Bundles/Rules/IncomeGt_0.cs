using ProductBundleRecommender.Models.Answers;

namespace ProductBundleRecommender.Models.Bundles.Rules
{
    public class IncomeGt_0 : IncomeRuleBase
    {
        public override string Text => "Income > 0";

        public override bool Execute(Answers.Answers answers)
        {
            return answers.IncomeAnswer.Value != IncomeRangeEnum.Zero;
        }
    }
}