using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using ProductBundleRecommender.Models.Answers;
using ProductBundleRecommender.Models.Bundles;
using Repositories.Interfaces;

namespace ProductBundleRecommender.BLL.Tests
{
    [TestFixture]
    public class ProductBundleServiceTests
    {
        private ProductBundleService _productBundleService;
        private static readonly IList<Bundle> DefaultBundles = new List<Bundle>
        {
            new JuniorSaverBundle().GetDefault,
            new StudentBundle().GetDefault,
            new ClassicBundle().GetDefault,
            new ClassicPlusBundle().GetDefault,
            new GoldBundle().GetDefault
        };

        [SetUp]
        public void SetUpFixture()
        {
            var productBundleRepositoryMock = new Mock<IProductBundleRepository>();
            productBundleRepositoryMock.Setup(x => x.GetDefaultBundles()).Returns(DefaultBundles);

            _productBundleService = new ProductBundleService(productBundleRepositoryMock.Object);
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
        public void ProductBundleService_Recomends_StudentBundleNotAvailableForPoorStudents()
        {
            var recommendedBundle = _productBundleService.GetRecommendedBundle(
                new Answers
                {
                    AgeAnswer = new AgeAnswer(18),
                    StudentAnswer = new StudentAnswer(true),
                    IncomeAnswer = new IncomeAnswer(default(IncomeRangeEnum))
                });

            Assert.IsNull(recommendedBundle);
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
