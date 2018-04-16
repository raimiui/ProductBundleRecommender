using System.Windows.Forms;
using Bll.Interfaces;
using ProductBundleRecommender.BLL;
using ProductBundleRecommender.Models.Answers;

namespace WindowsFormsApp
{
    public partial class QuestionsForm : Form
    {
        private readonly IProductBundleService _productBundleService;
        private readonly IProductService _productService;
        private readonly IAnswerService _answerService;

        public QuestionsForm(IProductBundleService productBundleService, IProductService productService, IAnswerService answerService)
        {
            _productBundleService = productBundleService;
            _productService = productService;
            _answerService = answerService;
            InitializeComponent();
            

            _answerService = answerService;

            var possibleAgeQuestionAnswers = answerService.GetPossibleAgeQuestionAnswers();
            var possibleStudentQuestionAnswers = answerService.GetPossibleStudentQuestionAnswers();
            var possibleIncomeQuestionAnswers = answerService.GetPossibleIncomeQuestionAnswers();

            chLbxAge.DataSource = possibleAgeQuestionAnswers;
            chLbxStudent.DataSource = possibleStudentQuestionAnswers;
            chLbxIncome.DataSource = possibleIncomeQuestionAnswers;
        }

        private void chLbxAge_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // allows only one value selected
            if (chLbxAge.CheckedItems.Count >= 1 && e.CurrentValue != CheckState.Checked)
            {
                e.NewValue = e.CurrentValue;
            }
        }

        private void chLbxStudent_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (chLbxStudent.CheckedItems.Count >= 1 && e.CurrentValue != CheckState.Checked)
            {
                e.NewValue = e.CurrentValue;
            }
        }

        private void chLbxIncome_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (chLbxIncome.CheckedItems.Count >= 1 && e.CurrentValue != CheckState.Checked)
            {
                e.NewValue = e.CurrentValue;
            }
        }

        

        private void Submit_Click(object sender, System.EventArgs e)
        {
            if (!(chLbxAge.CheckedItems.Count == 1 &&
                chLbxStudent.CheckedItems.Count == 1 &&
                chLbxIncome.CheckedItems.Count == 1))
            {
                MessageBox.Show("Please answer all questions.");
                return;
            }

            var answers = new Answers
            {
                Age = (AgeRangeEnum)chLbxAge.SelectedValue,
                IsStudent = (bool)chLbxStudent.SelectedValue,
                Income = (IncomeRangeEnum)chLbxIncome.SelectedValue
            };

            this.Hide();
            var productBundleForm = new ProductBundleForm(_productBundleService, _productService){ Answers = answers};

            productBundleForm.VisibleChanged += (o, args) => Show();
            productBundleForm.Show();
        }
    }

    public class Answers
    {
        public AgeRangeEnum Age { get; set; }
        public bool IsStudent { get; set; }
        public IncomeRangeEnum Income { get; set; }
    }
}
