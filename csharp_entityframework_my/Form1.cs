using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharp_entityframework_my
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        EntityUrunDBEntities db = new EntityUrunDBEntities();

        private void btnlistele_Click(object sender, EventArgs e)
        {
            var kategoriler = db.kategori_tbl.ToList();
            dataGridView1.DataSource=kategoriler;
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            kategori_tbl t = new kategori_tbl();
            t.categoryad = txtad.Text;
            db.kategori_tbl.Add(t);
            db.SaveChanges();
            MessageBox.Show("Kategori Eklendi");

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtno.Text);
            var ktgr = db.kategori_tbl.Find(x);
            db.kategori_tbl.Remove(ktgr);
            db.SaveChanges();
            MessageBox.Show("Kategori Silindi");

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtno.Text);
            var ktgr = db.kategori_tbl.Find(x);
            ktgr.categoryad = txtad.Text;
            db.SaveChanges();
            MessageBox.Show("Kategori Güncellendi");


        }
    }
}
