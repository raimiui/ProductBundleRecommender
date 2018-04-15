using ProductBundleRecommender.Models.Questions.Answers;

namespace ProductBundleRecommender.Models.Bundles.Rules
{
    public abstract class BundleRuleBase
    {
        public abstract string Text { get; }
        public abstract bool ConformsRule(Answers answers);
    }

    public abstract class AgeRule : BundleRuleBase
    {
    }

    public class Under18 : AgeRule
    {
        public override string Text => "Age < 18";

        public override bool ConformsRule(Answers answers)
        {
            return answers.AgeAnswer.Value == AgeRangeEnum.Range_0_17;
        }
    }

    public class Over17 : AgeRule
    {
        public override string Text => "Age > 17";

        public override bool ConformsRule(Answers answers)
        {
            return answers.AgeAnswer.Value != AgeRangeEnum.Range_0_17;
        }
    }


    public class StudentRule : BundleRuleBase
    {
        public override string Text => "Is student";

        public override bool ConformsRule(Answers answers)
        {
            return answers.StudentAnswer.IsStudent;
        }
    }

    public abstract class IncomeRule : BundleRuleBase
    {
    }

    public class IncomeGt_0 : IncomeRule
    {
        public override string Text => "Income > 0";

        public override bool ConformsRule(Answers answers)
        {
            return answers.IncomeAnswer.Value != IncomeRangeEnum.Zero;
        }
    }

    public class IncomeGt_12000 : IncomeRule
    {
        public override string Text => "Income > 12000";

        public override bool ConformsRule(Answers answers)
        {
            return (int)answers.IncomeAnswer.Value > (int)IncomeRangeEnum.Range_1_12000;
        }
    }

    public class IncomeGt_40000 : IncomeRule
    {
        public override string Text => "Income > 40000";

        public override bool ConformsRule(Answers answers)
        {
            return (int)answers.IncomeAnswer.Value > (int)IncomeRangeEnum.Range_12001_40000;
        }
    }

    public class DebitCardAccountRule : BundleRuleBase
    {
        public override string Text => "Income > 40000";

        public override bool ConformsRule(Answers answers)
        {
            return (int)answers.IncomeAnswer.Value > (int)IncomeRangeEnum.Range_12001_40000;
        }
    }
}