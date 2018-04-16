using ProductBundleRecommender.Models.Questions.Answers;

namespace WindowsFormsApp.Mappers
{
    public static class AnswersMapper
    {
        public static ProductBundleRecommender.Models.Questions.Answers.Answers Map(this Answers answers)
        {
            return new ProductBundleRecommender.Models.Questions.Answers.Answers
            {
                AgeAnswer = new AgeAnswer(answers.Age),
                StudentAnswer = new StudentAnswer(answers.IsStudent),
                IncomeAnswer = new IncomeAnswer(answers.Income)
            };
        }
    }
}