using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Okul_Projesi
{
    public partial class Frm_Ogrenci : Form
    {
        public Frm_Ogrenci()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-I8RD6T2;Initial Catalog=Okul_Projesi;Integrated Security=True");
        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        void listele()
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
        }
        private void Frm_Ogrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From TBL_KULUP", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbKulup.DisplayMember = "KULUPAD";
            cmbKulup.ValueMember = "KULUPID";
            cmbKulup.DataSource = dt;
            baglanti.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        string c = "";
        private void BtnEkle_Click(object sender, EventArgs e)
        {
                       
            ds.OgrenciEkle(txtad.Text, txtsoyad.Text, byte.Parse(cmbKulup.SelectedValue.ToString()), c);
            MessageBox.Show("öğrenci eklendi");
            listele();
            

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds.OgrenciGuncelle(txtad.Text,txtsoyad.Text,byte.Parse(cmbKulup.SelectedValue.ToString()),c,int.Parse(txtid.Text));
            listele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(txtid.Text));
            listele();


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmbKulup.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            c = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            if (c == "Erkek")
            {
                radioButton1.Checked = true;
            }
            if (c == "Kız")
            {
                radioButton2.Checked = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                c = "Erkek";
            }
         
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                c = "Kız";
            }
           
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciAra(txtAra.Text);
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            listele();
        }
    }
}
