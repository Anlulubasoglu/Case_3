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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        EgitimKampiDbEFDbEntities db = new EgitimKampiDbEFDbEntities();
        private void btnList_Click(object sender, EventArgs e)
        {
            
            var values =db.Guide.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Guide guide = new Guide();
            guide.GuideName = txtName.Text;
            guide.GuideSurName = txtSurname.Text;
            db.Guide.Add(guide);
            db.SaveChanges();
            MessageBox.Show("Rehber eklendi");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var deleteValue = db.Guide.Find(id);
            db.Guide.Remove(deleteValue);
            db.SaveChanges();
            MessageBox.Show("Rehber Kaydı Silindi");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var updateValue = db.Guide.Find(id);
            updateValue.GuideName = txtName.Text;
            updateValue.GuideSurName = txtSurname.Text;
            db.SaveChanges();
            MessageBox.Show("Rehber Güncellendi","UYARI",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnID_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var values = db.Guide.Where(x => x.GuideId == id).ToList();
            dataGridView1.DataSource = values;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
