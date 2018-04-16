using System;

namespace ProductBundleRecommender.Models.Answers
{
    public class AgeAnswer : Answer
    {
        private AgeRangeEnum _ageRange = AgeRangeEnum.Range_0_17;
        public AgeAnswer(int age)
        {
            if(age < 18)
                _ageRange = AgeRangeEnum.Range_0_17;
            else if (age >= 18 && age < 65)
                _ageRange = AgeRangeEnum.Range_18_64;
            else
                _ageRange = AgeRangeEnum.Range_65plus;
        }

        public AgeAnswer(AgeRangeEnum ageRange)
        {
            _ageRange = ageRange;
        }

        public AgeRangeEnum Value => _ageRange;

        public override string ToString()
        {
            return _ageRange.ToString();
        }
    }

    [Flags]
    public enum AgeRangeEnum
    {
        Range_0_17,
        Range_18_64,
        Range_65plus
    }
}