using ProductBundleRecommender.Models.Questions.Answers;

namespace Bll.Interfaces
{
    public interface IAnswerService
    {
        AgeRangeEnum[] GetPossibleAgeQuestionAnswers();
        IncomeRangeEnum[] GetPossibleIncomeQuestionAnswers();
        bool[] GetPossibleStudentQuestionAnswers();
    }
}