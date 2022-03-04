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


namespace OgrenciOdevTakip
{
    public partial class OgrenciBilgileri : Form
    {
        SqlConnection baglan = new SqlConnection("server=.; Initial Catalog=dbLogin;Integrated Security=SSPI");

        SqlCommand kmt = new SqlCommand();
        DataTable tablo = new DataTable();
        SqlDataAdapter adtr = new SqlDataAdapter();




        public OgrenciBilgileri()
        {
            InitializeComponent();
            baglan.Open();
            listele();
        }

        public void listele()
        {


            tablo.Clear();
            adtr = new SqlDataAdapter(" Select * from ogr ", baglan);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;



        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)
                    baglan.Open();
                // Bağlantımızı kontrol ediyoruz, eğer kapalıysa açıyoruz.
                string kayit = "insert into ogr(adi,soyadi,sinifi,ucreti,taksitsayisi,Adres,velitelefon,ceptelefonu,kayittarihi) values (@adi,@soyadi,@sinifi,@ucreti,@taksitsayisi,@adres,@velitelefon,@ceptelefonu,@kayittarihi)";
                // müşteriler tablomuzun ilgili alanlarına kayıt ekleme işlemini gerçekleştirecek sorgumuz.
                SqlCommand komut = new SqlCommand(kayit, baglan);
                komut.Parameters.AddWithValue("@adi", txtAd.Text);
                komut.Parameters.AddWithValue("@soyadi", txtSoyad.Text);
                komut.Parameters.AddWithValue("@sinifi", Convert.ToInt32(txtsınıf.Text));
                //komut.Parameters.AddWithValue("@cinsiyeti", txtcinsiyet.Text); ,cinsiyeti,ucreti,taksitsayisi, @cinsiyeti,@ucreti,@taksitsayisi,
                komut.Parameters.AddWithValue("@ucreti", Convert.ToInt32(txtUcret.Text));
                komut.Parameters.AddWithValue("@taksitsayisi", Convert.ToInt32(txtTaksitSayisi.Text));
                komut.Parameters.AddWithValue("@velitelefon", txttel.Text);
                komut.Parameters.AddWithValue("@adres", txtAdres.Text);
                komut.Parameters.AddWithValue("@ceptelefonu", txtOgrencitel.Text);
                komut.Parameters.AddWithValue("@kayittarihi", dateTimePicker1.Value);
                //Parametrelerimize Form üzerinde ki kontrollerden girilen verileri aktarıyoruz.
                komut.ExecuteNonQuery();
                //Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.
                baglan.Close();
                MessageBox.Show("Öğrenci Kayıt İşlemi Gerçekleşti.");
                txtsınıf.Clear();
                txtSoyad.Clear();
                txtAd.Clear();
                listele();

            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
        }

           private void btnOgrenciSil_Click(object sender, EventArgs e)
        {
            if (baglan.State == ConnectionState.Open)
            {

                baglan.Close();
            }

            baglan.Open();
            SqlCommand verisil = new SqlCommand("delete from ogr where numarasi = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'", baglan);
            verisil.ExecuteNonQuery();
            baglan.Close();


            MessageBox.Show("İşleminiz başarılı");
            listele();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglan.Open();
            kmt = new SqlCommand("UPDATE ogre SET adi='" + txtAd.Text + "',soyadi='" + txtSoyad.Text + "',sinifi='" + Convert.ToInt32(txtsınıf.Text) + "',adres='" + txtAdres.Text + "',odeme_turu='" , baglan);
            kmt.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("İşleminiz başarılı");
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SecimEkrani secimEkrani = new SecimEkrani();
            secimEkrani.Show();
            this.Close();
            
        }
    }
}


