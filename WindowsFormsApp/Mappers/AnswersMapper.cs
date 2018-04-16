using ProductBundleRecommender.Models.Answers;

namespace WindowsFormsApp.Mappers
{
    public static class AnswersMapper
    {
        public static ProductBundleRecommender.Models.Answers.Answers Map(this Answers answers)
        {
            return new ProductBundleRecommender.Models.Answers.Answers
            {
                AgeAnswer = new AgeAnswer(answers.Age),
                StudentAnswer = new StudentAnswer(answers.IsStudent),
                IncomeAnswer = new IncomeAnswer(answers.Income)
            };
        }
    }
}