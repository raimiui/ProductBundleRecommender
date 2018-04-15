using System;
using System.Linq;
using ProductBundleRecommender.Models.Products.Accounts;
using ProductBundleRecommender.Models.Questions.Answers;

namespace ProductBundleRecommender.Models.Bundles.Rules
{
    public abstract class RuleBase
    {
        public abstract string Text { get; }
    }

    public interface IRuleParameter
    {
    }

    public interface IAnswerParameter : IRuleParameter
    {
        bool Execute(Answers answers);
    }

    public interface IBundleParameter : IRuleParameter
    {
        bool Execute(Bundle bundle);
    }

    public abstract class AgeRule : RuleBase, IAnswerParameter
    {
        public abstract bool Execute(Answers answers);
    }

    public class Under18 : AgeRule
    {
        public override string Text => "Age < 18";

        public override bool Execute(Answers answers)
        {
            return answers.AgeAnswer.Value == AgeRangeEnum.Range_0_17;
        }
    }

    public class Over17 : AgeRule
    {
        public override string Text => "Age > 17";

        public override bool Execute(Answers answers)
        {
            return answers.AgeAnswer.Value != AgeRangeEnum.Range_0_17;
        }
    }


    public class StudentRule : RuleBase, IAnswerParameter
    {
        public override string Text => "Is student";

        public bool Execute(Answers answers)
        {
            return answers.StudentAnswer.IsStudent;
        }
    }

    public abstract class IncomeRule : RuleBase, IAnswerParameter
    {
        public abstract bool Execute(Answers answers);
    }

    public class IncomeGt_0 : IncomeRule
    {
        public override string Text => "Income > 0";

        public override bool Execute(Answers answers)
        {
            return answers.IncomeAnswer.Value != IncomeRangeEnum.Zero;
        }
    }

    public class IncomeGt_12000 : IncomeRule
    {
        public override string Text => "Income > 12000";

        public override bool Execute(Answers answers)
        {
            return (int)answers.IncomeAnswer.Value > (int)IncomeRangeEnum.Range_1_12000;
        }
    }

    public class IncomeGt_40000 : IncomeRule
    {
        public override string Text => "Income > 40000";

        public override bool Execute(Answers answers)
        {
            return (int)answers.IncomeAnswer.Value > (int)IncomeRangeEnum.Range_12001_40000;
        }
    }

    public class DebitCardAccountRule : RuleBase, IBundleParameter
    {
        public override string Text => "Bundle must include one of: Current Account, Current Account Plus, Student Account, or Pensioner Account";

        private Type[] _allowedAccounts =
        {
            typeof(CurrentAccount), typeof(CurrentPlusAccount), typeof(StudentAccount), typeof(PensionerAccount)
        };

        public bool Execute(Bundle bundle)
        {
            var account = bundle.Products.FirstOrDefault(p => p.GetType().IsSubclassOf(typeof(Account)));
            return _allowedAccounts.Contains(account?.GetType());
        }
    }
}