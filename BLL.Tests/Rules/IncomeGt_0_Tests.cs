using NUnit.Framework;
using ProductBundleRecommender.Models.Answers;
using ProductBundleRecommender.Models.Bundles.Rules;

namespace ProductBundleRecommender.BLL.Tests.Rules
{
    public class IncomeGt_0_Tests
    {

        [TestCase(IncomeRangeEnum.Zero, ExpectedResult = false)]
        [TestCase(IncomeRangeEnum.Range_1_12000, ExpectedResult = true)]
        [TestCase(IncomeRangeEnum.Range_12001_40000, ExpectedResult = true)]
        [TestCase(IncomeRangeEnum.Range_40001plus, ExpectedResult = true)]
        public bool RulesTests_IncomeGt_0(IncomeRangeEnum income)
        {
            var answer = new IncomeAnswer(income);

            var rule = new IncomeGt_0();

            return rule.Execute(new Answers { IncomeAnswer = answer });
        }

        [TestCase(-10, ExpectedResult = false)]
        [TestCase(0, ExpectedResult = false)]
        [TestCase(1, ExpectedResult = true)]
        [TestCase(12000, ExpectedResult = true)]
        [TestCase(40000, ExpectedResult = true)]
        [TestCase(99999, ExpectedResult = true)]
        public bool RulesTests_IncomeGt_0_AcceptsSpecificValues(int income)
        {
            var answer = new IncomeAnswer(income);

            var rule = new IncomeGt_0();

            return rule.Execute(new Answers { IncomeAnswer = answer });
        }
    }
}