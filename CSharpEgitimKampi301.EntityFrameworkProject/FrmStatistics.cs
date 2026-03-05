using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EntityFrameworkProject
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }


        CSharpEgitimKampiEntityFrameworkDBEntities db = new CSharpEgitimKampiEntityFrameworkDBEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {

        }        
        
        private void label2_Click(object sender, EventArgs e)
        {
            lblLocationCount.Text = db.Location.Count().ToString(); 

            lblSumCapacity.Text = db.Location.Sum(x => x.Capacity).ToString();

            lblGuideCount.Text = db.Guide.Count().ToString();

            lblAvgCapacity.Text = db.Location.Average(x => x.Capacity).ToString();

            lblAvgLocationPrice.Text = db.Location.Average(x => (decimal?)x.Price)?.ToString("0.00") + "₺";

            int lastcountryId = db.Location.Max(x => x.LocationId);

            lblLastCountryName.Text = db.Location.Where(x => x.LocationId == lastcountryId).Select(y => y.Country).FirstOrDefault();

            lblEgeLocationCapacity.Text = db.Location.Where(x => x.City == "Ege").FirstOrDefault().ToString(); 

            lblAvgCapacityTurkey.Text = db.Location.Where(x => x.Country == "Türkiye").Average(y => y.Capacity).ToString();

            int romeGuideId = db.Guide.Where(x => x.GuideName == "Roma").Select(y => y.GuideId).FirstOrDefault();
            lblRomeGuideName.Text = db.Guide.Where(x => x.GuideId == romeGuideId).Select(y => y.GuideName + " " + y.GuideSurname).FirstOrDefault().ToString();

            var maxCapacity = db.Location.Max(x => x.Capacity);
            lblMaxLocationCapacity.Text = db.Location.Where(x => x.Capacity == maxCapacity).Select(y => y.City).FirstOrDefault().ToString();

            var maxPrice = db.Location.Max(x => x.Price);
            lblMaxLocationPrice.Text = db.Location.Where(x => x.Price == maxPrice).Select(y => y.City).FirstOrDefault().ToString();

            var aliAslanTourCount = db.Guide.Where(x => x.GuideName == "Ali" && x.GuideSurname == "Aslan").Select(y => y.GuideId).FirstOrDefault();
            lblAliAslanTourCount.Text= db.Location.Where(x => x.GuideId == aliAslanTourCount).Count().ToString();

        }
    }
}
