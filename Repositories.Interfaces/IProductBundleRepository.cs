using System.Collections.Generic;
using ProductBundleRecommender.Models.Bundles;

namespace Repositories.Interfaces
{
    public interface IProductBundleRepository
    {
        IList<Bundle> GetDefaultBundles();
    }
}