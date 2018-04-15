using NUnit.Framework;
using ProductBundleRecommender.Models.Bundles.Rules;
using ProductBundleRecommender.Models.Questions.Answers;

namespace ProductBundleRecommender.BLL.Tests.Rules
{
    public class IncomeGt_40000_Tests
    {
        [TestCase(IncomeRangeEnum.Zero, ExpectedResult = false)]
        [TestCase(IncomeRangeEnum.Range_1_12000, ExpectedResult = false)]
        [TestCase(IncomeRangeEnum.Range_12001_40000, ExpectedResult = false)]
        [TestCase(IncomeRangeEnum.Range_40001plus, ExpectedResult = true)]
        public bool RulesTests_IncomeGt_40000(IncomeRangeEnum income)
        {
            var answer = new IncomeAnswer(income);

            var rule = new IncomeGt_40000();

            return rule.Execute(new Answers { IncomeAnswer = answer });
        }

        [TestCase(-10, ExpectedResult = false)]
        [TestCase(0, ExpectedResult = false)]
        [TestCase(1, ExpectedResult = false)]
        [TestCase(12000, ExpectedResult = false)]
        [TestCase(12001, ExpectedResult = false)]
        [TestCase(40000, ExpectedResult = false)]
        [TestCase(40001, ExpectedResult = true)]
        [TestCase(99999, ExpectedResult = true)]
        public bool RulesTests_IncomeGt_40000_AcceptsSpecificValues(int income)
        {
            var answer = new IncomeAnswer(income);

            var rule = new IncomeGt_40000();

            return rule.Execute(new Answers { IncomeAnswer = answer });
        }
    }
}