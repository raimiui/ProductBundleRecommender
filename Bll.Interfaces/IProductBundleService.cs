﻿using ProductBundleRecommender.Models.Bundles;
using ProductBundleRecommender.Models.Products;
using ProductBundleRecommender.Models.Questions.Answers;

namespace Bll.Interfaces
{
    public interface IProductBundleService
    {
        string[] GetRulesConditions(Bundle bundle);
        Bundle GetRecommendedBundle(Answers answers);
        BundleModificationResponse ModifyBundle(Answers answers, Bundle bundleBeingModified, Product[] products);
    }
}