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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Frm_Ogrenci_Notlar frm = new Frm_Ogrenci_Notlar();
            frm.numara = textBox1.Text; 
            frm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Frm_Ogretmen frm = new Frm_Ogretmen();
            frm.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
