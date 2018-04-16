using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ProductBundleRecommender.BLL;
using ProductBundleRecommender.Models.Questions.Answers;

namespace WindowsFormsApp
{
    public partial class QuestionsForm : Form
    {
        public QuestionsForm()
        {
            InitializeComponent();
            

            //TODO: DI
            var answerService = new AnswerService();
            
            var possibleAgeQuestionAnswers = answerService.GetPossibleAgeQuestionAnswers();//.Select(x=>x.ToString()).Concat(new[] { "Enter your value.." }).ToArray();
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

            /*if (e.Index == chLbxAge.Items.Count - 1)
            {
                MessageBox.Show("TAD");
                var textBox = new TextBox();
                textBox.Location = new Point(chLbxAge.Location.X, chLbxAge.Location.Y);
                textBox.Width = chLbxAge.Width;

                chLbxAge.Controls.Add(textBox);
            }*/
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
            var productBundleForm = new ProductBundleForm{ Answers = answers};

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
