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
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EntityUrunDBEntities db = new EntityUrunDBEntities();
            var sorgu = from x in db.admin_tbl where x.Kullanıcı == textBox1.Text && x.Sifre == textBox2.Text select x;
            if(sorgu.Any())
            {
                AnaForm fr =new AnaForm();
                fr.Show();
            }
            else
            {
                MessageBox.Show("Hatalı giriş!");
            }
        }
    }
}
