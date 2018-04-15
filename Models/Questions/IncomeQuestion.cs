using ProductBundleRecommender.Models.Questions.Answers;

namespace ProductBundleRecommender.Models.Questions
{
    public class IncomeQuestion : Question<IncomeQuestion>
    {
        public Answer<IncomeQuestion> Answer { get; }
        public override string Text => "What is your income?";
    }
}