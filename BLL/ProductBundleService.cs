using System;
using System.Collections.Generic;
using System.Linq;
using ProductBundleRecommender.Models.Bundles;
using ProductBundleRecommender.Models.Bundles.Rules;
using ProductBundleRecommender.Models.Questions;
using ProductBundleRecommender.Models.Questions.Answers;

namespace ProductBundleRecommender.BLL
{
    //TODO: get answers by user

    public class ProductBundleService : IProductBundleService
    {
        //TODO: to repo
        public static IList<Bundle> DefaultBundles = new List<Bundle>
        {
            new JuniorSaverBundle().GetDefault,
            new StudentBundle().GetDefault,
            new ClassicBundle().GetDefault,
            new ClassicPlusBundle().GetDefault,
            new GoldBundle().GetDefault
        };

        public Bundle GetRecommendedBundle(Answers answers)
        {
            // 1. Filter bundles by executing their rules with given answers
            // 2. Return bundle with highest value
            var recommendedBundle = 
                DefaultBundles
                .Where(x => x.Rules.All(y => y.ConformsRule(answers)))
                .OrderByDescending(x => x.Value).First();

            return recommendedBundle;
        }

        public string[] GetAnswers(Bundle bundle)
        {
            return bundle.Rules.Select(r => r.Text).ToArray();
        }
    }
}
