using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Okul_Projesi
{
    public partial class Frm_Ogretmen : Form
    {
        public Frm_Ogretmen()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Frm_Kulup frm = new Frm_Kulup();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_Dersler frm = new Frm_Dersler();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Frm_Ogrenci frm = new Frm_Ogrenci();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Frm_Sınav_Notlar fr = new Frm_Sınav_Notlar();
            fr.Show();
        }
    }
}
