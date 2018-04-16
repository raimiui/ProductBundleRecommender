using System.Linq;
using Bll.Interfaces;
using ProductBundleRecommender.BLL.Extensions;
using ProductBundleRecommender.Models.Answers;
using ProductBundleRecommender.Models.Bundles;
using ProductBundleRecommender.Models.Products;
using Repositories.Interfaces;

namespace ProductBundleRecommender.BLL
{
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
            Bundle[] recommendedBundles = defaultBundles.GetBundleByAnswers(answers);
            // leave only valid bundles
            recommendedBundles = recommendedBundles?.Where(b => Validate(b, answers)).ToArray();
            return recommendedBundles.Any() ? recommendedBundles.OrderByDescending(x => x.Value).First() : null;
        }

        private bool Validate(Bundle bundle, Answers answers)
        {
            // check bundle rules
            var bundleRulesValid = bundle.Rules.All(r => ProductBundleExtensions.ExecuteRule(r, answers, bundle));
            // check product rules
            var bundleProductsValid = bundle.Products.SelectMany(p => p.Rules).All(r => ProductBundleExtensions.ExecuteRule(r, answers, bundle));
            return bundleRulesValid && bundleProductsValid;
        }

        public BundleModificationResponse ModifyBundle(Answers answers, Bundle bundleBeingModified, Product[] products)
        {
            var defaultBundles = _productBundleRepository.GetDefaultBundles();
            var response = new BundleModificationResponse();

            // - Check if passed in products comply to answers
            if (products.CompliesAnswers(answers))
            {
                //      * Yes: 
            //           - Try get result bundle by products
                var bundles = defaultBundles.GetBundleByProducts(products);
                // leave only valid bundles
                bundles = bundles?.Where(b => Validate(b, answers)).ToArray();

                var resultBundle = bundles.Any() ? bundles.OrderByDescending(x => x.Value).FirstOrDefault() : null;
                //              * exists:      return bundle
                if (resultBundle != null)
                {
                    response.ResultBundle = resultBundle;
                    return response;
                }
            //              * not exists:  No such bundle (BundleBeingModified rules)
            }

            //      * No: not exists:  No such bundle (BundleBeingModified rules)
            response.ResultBundle = bundleBeingModified;
            response.Errors = GetRulesConditions(bundleBeingModified);
            return response;
        }

        

        public string[] GetRulesConditions(Bundle bundle)
        {
            return bundle.Rules.Select(r => r.Text).ToArray();
        }
    }
}
