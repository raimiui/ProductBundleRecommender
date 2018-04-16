using NUnit.Framework;
using ProductBundleRecommender.Models.Answers;
using ProductBundleRecommender.Models.Bundles.Rules;

namespace ProductBundleRecommender.BLL.Tests.Rules
{
    [TestFixture]
    public class IsStudentTests
    {
        [TestCase(true, ExpectedResult = true)]
        [TestCase(false, ExpectedResult = false)]
        public bool RulesTests_IsStudent(bool value)
        {
            var studentAnswer = new StudentAnswer(value);

            var under18 = new StudentRule();

            return under18.Execute(new Answers {StudentAnswer = studentAnswer });
        }
    }
}