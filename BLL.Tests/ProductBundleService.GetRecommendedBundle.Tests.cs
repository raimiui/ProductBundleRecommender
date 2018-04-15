using NUnit.Framework;
using ProductBundleRecommender.Models.Bundles;
using ProductBundleRecommender.Models.Questions.Answers;

namespace ProductBundleRecommender.BLL.Tests
{
    [TestFixture]
    public class ProductBundleServiceTests
    {
        private ProductBundleService _productBundleService;

        [SetUp]
        public void SetUpFixture()
        {
            _productBundleService = new ProductBundleService();
        }

        [Test]
        public void ProductBundleService_Recomends_JuniorSaverBundle()
        {
            var recommendedBundle = _productBundleService.GetRecommendedBundle(
                new Answers
                {
                    AgeAnswer = new AgeAnswer(AgeRangeEnum.Range_0_17),
                    StudentAnswer = new StudentAnswer(false),
                    IncomeAnswer = new IncomeAnswer(default(IncomeRangeEnum))
            });

            Assert.IsInstanceOf<JuniorSaverBundle>(recommendedBundle);
        }

        [Test]
        public void ProductBundleService_Recomends_StudentBundle()
        {
            var recommendedBundle = _productBundleService.GetRecommendedBundle(
                new Answers
                {
                    AgeAnswer = new AgeAnswer(18),
                    StudentAnswer = new StudentAnswer(true),
                    IncomeAnswer = new IncomeAnswer(default(IncomeRangeEnum))
                });

            Assert.IsInstanceOf<StudentBundle>(recommendedBundle);
        }

        [TestCase(1)]
        [TestCase(12000)]
        public void ProductBundleService_Recomends_ClassicBundle(int income)
        {
            var recommendedBundle = _productBundleService.GetRecommendedBundle(
                new Answers
                {
                    AgeAnswer = new AgeAnswer(18),
                    StudentAnswer = new StudentAnswer(true),
                    IncomeAnswer = new IncomeAnswer(income)
                });

            Assert.IsInstanceOf<ClassicBundle>(recommendedBundle);
        }

        [TestCase(12001)]
        [TestCase(40000)]
        public void ProductBundleService_Recomends_ClassicBundlePlus(int income)
        {
            var recommendedBundle = _productBundleService.GetRecommendedBundle(
                new Answers
                {
                    AgeAnswer = new AgeAnswer(18),
                    StudentAnswer = new StudentAnswer(true),
                    IncomeAnswer = new IncomeAnswer(income)
                });

            Assert.IsInstanceOf<ClassicPlusBundle>(recommendedBundle);
        }

        [TestCase(40001)]
        public void ProductBundleService_Recomends_GoldBundle(int income)
        {
            var recommendedBundle = _productBundleService.GetRecommendedBundle(
                new Answers
                {
                    AgeAnswer = new AgeAnswer(18),
                    StudentAnswer = new StudentAnswer(true),
                    IncomeAnswer = new IncomeAnswer(income)
                });

            Assert.IsInstanceOf<GoldBundle>(recommendedBundle);
        }
    }
}
