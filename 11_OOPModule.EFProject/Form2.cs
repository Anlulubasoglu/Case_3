using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _11_OOPModule.EFProject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        EgitimKampiDbEFDbEntities db = new EgitimKampiDbEFDbEntities();
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Location.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Location location = new Location();
            location.LocationCity = txtcity.Text;
            location.LocationCountry = txtCountry.Text;
            location.LocationCapacity = byte.Parse(numericUpDown1.Value.ToString());
            location.LocationPrice = decimal.Parse(txtPrice.Text);
            location.DayNight = txtDayNight.Text;
            location.GuideId = int.Parse(comboBox1.SelectedValue.ToString());
            location.LocationName=txtName.Text;
            db.Location.Add(location);
            db.SaveChanges();
            MessageBox.Show("Tur Bilgisi Eklendi", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var deleteValue = db.Location.Find(id);
            db.Location.Remove(deleteValue);
            db.SaveChanges();
            MessageBox.Show("Tur Bilgisi Silindi", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            int id = int.Parse(txtId.Text);
            var updateLocation = db.Location.Find(id);
            updateLocation.LocationCity = txtcity.Text;
            updateLocation.LocationCountry = txtCountry.Text;
            updateLocation.LocationCapacity = byte.Parse(numericUpDown1.Value.ToString());
            updateLocation.LocationPrice = decimal.Parse(txtPrice.Text);
            updateLocation.DayNight = txtDayNight.Text;
            updateLocation.GuideId = int.Parse(comboBox1.SelectedValue.ToString());
            updateLocation.LocationName = txtName.Text;
            db.SaveChanges();
            MessageBox.Show("Tur Bilgisi Güncellendi", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnID_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var values = db.Location.Where(x => x.LocationId == id).ToList();
            dataGridView1.DataSource = values;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            var values = db.Guide.Select(x => new
            {
                FullName = x.GuideName + " " + x.GuideSurName,
                x.GuideId
            }).ToList();
            comboBox1.DisplayMember = "FullName";
            comboBox1.ValueMember= "GuideId";
            comboBox1.DataSource = values;
        }
    }
}
