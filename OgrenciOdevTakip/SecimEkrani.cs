using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrenciOdevTakip
{
    public partial class SecimEkrani : Form
    {
        public SecimEkrani()
        {
            InitializeComponent();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OgrenciBilgileri ogrenciBilgileri = new OgrenciBilgileri();
            ogrenciBilgileri.ShowDialog();
            this.Close();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Taksit taksit = new Taksit();
            taksit.ShowDialog();
           



        }
    }
}
