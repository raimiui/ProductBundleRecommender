using System;
using System.Linq;
using ProductBundleRecommender.Models.Bundles;
using ProductBundleRecommender.Models.Bundles.Rules;
using ProductBundleRecommender.Models.Products;
using ProductBundleRecommender.Models.Questions.Answers;

namespace ProductBundleRecommender.BLL.Extensions
{
    public static class ProductBundleExtensions
    {
        public static Bundle GetBundleByAnswers(this System.Collections.Generic.IList<Bundle> bundles, Answers answers)
        {
            return bundles
                .Where(b => b.Rules.All(r => ExecuteRule(r, answers, b)))
                .OrderByDescending(x => x.Value).First();
        }

        #region MyRegion
        private static bool ExecuteRule(RuleBase rule, Answers answers, Bundle bundle)
        {
            if (rule is IAnswerParameter)
                return ((IAnswerParameter)rule).Execute(answers);

            if (rule is IBundleParameter)
                return ((IBundleParameter)rule).Execute(bundle);

            throw new Exception("Unrecognized rule parameter type.");
        }
        #endregion

        public static Bundle GetBundleByProducts(this System.Collections.Generic.IList<Bundle> bundles, Product[] products)
        {
            return bundles
                .Where(b =>
                    Enumerable.SequenceEqual
                    (
                        products.OrderBy(x => x),
                        b.Products.OrderBy(x => x),
                        new ProductComparer())
                ).OrderByDescending(x => x.Value)
                .FirstOrDefault();
        }


    }
}