using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cSharpEgitimKampi301.EFProjecy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        EgitimKampiEfTravelDbEntities2 db = new EgitimKampiEfTravelDbEntities2(); //DbContext sınıfından db nesnesi türetildi Tablolarımıza erişim sağlamak için. ortak alana yazdık her birine tek tek yazmamak için.

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.TblGuide.ToList(); //TblGuide tablosundaki tüm veriler çekildi
            dataGridView1.DataSource = values; //Veriler DataGridView a aktarildi.


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TblGuide newguide = new TblGuide(); // tabloya veri eklemek için tabloyu temsil eden sınıftan nesne türetmemiz gerekiyor.
            newguide.GuideName = txtName.Text; //textBox lardan veriler alındı
            newguide.GuideSurname = txtSurname.Text;//textBox lardan veriler alındı
            db.TblGuide.Add(newguide); //veri eklendi veritabanına
            db.SaveChanges(); // değişiklikler kaydedildi
            MessageBox.Show("Rehber Eklendi"); //kullanıcıya bilgi verildi
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text); //textBox tan id alındı
            var removeValue = db.TblGuide.Find(id); //id ye göre ilgili kayıt bulunur
            db.TblGuide.Remove(removeValue); //kayıt silindi
            db.SaveChanges(); //değişiklikler kaydedildi
            MessageBox.Show("Rehberden Silindi"); //kullanıcıya bilgi verildi
        }

        private void btdUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text); //textBox tan id alındı

            var updateValue = db.TblGuide.Find(id); //id ye göre ilgili kayıt bulunur, bu metot ilgili id yi bulur ve o satırdaki tüm verileri getirir kullanıcı adı ve soyadı gibi.

            updateValue.GuideName = txtName.Text; // güncellenecek alanlar
            updateValue.GuideSurname = txtSurname.Text; // güncellenecek alanlar
            db.SaveChanges(); // değişiklikler kaydedildi
            MessageBox.Show("Rehber Güncellendi"); //kullanıcıya bilgi verildi
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text); //textBox tan id alındı
            var values = db.TblGuide.Where(x => x.GuideId == id).ToList(); //id ye göre ilgili kayıtlar çekildi // Where metodu ile birden fazla kayıt dönebilir bu yüzden ToList ile listeye çevirdik.
            dataGridView1.DataSource = values; //Veriler DataGridView a aktarildi.

        }
    }
}
