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
    public partial class Login : Form
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        public void sifredogrulama()
        {
            

        }

        private void lbldogrulama_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sifredogrula();
           




        }
        public void sifredogrula()
        {
            string sorgu = "SELECT * FROM tblUser1 where usr=@user AND sifre=@pass";
            con = new SqlConnection("server=.; Initial Catalog=dbLogin;Integrated Security=SSPI");
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@user", txtKullanıcıAdi.Text);
            cmd.Parameters.AddWithValue("@pass", txtSifre.Text);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
                
            {
                SecimEkrani secimEkrani = new SecimEkrani();

                secimEkrani.ShowDialog();
                lbldogrulama.Text = " ";


                
            }
            else
            {
                lbldogrulama.ForeColor = Color.Red;
                lbldogrulama.Font = new Font("Georgia", 10, FontStyle.Bold);
                lbldogrulama.Text = "Kullanici adi ve şifrenizi kontrol ediniz";

               
                

            }
            con.Close();
        }
    }
}
