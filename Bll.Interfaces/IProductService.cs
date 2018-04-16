using ProductBundleRecommender.Models.Products;
using ProductBundleRecommender.Models.Questions.Answers;

namespace Bll.Interfaces
{
    public interface IProductService
    {
        Product[] GetAvailable(Answers answers);
    }
}