using ProductBundleRecommender.Models.Bundles;
using ProductBundleRecommender.Models.Questions.Answers;

namespace Bll.Interfaces
{
    public interface IProductBundleService
    {
        string[] GetAnswers(Bundle bundle);
        Bundle GetRecommendedBundle(Answers answers);
    }
}