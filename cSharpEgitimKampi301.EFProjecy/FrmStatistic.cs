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
    public partial class FrmStatistic : Form
    {
        public FrmStatistic()
        {
            InitializeComponent();
        }
        EgitimKampiEfTravelDbEntities2 db = new EgitimKampiEfTravelDbEntities2();
        private void FrmStatistic_Load(object sender, EventArgs e)
        {


            lblLocationCount.Text = db.TblLocation.Count().ToString();

            lblSumCapacity.Text = db.TblLocation.Sum(x => x.Capacity).ToString();

            lblGuideCount.Text = db.TblGuide.Count().ToString();

            lblAverageCapacity.Text = db.TblLocation.Average(x => x.Capacity).ToString();

            lblAverageLocationPrice.Text = db.TblLocation.Average(x => x.Price).ToString() + " ₺";

            int lastCountryId = db.TblLocation.Max(x => x.LocationId);
            lblLastCountryName.Text = db.TblLocation.Where(x => x.LocationId == lastCountryId).Select(y => y.Country).FirstOrDefault();

            lblCapadociaCapacity.Text = db.TblLocation.Where(x => x.City == "Kapadokya").Select(y => y.Capacity).FirstOrDefault().ToString();

            lblAverageCapacityAverage.Text = db.TblLocation.Where(x => x.Country == "Türkiye").Average(y => y.Capacity).ToString();

            var CorumGuideId = db.TblLocation.Where(x => x.City == "Çorum").Select(y => y.GuideId).FirstOrDefault();

            lblCorumGuideName.Text = db.TblGuide.Where(x => x.GuideId == CorumGuideId).Select(y => y.GuideName + " " + y.GuideSurname).FirstOrDefault();

            var maxCapacity = db.TblLocation.Max(x => x.Capacity);
            lblMaxCapacityTour.Text = db.TblLocation.Where(x => x.Capacity == maxCapacity).Select(y => y.City).FirstOrDefault();

            var maxPriceTour = db.TblLocation.Max(x => x.Price);
            lblMaxPriceTour.Text = db.TblLocation.Where(x => x.Price == maxPriceTour).Select(y => y.City).FirstOrDefault();

            var guideIdByMehmetEryucel = db.TblGuide.Where(x => x.GuideName == "Mehmet" && x.GuideSurname == "Eryücel").Select(y => y.GuideId).FirstOrDefault();

            lblMehmetEryucelTourCount.Text = db.TblLocation.Where(x => x.GuideId == guideIdByMehmetEryucel).Count().ToString();

        }

        
    }
}
