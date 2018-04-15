namespace ProductBundleRecommender.Models.Questions.Answers
{
    public abstract class Answer
    {
        public abstract string ToString();
    }

    public abstract class Answer<T> : Answer
        where T : Question<T>
    {
    }
}