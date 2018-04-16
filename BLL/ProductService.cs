using System.Linq;
using Bll.Interfaces;
using ProductBundleRecommender.Models.Answers;
using ProductBundleRecommender.Models.Bundles.Rules;
using ProductBundleRecommender.Models.Products;
using ProductBundleRecommender.Models.Products.Accounts;
using ProductBundleRecommender.Models.Products.Cards;

namespace ProductBundleRecommender.BLL
{
    public class ProductService : IProductService
    {
        public Product[] GetAvailable(Answers answers)
        {
            var products = new Product[]
            {
                new CurrentAccount(),
                new CurrentPlusAccount(),
                new JuniorSaverAccount(),
                new StudentAccount(),
                new DebitCard(),
                new CreditCard(),
                new GoldCreditCard()
            };

            //TODO: make sure DebitCard comes
            var filtered = products.Where(p => p.Rules.All(r => ((IAnswerParameter) r).Execute(answers))).ToArray();

            return filtered;
        }
    }
}