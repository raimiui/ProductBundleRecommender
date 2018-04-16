namespace ProductBundleRecommender.Models.Bundles.Rules
{
    public class StudentRule : RuleBase, IAnswerParameter
    {
        public override string Text => "Is student";

        public bool Execute(Answers.Answers answers)
        {
            return answers.StudentAnswer.IsStudent;
        }
    }
}