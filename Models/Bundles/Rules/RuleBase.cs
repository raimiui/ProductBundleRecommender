namespace ProductBundleRecommender.Models.Bundles.Rules
{
    public abstract class RuleBase
    {
        public abstract string Text { get; }
    }

    public interface IAnswerParameter
    {
        bool Execute(Answers.Answers answers);
    }

    public interface IBundleParameter
    {
        bool Execute(Bundle bundle);
    }
}