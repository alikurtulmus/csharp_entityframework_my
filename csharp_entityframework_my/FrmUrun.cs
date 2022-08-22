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
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }

        EntityUrunDBEntities db = new EntityUrunDBEntities();


        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.urun_tbl 
                                        select new { x.urunid, x.urunad, x.urunmarka, x.stok, x.fiyat, x.kategori_tbl.categoryad, x.durum }).ToList();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            urun_tbl u = new urun_tbl();
            u.urunad = txtad.Text;
            u.urunmarka = txtmarka.Text;
            u.stok = short.Parse(txtstok.Text);
            u.kategori = int.Parse(cmbkategori.SelectedValue.ToString());
            u.fiyat = decimal.Parse(txtfiyat.Text);
            u.durum = true;
            db.urun_tbl.Add(u);
            db.SaveChanges();
            MessageBox.Show("Ürün Eklendi");
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtno.Text);
            var urun = db.urun_tbl.Find(x);
            db.urun_tbl.Remove(urun);
            db.SaveChanges();
            MessageBox.Show("Ürün Silindi");
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            int x=Convert.ToInt32(txtno.Text);
            var u = db.urun_tbl.Find(x);
            u.urunad = txtad.Text;
            u.urunmarka = txtmarka.Text;
            u.stok = short.Parse(txtstok.Text);
            u.kategori = int.Parse(cmbkategori.Text);
            u.fiyat = decimal.Parse(txtfiyat.Text);
            u.durum = bool.Parse(txtdurum.Text);
            db.SaveChanges();
            MessageBox.Show("Ürün Güncellendi");

        }

        private void FrmUrun_Load(object sender, EventArgs e)
        {
            var kategoriler = (from x in db.kategori_tbl
                               select new
                               { x.categoryid, 
                                 x.categoryad }
                                ).ToList();

            cmbkategori.ValueMember = "categoryid";
            cmbkategori.DisplayMember = "categoryad";
            cmbkategori.DataSource = kategoriler;

        }
    }
}
