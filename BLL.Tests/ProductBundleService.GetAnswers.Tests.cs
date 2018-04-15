using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using ProductBundleRecommender.Models.Bundles;
using ProductBundleRecommender.Models.Bundles.Rules;
using Repositories.Interfaces;

namespace ProductBundleRecommender.BLL.Tests
{
    [TestFixture]
    public class ProductBundleServiceGetAnswersTests
    {
        private ProductBundleService _productBundleService;
        private Dictionary<Type, RuleBase> _bundleRules;

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
            _bundleRules = new Dictionary<Type, RuleBase>
            {
                {typeof(Under18), new Under18()},
                {typeof(Over17), new Over17()},
                {typeof(StudentRule), new StudentRule()},
                {typeof(IncomeGt_0), new IncomeGt_0()},
                {typeof(IncomeGt_12000), new IncomeGt_12000()},
                {typeof(IncomeGt_40000), new IncomeGt_40000()}
            };
        }

        [Test]
        public void ProductBundleService_GetsAnswersFor_JuniorSaverBundle()
        {
            var bundle = new JuniorSaverBundle();
            var answers = _productBundleService.GetAnswers(bundle);

            var expectedAnswers = new[]
            {
                "Age < 18"
            };

            Assert.IsTrue(answers.Length == expectedAnswers.Length);
            Assert.IsTrue(answers.All(expectedAnswers.Contains));
        }

        [Test]
        public void ProductBundleService_GetsAnswersFor_StudentBundle()
        {
            var bundle = new StudentBundle();
            var answers = _productBundleService.GetAnswers(bundle);

            var expectedAnswers = new[]
            {
                "Age > 17",
                "Is student"
            };

            Assert.IsTrue(answers.Length == expectedAnswers.Length);
            Assert.IsTrue(answers.All(expectedAnswers.Contains));
        }

        [Test]
        public void ProductBundleService_GetsAnswersFor_ClassicBundle()
        {
            var bundle = new ClassicBundle();
            var answers = _productBundleService.GetAnswers(bundle);

            var expectedAnswers = new[]
            {
                "Age > 17",
                "Income > 0"
            };

            Assert.IsTrue(answers.Length == expectedAnswers.Length);
            Assert.IsTrue(answers.All(expectedAnswers.Contains));
        }

        [Test]
        public void ProductBundleService_GetsAnswersFor_ClassicPlusBundle()
        {
            var bundle = new ClassicPlusBundle();
            var answers = _productBundleService.GetAnswers(bundle);

            var expectedAnswers = new[]
            {
                "Age > 17",
                "Income > 12000"
            };

            Assert.IsTrue(answers.Length == expectedAnswers.Length);
            Assert.IsTrue(answers.All(expectedAnswers.Contains));
        }
        [Test]
        public void ProductBundleService_GetsAnswersFor_GoldBundle()
        {
            var bundle = new GoldBundle();
            var answers = _productBundleService.GetAnswers(bundle);

            var expectedAnswers = new[]
            {
                "Age > 17",
                "Income > 40000"
            };

            Assert.IsTrue(answers.Length == expectedAnswers.Length);
            Assert.IsTrue(answers.All(expectedAnswers.Contains));
        }
    }
}
