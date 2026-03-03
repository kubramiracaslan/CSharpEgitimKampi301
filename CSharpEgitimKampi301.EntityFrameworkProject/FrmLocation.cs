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
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }

        CSharpEgitimKampiEntityFrameworkDBEntities db = new CSharpEgitimKampiEntityFrameworkDBEntities();
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Location.ToList();
            dataGridView1.DataSource = values;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmLocation_Load(object sender, EventArgs e)
        {
            //DB'deki guide tablosundaki verileri çekip combobox'a dolduracağız.
            //Bu kod, veritabanına gidip "Bana bütün tabloyu getirme, sadece şu iki parçayı birleştirip getir" demektir.
            /*
             * db.Guide	                  --          "Rehberler tablosuna git."
               .Select(x => ...)	      --          "Tablodaki her bir satırı (x) al ve onu şu kalıba sok."
               new { ... }	              --          Anonymous Type (İsimsiz Tip): O an uydurduğumuz geçici bir 
                                                    kutu oluşturur.
               FullName = x.GuideName + " " + x.GuideSurname	--  Rehberin adını ve soyadını araya boşluk koyarak     birleştirir ve adını FullName koyar.
               x.GuideId	              --           Rehberin ID'sini olduğu gibi kutuya atar.
               .ToList()	              --          "Bu seçtiğim listeyi oluştur ve hafızaya (RAM) getir
             * 
             */
            var values = db.Guide.Select(x => new
            {
                FullName = x.GuideName + " " + x.GuideSurname,
                x.GuideId
            }).ToList();

            cbGuide.DisplayMember = "FullName";
            cbGuide.ValueMember = "GuideId";
            cbGuide.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Location location = new Location();
            location.Capacity = byte.Parse(nuCapacity.Value.ToString());
            location.City = txtCity.Text;
            location.Country = txtCountry.Text; 
            location.Price = decimal.Parse(txtPrice.Text);
            location.DayNight = txtDayNight.Text;
            location.GuideId = int.Parse(cbGuide.SelectedValue.ToString());
            db.Location.Add(location);
            db.SaveChanges();
            MessageBox.Show("Yeni lokasyon eklendi.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var deleteValue = db.Location.Find(id);
            db.Location.Remove(deleteValue);
            db.SaveChanges();
            MessageBox.Show("Lokasyon silindi.");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var updateValue = db.Location.Find(id);
            updateValue.DayNight = txtDayNight.Text;
            updateValue.Price = decimal.Parse(txtPrice.Text);
            updateValue.Capacity = byte.Parse(nuCapacity.Value.ToString());
            updateValue.Country = txtCountry.Text;
            updateValue.City = txtCity.Text;
            updateValue.GuideId = int.Parse(cbGuide.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Lokasyon güncellendi.");
        }
    }
}
