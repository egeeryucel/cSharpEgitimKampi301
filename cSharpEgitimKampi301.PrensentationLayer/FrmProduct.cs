using cSharpEgitimKampi301.BusinessLayer.Abstract;
using cSharpEgitimKampi301.BusinessLayer.Concrete;
using cSharpEgitimKampi301.DataAccessLayer.EntityFramework;
using cSharpEgitimKampi301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cSharpEgitimKampi301.PrensentationLayer
{
    public partial class FrmProduct : Form
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public FrmProduct()
        {
            InitializeComponent();
            _productService = new ProductManager(new EfProductDal());
            _categoryService = new CategoryManager(new EfCategoryDal());
        }

        private void btnList_Click(object sender, EventArgs e) // Ürünleri Listeleme
        {
            var values = _productService.TGetAll();
            dataGridView1.DataSource = values;
        }
        private void btnList2_Click(object sender, EventArgs e)
        {
            var values = _productService.TGetProductsWithCategory();
            dataGridView1.DataSource = values;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductId.Text);
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            MessageBox.Show("Product Deleted");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.CategoryId = int.Parse(cmbCategory.SelectedValue.ToString());
            product.ProductPrice = decimal.Parse(txtProductPrice.Text);
            product.ProductName = txtProductName.Text;
            product.ProductDescription = txtDescription.Text;
            product.ProductStock = int.Parse(txtProductStok.Text);
            _productService.TInsert(product);
            MessageBox.Show("Product Added");
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductId.Text);
            var value = _productService.TGetById(id);
            dataGridView1.DataSource = value;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductId.Text);
            var value = _productService.TGetById(id);
            value.CategoryId = int.Parse(cmbCategory.SelectedValue.ToString());
            value.ProductName = txtProductName.Text;
            value.ProductStock = int.Parse(txtProductStok.Text);
            value.ProductPrice = decimal.Parse(txtProductPrice.Text);
            value.ProductDescription = txtDescription.Text;
            _productService.TUpdate(value);
            MessageBox.Show("Product Updated");
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
                var values = _categoryService.TGetAll();
            cmbCategory.DataSource = values;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryId";
        }
    }
}
