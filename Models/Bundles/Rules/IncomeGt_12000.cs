using ProductBundleRecommender.Models.Answers;

namespace ProductBundleRecommender.Models.Bundles.Rules
{
    public class IncomeGt_12000 : IncomeRuleBase
    {
        public override string Text => "Income > 12000";

        public override bool Execute(Answers.Answers answers)
        {
            return (int)answers.IncomeAnswer.Value > (int)IncomeRangeEnum.Range_1_12000;
        }
    }
}