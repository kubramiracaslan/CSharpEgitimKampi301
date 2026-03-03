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

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        CSharpEgitimKampiEntityFrameworkDB db = new CSharpEgitimKampiEntityFrameworkDB();
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Guide.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Guide guide = new Guide();
            guide.Name = txtName.Text;
            guide.Surname = txtSurname.Text;
            guide.City = txtCity.Text;
            db.Guide.Add(guide);
            db.SaveChanges();
            MessageBox.Show("Rehber eklendi.");
            db.SaveChanges();
            MessageBox.Show("Rehber eklendi.");
        }
    }
}
