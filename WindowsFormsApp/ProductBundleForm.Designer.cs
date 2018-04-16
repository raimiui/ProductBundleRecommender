namespace WindowsFormsApp
{
    partial class ProductBundleForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblErrors = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRemoveProduct = new System.Windows.Forms.Button();
            this.listBoxSelectedProducts = new System.Windows.Forms.ListBox();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.lblProducts = new System.Windows.Forms.Label();
            this.lstBoxProducts = new System.Windows.Forms.ListBox();
            this.lblBundleName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblErrors);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnRemoveProduct);
            this.panel1.Controls.Add(this.listBoxSelectedProducts);
            this.panel1.Controls.Add(this.btnAddProduct);
            this.panel1.Controls.Add(this.lblProducts);
            this.panel1.Controls.Add(this.lstBoxProducts);
            this.panel1.Location = new System.Drawing.Point(37, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(708, 351);
            this.panel1.TabIndex = 0;
            // 
            // lblErrors
            // 
            this.lblErrors.AutoSize = true;
            this.lblErrors.ForeColor = System.Drawing.Color.Red;
            this.lblErrors.Location = new System.Drawing.Point(276, 180);
            this.lblErrors.Name = "lblErrors";
            this.lblErrors.Size = new System.Drawing.Size(34, 13);
            this.lblErrors.TabIndex = 8;
            this.lblErrors.Text = "Errors";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(12, 212);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(276, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Bundle Products";
            // 
            // btnRemoveProduct
            // 
            this.btnRemoveProduct.Location = new System.Drawing.Point(194, 110);
            this.btnRemoveProduct.Name = "btnRemoveProduct";
            this.btnRemoveProduct.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveProduct.TabIndex = 5;
            this.btnRemoveProduct.Text = "<";
            this.btnRemoveProduct.UseVisualStyleBackColor = true;
            this.btnRemoveProduct.Click += new System.EventHandler(this.btnRemoveProduct_Click);
            // 
            // listBoxSelectedProducts
            // 
            this.listBoxSelectedProducts.FormattingEnabled = true;
            this.listBoxSelectedProducts.Location = new System.Drawing.Point(276, 30);
            this.listBoxSelectedProducts.Name = "listBoxSelectedProducts";
            this.listBoxSelectedProducts.Size = new System.Drawing.Size(155, 147);
            this.listBoxSelectedProducts.TabIndex = 3;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(193, 54);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(75, 23);
            this.btnAddProduct.TabIndex = 2;
            this.btnAddProduct.Text = ">";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // lblProducts
            // 
            this.lblProducts.AutoSize = true;
            this.lblProducts.Location = new System.Drawing.Point(9, 10);
            this.lblProducts.Name = "lblProducts";
            this.lblProducts.Size = new System.Drawing.Size(95, 13);
            this.lblProducts.TabIndex = 1;
            this.lblProducts.Text = "Available Products";
            // 
            // lstBoxProducts
            // 
            this.lstBoxProducts.FormattingEnabled = true;
            this.lstBoxProducts.Location = new System.Drawing.Point(12, 30);
            this.lstBoxProducts.Name = "lstBoxProducts";
            this.lstBoxProducts.Size = new System.Drawing.Size(173, 147);
            this.lstBoxProducts.TabIndex = 0;
            this.lstBoxProducts.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // lblBundleName
            // 
            this.lblBundleName.AutoSize = true;
            this.lblBundleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBundleName.Location = new System.Drawing.Point(49, 37);
            this.lblBundleName.Name = "lblBundleName";
            this.lblBundleName.Size = new System.Drawing.Size(121, 24);
            this.lblBundleName.TabIndex = 2;
            this.lblBundleName.Text = "BundleName";
            // 
            // ProductBundleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 547);
            this.Controls.Add(this.lblBundleName);
            this.Controls.Add(this.panel1);
            this.Name = "ProductBundleForm";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblProducts;
        private System.Windows.Forms.ListBox lstBoxProducts;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.ListBox listBoxSelectedProducts;
        private System.Windows.Forms.Button btnRemoveProduct;
        private System.Windows.Forms.Label lblBundleName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblErrors;
    }
}

