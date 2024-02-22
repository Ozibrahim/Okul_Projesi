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
    public partial class Frm_Ogrenci_Notlar : Form
    {
        public Frm_Ogrenci_Notlar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-I8RD6T2;Initial Catalog=Okul_Projesi;Integrated Security=True");
        public string numara;

        private void Frm_Ogrenci_Notlar_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select DERSAD,SINAV1,SINAV2,SINAV3,PROJE,DURUM FROM TBL_NOT\r\nINNER JOIN TBL_DERS ON TBL_NOT.DERSID=TBL_DERS.DERSID WHERE OGRID=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select OGRAD,OGRSOYAD FROM TBL_OGRENCI WHERE OGRID=@s1",baglanti);
            komut2.Parameters.AddWithValue("@s1", numara);
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                this.Text = dr[0].ToString()+" " + dr[1].ToString();
            }
            baglanti.Close();
            
        }
    }
}
