using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11_OOPModule.EFProject
{
    public partial class FrmStatistic : Form
    {
        public FrmStatistic()
        {
            InitializeComponent();
        }
        EgitimKampiDbEFDbEntities db = new EgitimKampiDbEFDbEntities();
        private void FrmStatistic_Load(object sender, EventArgs e)
        {
            #region ToplamLokasyonSayısı

            lblCount.Text = db.Location.Count().ToString();
            lblCapacity.Text = db.Location.Sum(x => x.LocationCapacity).ToString();
            lblGuide.Text = db.Guide.Count().ToString();
            lblAvgCapacity.Text=db.Location.Average(x => x.LocationCapacity).ToString();
            lblAvgPrice.Text=db.Location.Average(x => x.LocationPrice).Value.ToString("F2") + " ₺";

            int lastContryId = db.Location.Max(x => x.LocationId);
            lblLastContry.Text=db.Location.Where(x=>x.LocationId==lastContryId).Select(y=>y.LocationCountry).FirstOrDefault();

            lblRomaTour.Text = db.Location.Where(x => x.LocationCity == "Roma").Select(y => y.LocationCapacity).FirstOrDefault().ToString();

            lblTurkiyeAvgCapacity.Text = db.Location.Where(x => x.LocationCountry == "TÜRKİYE").Average(y => y.LocationCapacity).ToString();

            var guideId =db.Location.Where(x=>x.LocationCity=="Roma").Select(y=>y.GuideId).FirstOrDefault();

            lblRomaGuide.Text=db.Guide.Where(x=>x.GuideId==guideId).Select(y=>y.GuideName +" " + y.GuideSurName).FirstOrDefault().ToString();
            var maxCapacity = db.Location.Max(x => x.LocationCapacity);
            lblMaxCapacityTour.Text=db.Location.Where(x=>x.LocationCapacity==maxCapacity).Select(y=>y.LocationCity).FirstOrDefault().ToString();

            var maxPriceTour = db.Location.Max(x => x.LocationPrice);
            lblMaxPriceTour.Text = db.Location.Where(x => x.LocationPrice == maxPriceTour).Select(y => y.LocationCity).FirstOrDefault().ToString();

            var guideIdByNameAnıl=db.Guide.Where(x=>x.GuideName=="Anıl").Select(y=>y.GuideId).FirstOrDefault();
            lblAnılTourCount.Text = db.Location.Where(x => x.GuideId == guideIdByNameAnıl).Count().ToString();
            #endregion
        }
    }
}
