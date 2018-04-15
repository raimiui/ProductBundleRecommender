using NUnit.Framework;
using ProductBundleRecommender.Models.Bundles.Rules;
using ProductBundleRecommender.Models.Questions.Answers;

namespace ProductBundleRecommender.BLL.Tests.Rules
{
    [TestFixture]
    public class Under18Tests
    {
        [TestCase(AgeRangeEnum.Range_0_17, ExpectedResult = true)]
        [TestCase(AgeRangeEnum.Range_18_64, ExpectedResult = false)]
        [TestCase(AgeRangeEnum.Range_65plus, ExpectedResult = false)]
        public bool RulesTests_Under18(AgeRangeEnum age)
        {
            var ageAnswer = new AgeAnswer(age);

            var under18 = new Under18();

            return under18.ConformsRule(new Answers {AgeAnswer = ageAnswer});
        }

        [TestCase(0, ExpectedResult = true)]
        [TestCase(10, ExpectedResult = true)]
        [TestCase(17, ExpectedResult = true)]
        [TestCase(18, ExpectedResult = false)]
        [TestCase(80, ExpectedResult = false)]
        public bool RulesTests_Under18_acceptsSpecificValues(int age)
        {
            var ageAnswer = new AgeAnswer(age);

            var under18 = new Under18();

            return under18.ConformsRule(new Answers { AgeAnswer = ageAnswer });
        }
    }
}