using System.Linq;
using ProductBundleRecommender.Models.Bundles.Rules;
using ProductBundleRecommender.Models.Products;
using ProductBundleRecommender.Models.Questions.Answers;

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