using ProductBundleRecommender.Models.Questions.Answers;

namespace ProductBundleRecommender.Models.Questions
{
    public class StudentQuestion : Question<StudentQuestion>
    {
        public Answer<StudentQuestion> Answer { get; }
        public override string Text => "Are you a student?";
    }
}