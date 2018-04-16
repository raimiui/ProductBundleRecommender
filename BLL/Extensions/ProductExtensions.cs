using System.Linq;
using ProductBundleRecommender.Models.Answers;
using ProductBundleRecommender.Models.Bundles.Rules;
using ProductBundleRecommender.Models.Products;

namespace ProductBundleRecommender.BLL.Extensions
{
    public static class ProductExtensions
    {
        public static bool CompliesAnswers(this Product[] products, Answers answers)
        {
            return products.All(p => p.Rules.All(r => ((IAnswerParameter) r).Execute(answers)));
        }
    }
}