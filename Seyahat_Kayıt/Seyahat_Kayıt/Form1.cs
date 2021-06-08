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

namespace Seyahat_Kayıt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // bağlantı oluşturup.
        SqlConnection baglanti = new SqlConnection (@"Data Source = DESKTOP-0AV1K5O\SQLEXPRESS; Initial Catalog = CheckPassengers;Integrated Security = True");
        // data dan seferbilgisini alıp form içindeki datagride koyuyorum.
        void seferlistesi()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tblseferbılgı", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // kaydetme işlemini yapacağım yerleri yazıyorum.
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tblpassengers (ad,soyad,telefon,tc,maıl) values (@p1,@p2,@p3,@p4,@p6) ", baglanti );
            // Formlardan girilecek değerlerin server içinde hangi parametreye kaydolacağını yazıyorum.
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTel.Text);
            komut.Parameters.AddWithValue("@p4", mskTc.Text);
            komut.Parameters.AddWithValue("@p6", txtMail.Text);
            //İşlemi gerçekleştir diyorum.
            komut.ExecuteNonQuery();
            baglanti.Close();   
            MessageBox.Show("Yolcu Bilgisi Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnKaptan_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tblkaptan (kaptanno,adsoyad,telefon) values (@p1,@p2,@p3)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtKaptanNo.Text);
            komut.Parameters.AddWithValue("@p2", txtKaptanAd.Text);
            komut.Parameters.AddWithValue("@p3", mskKaptanTel.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kaptan Bilgisi Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSeferOluştur_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tblseferbılgı (kalkıs,varıs,tarıh,saat,kaptan,fıyat) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtKalkis.Text);
            komut.Parameters.AddWithValue("@p2", txtVaris.Text);
            komut.Parameters.AddWithValue("@p3", mskTarih.Text);
            komut.Parameters.AddWithValue("@p4", mskSaat.Text);
            komut.Parameters.AddWithValue("@p5", mskKaptan.Text);
            komut.Parameters.AddWithValue("@p6", txtFiyat.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Sefer Bilgisi Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            seferlistesi();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            seferlistesi();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // datagridin 0. dizesinden bilgiyi al
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            // datagridin satırlarından seçtiğim satırın 0. hücresinden alıp istediğim yere yaz.
            txtSeferNumara.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
        }
        // koltuklara bastığımda koltuk numarasını koltukno textine yazacak.
        private void btn1_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "1";

        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "2";

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "3";

        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "4";

        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "5";

        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "6";

        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "7";

        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "8";

        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "9";

        }

        private void btnRezervasyon_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tblseferdetay (seferno,yolcutc,koltuk) values (@p1, @p2, @p3)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtSeferNo.Text);
            komut.Parameters.AddWithValue("@p2", mskYolcuTc.Text);
            komut.Parameters.AddWithValue("@p3", txtKoltukNo.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Rezervasyon Oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            seferlistesi();
        }
    }
}
