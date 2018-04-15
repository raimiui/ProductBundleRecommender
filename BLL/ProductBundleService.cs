using System;
using System.Linq;
using Bll.Interfaces;
using ProductBundleRecommender.Models.Bundles;
using ProductBundleRecommender.Models.Bundles.Rules;
using ProductBundleRecommender.Models.Questions.Answers;
using Repositories.Interfaces;

namespace ProductBundleRecommender.BLL
{
    //TODO: get answers by user

    public class ProductBundleService : IProductBundleService
    {
        private readonly IProductBundleRepository _productBundleRepository;

        public ProductBundleService(IProductBundleRepository productBundleRepository)
        {
            _productBundleRepository = productBundleRepository;
        }

        public Bundle GetRecommendedBundle(Answers answers)
        {
            // 1. Filter default bundles by executing their rules with given answers
            // 2. Return bundle with highest value
            var defaultBundles = _productBundleRepository.GetDefaultBundles();

            var recommendedBundle =
                defaultBundles
                    .Where(b => b.Rules.All(r => ExecuteRule(r, answers, b)))
                    .OrderByDescending(x => x.Value).First();

            return recommendedBundle;
        }

        //TODO: put it somewhere
        private bool ExecuteRule(RuleBase rule, Answers answers, Bundle bundle)
        {
            if (rule is IAnswerParameter)
                return ((IAnswerParameter) rule).Execute(answers);

            if (rule is IBundleParameter)
                return ((IBundleParameter)rule).Execute(bundle);

            throw new Exception("Unrecognized rule parameter type.");
        }

        public string[] GetAnswers(Bundle bundle)
        {
            return bundle.Rules.Select(r => r.Text).ToArray();
        }
    }
}
