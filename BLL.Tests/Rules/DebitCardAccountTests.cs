using System.Collections.Generic;
using NUnit.Framework;
using ProductBundleRecommender.Models.Bundles;
using ProductBundleRecommender.Models.Bundles.Rules;
using ProductBundleRecommender.Models.Products;
using ProductBundleRecommender.Models.Products.Accounts;

namespace ProductBundleRecommender.BLL.Tests.Rules
{
    [TestFixture]
    public class DebitCardAccountRuleTests
    {
        [Test]
        public void RulesTests_DebitCardAccountRule_FailsFor_JuniorSaverBundle()
        {
            var bundle = new JuniorSaverBundle().GetDefault;

            var rule = new DebitCardAccountRule();

            var result = rule.Execute(bundle);
            Assert.IsFalse(result);
        }

        [Test]
        public void RulesTests_DebitCardAccountRule_PassesFor_ClassicBundle()
        {
            var bundle = new ClassicBundle().GetDefault;

            var rule = new DebitCardAccountRule();

            var result = rule.Execute(bundle);
            Assert.IsTrue(result);
        }

        [Test]
        public void RulesTests_DebitCardAccountRule_PassesFor_ClassicPlusBundle()
        {
            var bundle = new ClassicPlusBundle().GetDefault;

            var rule = new DebitCardAccountRule();

            var result = rule.Execute(bundle);
            Assert.IsTrue(result);
        }

        [Test]
        public void RulesTests_DebitCardAccountRule_PassesFor_GoldBundle()
        {
            var bundle = new GoldBundle().GetDefault;

            var rule = new DebitCardAccountRule();

            var result = rule.Execute(bundle);
            Assert.IsTrue(result);
        }

        [Test]
        public void RulesTests_DebitCardAccountRule_PassesFor_GoldBundleWithPensionerAccount()
        {
            var bundle = new GoldBundle().GetDefault;
            bundle.Products = new List<Product>{new PensionerAccount()};

            var rule = new DebitCardAccountRule();

            var result = rule.Execute(bundle);
            Assert.IsTrue(result);
        }

        [Test]
        public void RulesTests_DebitCardAccountRule_HandlesNoAccount()
        {
            var bundle = new GoldBundle().GetDefault;
            bundle.Products = new List<Product>();

            var rule = new DebitCardAccountRule();

            var result = rule.Execute(bundle);
            Assert.IsFalse(result);
        }
    }
}