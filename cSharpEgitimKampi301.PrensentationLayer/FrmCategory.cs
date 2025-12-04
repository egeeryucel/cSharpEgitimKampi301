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
    public partial class FrmCategory : Form
    {
        private readonly ICategoryService _categoryService; 



        public FrmCategory()

        {
            _categoryService = new CategoryManager(new EfCategoryDal()); // Dependency Injection
            InitializeComponent();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var categoryValues = _categoryService.TGetAll();
            dataGridView1.DataSource = categoryValues;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.CategoryName = txtCategoryName.Text;
            category.CategoryStatus = true;
            _categoryService.TInsert(category);
            MessageBox.Show("Category Added");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryID.Text);
            var deletedValue = _categoryService.TGetById(id);
            _categoryService.TDelete(deletedValue);
            MessageBox.Show("Category Deleted");
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryID.Text);
            var values = _categoryService.TGetById(id);
            dataGridView1.DataSource = values;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int updateId = int.Parse(txtCategoryID.Text);
            var updatedValue = _categoryService.TGetById(updateId);
            updatedValue.CategoryName = txtCategoryName.Text;
            updatedValue.CategoryStatus = true;
            _categoryService.TUpdate(updatedValue);
            MessageBox.Show("Category Updated");

        }
    }
}
