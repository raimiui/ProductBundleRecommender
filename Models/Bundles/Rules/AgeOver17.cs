using ProductBundleRecommender.Models.Answers;

namespace ProductBundleRecommender.Models.Bundles.Rules
{
    public class AgeOver17 : AgeRuleBase
    {
        public override string Text => "Age > 17";

        public override bool Execute(Answers.Answers answers)
        {
            return answers.AgeAnswer.Value != AgeRangeEnum.Range_0_17;
        }
    }
}