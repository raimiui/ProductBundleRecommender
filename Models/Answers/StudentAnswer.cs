namespace ProductBundleRecommender.Models.Answers
{
    public class StudentAnswer : Answer
    {
        private readonly bool _isStudent;

        public StudentAnswer(bool isStudent)
        {
            _isStudent = isStudent;
        }

        public bool IsStudent => _isStudent;

        public override string ToString()
        {
            return _isStudent.ToString();
        }
    }
}