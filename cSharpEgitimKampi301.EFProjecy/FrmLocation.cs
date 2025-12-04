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
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }

        EgitimKampiEfTravelDbEntities2 db = new EgitimKampiEfTravelDbEntities2();

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.TblLocation.ToList();
            dataGridView1.DataSource = values;
        }

        private void FrmLocation_Load(object sender, EventArgs e) // Form yüklendiğinde tetiklenen olay (Load event handler)
        {
            // 'db' Entity Framework bağlamı (EgitimKampiEfTravelDbEntities2) üzerinden TblGuide tablosuna erişiyoruz.
            // Select ile her bir rehber (guide) için yeni anonim bir nesne oluşturuyoruz:
            //   FullName => rehberin adı + boşluk + soyadı
            //   GuideId  => rehberin kimlik değeri
            // Bu sorgu, ToList() çağrısı ile veritabanından hemen çekilip belleğe alınır (deferred execution sonlandırılır).
            var values = db.TblGuide.Select(x => new
            {
                FullName = x.GuideName + " " + x.GuideSurname, // görüntülenecek tam isim alanı
                x.GuideId                                     // combobox'ın ValueMember'ı olacak kimlik
            }).ToList();

            // comboBox1'de gösterilecek metin alanını belirliyoruz.
            // Buraya atanan string, 'values' içindeki anonim tipteki property adıdır ("FullName").
            cmbGuide.DisplayMember = "FullName";

            // comboBox1'de seçili öğenin arka planda tutacağı değer alanını belirliyoruz.
            // Bu da anonim tip içindeki "GuideId" property'sine karşılık gelir.
            cmbGuide.ValueMember = "GuideId";

            // ComboBox'ın veri kaynağını atıyoruz. Bu atama, UI'yi verilen liste ile doldurur.
            // Sonrasında comboBox1.SelectedValue üzerinden seçili rehberin GuideId'sine ulaşabilirsiniz.
            cmbGuide.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           TblLocation location = new TblLocation();
            location.Capacity = byte.Parse(nmrCapacity.Value.ToString());
            location.City = txtCity.Text;
            location.Country = txtCountry.Text;
            location.Price = decimal.Parse(txtPrice.Text);
            location.DayNight = txtDayNight.Text;
            location.GuideId = int.Parse(cmbGuide.SelectedValue.ToString());
            db.TblLocation.Add(location);
            db.SaveChanges();
            MessageBox.Show("Ekleme Başarılı");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var location = db.TblLocation.Find(id);
            db.TblLocation.Remove(location);    
            db.SaveChanges();
            MessageBox.Show("Silme Başarılı");
        }

        private void btdUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text); // ID değerini TextBox'tan al
            var updatedLocation = db.TblLocation.Find(id);// Veritabanından ilgili kaydı bul

            updatedLocation.DayNight = txtDayNight.Text; // Güncelleme işlemleri
            updatedLocation.Price = decimal.Parse(txtPrice.Text); // Güncelleme işlemleri
            updatedLocation.Capacity = byte.Parse(nmrCapacity.Value.ToString()); // Güncelleme işlemleri
            updatedLocation.City = txtCity.Text; // Güncelleme işlemleri
            updatedLocation.Country = txtCountry.Text; // Güncelleme işlemleri
            updatedLocation.GuideId = int.Parse(cmbGuide.SelectedValue.ToString()); // Güncelleme işlemleri
            db.SaveChanges(); // Değişiklikleri veritabanına kaydet
            MessageBox.Show("Güncelleme Başarılı");
        }
    }
}
