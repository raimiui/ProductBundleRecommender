using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using ProductBundleRecommender.Models.Answers;
using ProductBundleRecommender.Models.Bundles;
using ProductBundleRecommender.Models.Products;
using ProductBundleRecommender.Models.Products.Accounts;
using ProductBundleRecommender.Models.Products.Cards;
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
                new Product[] { new JuniorSaverAccount() }
            );

            Assert.IsInstanceOf<JuniorSaverBundle>(response.ResultBundle);
        }

        [Test]
        public void ProductBundleService_ModifyBundle_Returns_StudentBundleNotReturnedForPoorStudent()
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
                new Product[] { new StudentAccount(), new DebitCard(), new CreditCard() }
            );

            Assert.IsInstanceOf<ClassicBundle>(response.ResultBundle);
        }

        [Test]
        public void ProductBundleService_ModifyBundle_Returns_StudentBundleForRichStudent()
        {
            var classicBundle = new ClassicBundle();

            var response = _productBundleService.ModifyBundle
            (
                new Answers
                {
                    AgeAnswer = new AgeAnswer(18),
                    StudentAnswer = new StudentAnswer(true),
                    IncomeAnswer = new IncomeAnswer(IncomeRangeEnum.Range_12001_40000)
                },
                classicBundle,
                new Product[] { new StudentAccount(), new DebitCard(), new CreditCard() }
            );

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
                new Product[] { new CurrentAccount(), new DebitCard() }
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
                new Product[] {new CurrentAccount(), new DebitCard(), new CreditCard()}
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
                new Product[] { new CurrentPlusAccount(), new DebitCard(), new GoldCreditCard()}
            );

            Assert.IsInstanceOf<GoldBundle>(response.ResultBundle);
        }
    }
}
