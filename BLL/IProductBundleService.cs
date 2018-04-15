using System.Collections.Generic;
using ProductBundleRecommender.Models.Bundles;
using ProductBundleRecommender.Models.Questions.Answers;

namespace ProductBundleRecommender.BLL
{
    public interface IProductBundleService
    {
        string[] GetAnswers(Bundle bundle);
        Bundle GetRecommendedBundle(Answers answers);
    }
}