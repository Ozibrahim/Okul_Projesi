using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Okul_Projesi
{
    public partial class Frm_Sınav_Notlar : Form
    {
        public Frm_Sınav_Notlar()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-I8RD6T2;Initial Catalog=Okul_Projesi;Integrated Security=True");
        DataSet1TableAdapters.TBL_NOTTableAdapter ds = new DataSet1TableAdapters.TBL_NOTTableAdapter();
        int notid;
                

        private void BtnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.NotListesi(int.Parse(txtid.Text));
        }

        private void Frm_Sınav_Notlar_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From TBL_DERS", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbders.DisplayMember = "DERSAD";
            cmbders.ValueMember = "DERSID";
            cmbders.DataSource = dt;
            baglanti.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cmbders.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            notid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtsınav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtsınav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtsınav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtproje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtortalama.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtdurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }

        private void BtnHesapla_Click(object sender, EventArgs e)
        {
            int sinav1, sinav2, sinav3, proje;
            double ortalama;
            // string durum;
            sinav1 = Convert.ToInt16(txtsınav1.Text);
            sinav2 = Convert.ToInt16(txtsınav2.Text);
            sinav3 = Convert.ToInt16(txtsınav3.Text);
            proje = Convert.ToInt16(txtproje.Text);
            ortalama = (sinav1+sinav2+ sinav3+proje)/4;
            txtortalama.Text = ortalama.ToString();
            if (ortalama >= 50)
            {
                txtdurum.Text = "True";
            }
            else
            {
                txtdurum.Text = "False";
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds.NotGuncelle(byte.Parse(cmbders.SelectedValue.ToString()),int.Parse(txtid.Text),byte.Parse(txtsınav1.Text),byte.Parse(txtsınav2.Text),byte.Parse(txtsınav3.Text),byte.Parse(txtproje.Text),decimal.Parse(txtortalama.Text),bool.Parse(txtdurum.Text),notid);
        }
    }
}
