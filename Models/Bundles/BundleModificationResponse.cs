namespace ProductBundleRecommender.Models.Bundles
{
    public class BundleModificationResponse
    {
        public Bundle ResultBundle { get; set; }
        public string[] Errors { get; set; }
        public bool IsValid => Errors == null || Errors.Length == 0;
    }
}