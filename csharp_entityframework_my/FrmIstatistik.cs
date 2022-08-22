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
    public partial class FrmIstatistik : Form
    {
        public FrmIstatistik()
        {
            InitializeComponent();
        }

        EntityUrunDBEntities db = new EntityUrunDBEntities();

        private void FrmIstatistik_Load(object sender, EventArgs e)
        {
            lblks.Text = db.kategori_tbl.Count().ToString();
            lblus.Text = db.urun_tbl.Count().ToString();
            lblams.Text = db.musteri_tbl.Count(x=>x.musteridurum==true).ToString();
            lblpms.Text = db.musteri_tbl.Count(x => x.musteridurum == false).ToString();
            lblts.Text = db.urun_tbl.Sum(y => y.stok).ToString();
            lblkt.Text = db.satis_tbl.Sum(z => z.fiyat).ToString()+"TL";
            lblepu.Text = (from x in db.urun_tbl orderby x.fiyat descending select x.urunad).FirstOrDefault();
            lblecu.Text = (from x in db.urun_tbl orderby x.fiyat ascending select x.urunad).FirstOrDefault();
            lblbes.Text = db.urun_tbl.Count(x => x.kategori == 1).ToString();
            lblss.Text= (from x in db.musteri_tbl select x.musterisehir).Distinct().Count().ToString();
            lbltls.Text= db.urun_tbl.Count(x=>x.urunad=="Laptop").ToString();
            //lblefum.Text = db.markagetir().FirstOrDefault().ToString();
           
        }


    }
}
