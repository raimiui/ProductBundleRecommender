using System;
using Bll.Interfaces;
using ProductBundleRecommender.Models.Questions.Answers;

namespace ProductBundleRecommender.BLL
{
    public class AnswerService : IAnswerService
    {
        public AgeRangeEnum[] GetPossibleAgeQuestionAnswers()
        {
            return (AgeRangeEnum[])Enum.GetValues(typeof(AgeRangeEnum));
        }

        public bool[] GetPossibleStudentQuestionAnswers()
        {
            return new[] {true, false};
        }

        public IncomeRangeEnum[] GetPossibleIncomeQuestionAnswers()
        {
            return (IncomeRangeEnum[]) Enum.GetValues(typeof(IncomeRangeEnum));
        }

    }
}