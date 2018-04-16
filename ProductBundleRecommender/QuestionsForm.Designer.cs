namespace WindowsFormsApp
{
    partial class QuestionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chLbxAge = new System.Windows.Forms.CheckedListBox();
            this.chLbxStudent = new System.Windows.Forms.CheckedListBox();
            this.chLbxIncome = new System.Windows.Forms.CheckedListBox();
            this.Submit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chLbxAge
            // 
            this.chLbxAge.CheckOnClick = true;
            this.chLbxAge.FormattingEnabled = true;
            this.chLbxAge.Location = new System.Drawing.Point(143, 65);
            this.chLbxAge.Name = "chLbxAge";
            this.chLbxAge.Size = new System.Drawing.Size(150, 79);
            this.chLbxAge.TabIndex = 0;
            this.chLbxAge.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chLbxAge_ItemCheck);
            // 
            // chLbxStudent
            // 
            this.chLbxStudent.CheckOnClick = true;
            this.chLbxStudent.FormattingEnabled = true;
            this.chLbxStudent.Location = new System.Drawing.Point(143, 149);
            this.chLbxStudent.Name = "chLbxStudent";
            this.chLbxStudent.Size = new System.Drawing.Size(150, 34);
            this.chLbxStudent.TabIndex = 1;
            this.chLbxStudent.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chLbxStudent_ItemCheck);
            // 
            // chLbxIncome
            // 
            this.chLbxIncome.CheckOnClick = true;
            this.chLbxIncome.FormattingEnabled = true;
            this.chLbxIncome.Location = new System.Drawing.Point(143, 189);
            this.chLbxIncome.Name = "chLbxIncome";
            this.chLbxIncome.Size = new System.Drawing.Size(150, 64);
            this.chLbxIncome.TabIndex = 2;
            this.chLbxIncome.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chLbxIncome_ItemCheck);
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(143, 259);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(75, 23);
            this.Submit.TabIndex = 3;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "What is your age?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Are you a student?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "What is your income?";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Please select answers:";
            // 
            // QuestionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 451);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.chLbxIncome);
            this.Controls.Add(this.chLbxStudent);
            this.Controls.Add(this.chLbxAge);
            this.Name = "QuestionsForm";
            this.Text = "QuestionsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chLbxAge;
        private System.Windows.Forms.CheckedListBox chLbxStudent;
        private System.Windows.Forms.CheckedListBox chLbxIncome;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}