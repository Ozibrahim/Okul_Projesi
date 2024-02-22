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
    public partial class Frm_Kulup : Form
    {
        public Frm_Kulup()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-I8RD6T2;Initial Catalog=Okul_Projesi;Integrated Security=True");
        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_KULUP", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Frm_Kulup_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBL_KULUP (KULUPAD) values (@p1)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtKululpAd.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulup Listeye Eklendi","Ekleme",MessageBoxButtons.OK,MessageBoxIcon.Information);
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKulupid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtKululpAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete From TBL_KULUP Where KULUPID=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", txtKulupid.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Update TBL_KULUP  SET KULUPAD=@p1 where KULUPID=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", txtKululpAd.Text);
            komut.Parameters.AddWithValue("@p2", txtKulupid.Text);
            komut.ExecuteNonQuery();
            baglanti.Close() ;
            MessageBox.Show("Güncelleme Yapıldı.");
            listele();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Gray;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
        }
    }
}
