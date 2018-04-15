using ProductBundleRecommender.Models.Questions.Answers;

namespace ProductBundleRecommender.Models.Questions
{
    public class AgeQuestion : Question<AgeQuestion>
    {
        public Answer<AgeQuestion> Answer { get; }
        public override string Text => "What is your age?";
    }
}