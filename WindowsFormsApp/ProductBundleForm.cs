using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApp.Mappers;
using ProductBundleRecommender.BLL;
using ProductBundleRecommender.Models.Bundles;
using ProductBundleRecommender.Models.Questions.Answers;

namespace WindowsFormsApp
{
    public partial class ProductBundleForm : Form
    {
        ProductBundleService _productBundleService;
        private ProductService _productService;

        public ProductBundleForm()
        {
            InitializeComponent();

            //TODO: DI
            _productBundleService = new ProductBundleService(new ProductBundleRepository());
            _productService = new ProductService();
        }

        private Bundle _formBundle;


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _formBundle = _productBundleService.GetRecommendedBundle(Answers.Map());
            BindControls();
        }

        private void BindControls()
        {
            var answers = Answers.Map();
            
            lblBundleName.Text = _formBundle.GetType().Name;

            var availableProducts = _productService.GetAvailable(answers);
            var bundleProductTypes = _formBundle.Products.Select(p => p.GetType()).ToArray();
            var availableProductsNotInBundle = availableProducts.Where(p => !bundleProductTypes.Contains(p.GetType())).ToList();

            lstBoxProducts_DataSource = availableProductsNotInBundle.Select(x => new ProductListItem { Value = x, Text = x.GetType().Name }).ToList();
            BindData(lstBoxProducts, lstBoxProducts_DataSource);

            listBoxSelectedProducts_DataSource = _formBundle.Products.Select(x => new ProductListItem { Value = x, Text = x.GetType().Name }).ToList();
            BindData(listBoxSelectedProducts, listBoxSelectedProducts_DataSource);
        }

        List<ProductListItem> lstBoxProducts_DataSource;
        List<ProductListItem> listBoxSelectedProducts_DataSource;

        public Answers Answers { get; set; }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            var productToAdd = (ProductListItem)lstBoxProducts.SelectedItem;
            if (productToAdd == null) return;

            lstBoxProducts_DataSource.Remove(productToAdd);
            listBoxSelectedProducts_DataSource.Add(productToAdd);

            //Refresh
            BindData(lstBoxProducts, lstBoxProducts_DataSource);
            BindData(listBoxSelectedProducts, listBoxSelectedProducts_DataSource);
        }

        private void BindData(ListBox listBox, List<ProductListItem> items)
        {
            listBox.DataSource = null;
            listBox.DataSource = items;
            listBox.DisplayMember = "Text";
        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            var productToRemove = (ProductListItem)listBoxSelectedProducts.SelectedItem;
            if (productToRemove == null) return;

            listBoxSelectedProducts_DataSource.Remove(productToRemove);
            lstBoxProducts_DataSource.Add(productToRemove);

            //Refresh
            BindData(lstBoxProducts, lstBoxProducts_DataSource);
            BindData(listBoxSelectedProducts, listBoxSelectedProducts_DataSource);
        }

        private void showQuestionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var response = _productBundleService.ModifyBundle(Answers.Map(), _formBundle, listBoxSelectedProducts_DataSource.Select(x => x.Value).ToArray());
            if (response.IsValid)
            {
                lblErrors.Text = "";
                _formBundle = response.ResultBundle;
                BindControls();
            }
            else
            {
                var sb = new StringBuilder();
                sb.AppendFormat("{0} should contain these products: \n", response.ResultBundle.GetType().Name);
                response.ResultBundle.Products.ToList().ForEach(v => sb.AppendFormat("* {0}{1}", v.GetType().Name, "\n"));
                lblErrors.Text = sb.ToString(0, sb.Length - 1);
            }
        }
    }
}
