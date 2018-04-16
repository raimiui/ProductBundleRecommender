using ProductBundleRecommender.Models.Answers;

namespace Bll.Interfaces
{
    public interface IAnswerService
    {
        AgeRangeEnum[] GetPossibleAgeQuestionAnswers();
        IncomeRangeEnum[] GetPossibleIncomeQuestionAnswers();
        bool[] GetPossibleStudentQuestionAnswers();
    }
}