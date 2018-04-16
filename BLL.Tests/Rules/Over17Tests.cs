using NUnit.Framework;
using ProductBundleRecommender.Models.Bundles.Rules;
using ProductBundleRecommender.Models.Questions.Answers;

namespace ProductBundleRecommender.BLL.Tests.Rules
{
    [TestFixture]
    public class Over17Tests
    {
        [TestCase(AgeRangeEnum.Range_0_17, ExpectedResult = false)]
        [TestCase(AgeRangeEnum.Range_18_64, ExpectedResult = true)]
        [TestCase(AgeRangeEnum.Range_65plus, ExpectedResult = true)]
        public bool RulesTests_Over17(AgeRangeEnum age)
        {
            var ageAnswer = new AgeAnswer(age);

            var over17 = new AgeOver17();

            return over17.Execute(new Answers {AgeAnswer = ageAnswer});
        }

        [TestCase(-10, ExpectedResult = false)]
        [TestCase(0, ExpectedResult = false)]
        [TestCase(10, ExpectedResult = false)]
        [TestCase(17, ExpectedResult = false)]
        [TestCase(18, ExpectedResult = true)]
        [TestCase(80, ExpectedResult = true)]
        public bool RulesTests_Over17_acceptsSpecificValues(int age)
        {
            var ageAnswer = new AgeAnswer(age);

            var over17 = new AgeOver17();

            return over17.Execute(new Answers { AgeAnswer = ageAnswer });
        }
    }
}