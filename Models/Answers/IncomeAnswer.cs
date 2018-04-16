namespace ProductBundleRecommender.Models.Answers
{
    public class IncomeAnswer : Answer
    {
        private IncomeRangeEnum _incomeRangeEnum = IncomeRangeEnum.Zero;

        public IncomeAnswer(int income)
        {
            if (income >= 1 && income <= 12000)
                _incomeRangeEnum = IncomeRangeEnum.Range_1_12000;
            else if (income >= 12001 && income <= 40000)
                _incomeRangeEnum = IncomeRangeEnum.Range_12001_40000;
            else if (income >= 40001)
                _incomeRangeEnum = IncomeRangeEnum.Range_40001plus;
        }

        public IncomeAnswer(IncomeRangeEnum incomeRangeEnum)
        {
            _incomeRangeEnum = incomeRangeEnum;
        }

        public IncomeRangeEnum Value => _incomeRangeEnum;

        public override string ToString()
        {
            return _incomeRangeEnum.ToString();
        }
    }

    public enum IncomeRangeEnum
    {
        Zero = 0,
        Range_1_12000,
        Range_12001_40000,
        Range_40001plus
    }
}