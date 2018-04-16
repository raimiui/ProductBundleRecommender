using System.Collections.Generic;
using ProductBundleRecommender.Models.Bundles;
using Repositories.Interfaces;

namespace ProductBundleRecommender.Repository
{
    public class ProductBundleRepository : IProductBundleRepository
    {
        private static readonly IList<Bundle> DefaultBundles = new List<Bundle>
        {
            new JuniorSaverBundle().GetDefault,
            new StudentBundle().GetDefault,
            new ClassicBundle().GetDefault,
            new ClassicPlusBundle().GetDefault,
            new GoldBundle().GetDefault
        };

        public IList<Bundle> GetDefaultBundles()
        {
            return DefaultBundles;

        }
    }
}