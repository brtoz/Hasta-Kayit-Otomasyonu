using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaKayitOtomasyonu
{
    public partial class Menü : Form
    {
        public Menü()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HastaKayit hastakayit = new HastaKayit();
            hastakayit.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Randevu_Al randevu_al = new Randevu_Al();
            randevu_al.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TeshisBilgileri teshis_bilgileri = new TeshisBilgileri();
            teshis_bilgileri.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Muayene muayene = new Muayene();
            muayene.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Recete recete = new Recete();
            recete.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            HastaKayitGörüntüle hastakayitgörüntüle = new HastaKayitGörüntüle();
            hastakayitgörüntüle.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            RandevuGörüntüle randevugörüntüle = new RandevuGörüntüle();
            randevugörüntüle.Show();
        }

        private void Menü_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            TeshisGörüntüle tehisgörüntüle = new TeshisGörüntüle();
            tehisgörüntüle.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MuayeneGörüntüle muayenegörüntüle = new MuayeneGörüntüle();
            muayenegörüntüle.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ReceteGörüntüle recetegörüntüle = new ReceteGörüntüle();
            recetegörüntüle.Show();
        }
    }
}
