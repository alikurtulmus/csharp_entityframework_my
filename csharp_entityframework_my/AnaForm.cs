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
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmUrun frmu=new FrmUrun();
            frmu.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frmk = new Form1();
            frmk.Show();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            FrmIstatistik fri = new FrmIstatistik();
            fri.Show();

        }
    }
}
