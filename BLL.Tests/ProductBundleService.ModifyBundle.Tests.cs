using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using ProductBundleRecommender.Models.Answers;
using ProductBundleRecommender.Models.Bundles;
using ProductBundleRecommender.Models.Products;
using ProductBundleRecommender.Models.Products.Accounts;
using Repositories.Interfaces;

namespace ProductBundleRecommender.BLL.Tests
{
    [TestFixture]
    public class ModifyBundleTests
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
        public void ProductBundleService_ModifyBundle_Returns_JuniorSaverBundle()
        {
            var classicBundle = new ClassicPlusBundle();

            var response = _productBundleService.ModifyBundle
            (
                new Answers
                {
                    AgeAnswer = new AgeAnswer(AgeRangeEnum.Range_0_17),
                    StudentAnswer = new StudentAnswer(false),
                    IncomeAnswer = new IncomeAnswer(default(IncomeRangeEnum))
                },
                classicBundle,
                new JuniorSaverBundle().GetDefault.Products.ToArray()
            );

            Assert.IsInstanceOf<JuniorSaverBundle>(response.ResultBundle);
        }

        [Test]
        public void ProductBundleService_ModifyBundle_Returns_StudentBundle()
        {
            var classicBundle = new ClassicBundle();

            var response = _productBundleService.ModifyBundle
            (
                new Answers
                {
                    AgeAnswer = new AgeAnswer(18),
                    StudentAnswer = new StudentAnswer(true),
                    IncomeAnswer = new IncomeAnswer(default(IncomeRangeEnum))
                },
                classicBundle,
                new StudentBundle().GetDefault.Products.ToArray()
            );

            throw new Exception("Is StudentBundle only for rich students? Credit card rule product asks for income > 12000.");
            Assert.IsInstanceOf<StudentBundle>(response.ResultBundle);
        }

        [TestCase(1)]
        [TestCase(12000)]
        public void ProductBundleService_ModifyBundle_Returns_ClassicBundle(int income)
        {
            var classicBundle = new ClassicBundle();

            var response = _productBundleService.ModifyBundle
            (
                new Answers
                {
                    AgeAnswer = new AgeAnswer(18),
                    StudentAnswer = new StudentAnswer(true),
                    IncomeAnswer = new IncomeAnswer(income)
                },
                classicBundle,
                new ClassicBundle().GetDefault.Products.ToArray()
            );

            Assert.IsInstanceOf<ClassicBundle>(response.ResultBundle);
        }

        [TestCase(12001)]
        [TestCase(40000)]
        public void ProductBundleService_ModifyBundle_Returns_ClassicBundlePlus(int income)
        {
            var classicBundle = new ClassicBundle();

            var response = _productBundleService.ModifyBundle
            (
                new Answers
                {
                    AgeAnswer = new AgeAnswer(18),
                    StudentAnswer = new StudentAnswer(true),
                    IncomeAnswer = new IncomeAnswer(income)
                },
                classicBundle,
                new ClassicPlusBundle().GetDefault.Products.ToArray()
            );

            Assert.IsInstanceOf<ClassicPlusBundle>(response.ResultBundle);
        }

        [TestCase(40001)]
        public void ProductBundleService_ModifyBundle_Returns_GoldBundle(int income)
        {
            var classicBundle = new ClassicBundle();

            var response = _productBundleService.ModifyBundle
            (
                new Answers
                {
                    AgeAnswer = new AgeAnswer(18),
                    StudentAnswer = new StudentAnswer(true),
                    IncomeAnswer = new IncomeAnswer(income)
                },
                classicBundle,
                new GoldBundle().GetDefault.Products.ToArray()
            );

            Assert.IsInstanceOf<GoldBundle>(response.ResultBundle);
        }
    }
}
