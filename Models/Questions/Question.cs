using ProductBundleRecommender.Models.Questions.Answers;

namespace ProductBundleRecommender.Models.Questions
{
    public abstract class Question
    {
        public abstract string Text { get; }
        public abstract string GetAnswer { get; }
    }

    public abstract class Question<T> : Question
        where T : Question<T>
    {
        public Answer<T> Answer { get; }
        public override string GetAnswer => Answer.ToString();
    }
}