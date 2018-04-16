using ProductBundleRecommender.Models.Answers;

namespace ProductBundleRecommender.Models.Bundles.Rules
{
    public class IncomeGt_40000 : IncomeRuleBase
    {
        public override string Text => "Income > 40000";

        public override bool Execute(Answers.Answers answers)
        {
            return (int)answers.IncomeAnswer.Value > (int)IncomeRangeEnum.Range_12001_40000;
        }
    }
}