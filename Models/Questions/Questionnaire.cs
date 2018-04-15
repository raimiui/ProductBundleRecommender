using System.Collections.Generic;

namespace ProductBundleRecommender.Models.Questions
{
    public class Questionnaire
    {
        private readonly IList<Question> _questions;

        public Questionnaire()
        {
            _questions = new List<Question>
            {
                new AgeQuestion(),
                new StudentQuestion(),
                new IncomeQuestion()
            };
        }

        public IList<Question> Questions => _questions;
    }
}