namespace ProductBundleRecommender.Models.Questions.Answers
{
    public class StudentAnswer : Answer<StudentQuestion>
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