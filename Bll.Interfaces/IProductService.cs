using ProductBundleRecommender.Models.Answers;
using ProductBundleRecommender.Models.Products;

namespace Bll.Interfaces
{
    public interface IProductService
    {
        Product[] GetAvailable(Answers answers);
    }
}