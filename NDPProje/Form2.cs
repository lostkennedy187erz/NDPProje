//Ad Soyad : İBRAHİM ÇELEN
//Numara : B201200014
//Bölüm : BİLİŞİM SİSTEMLERİ MÜHENDİSLİĞİ

using System;
using ProjeLibrary;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjeLibrary.Somut;
using ProjeLibrary.Enum;

namespace NDPProje
{
    public partial class Form2 : Form
    {
        public int sure;
        private readonly Oyun _oyun;
        public Form2()
        {
            InitializeComponent();
            _oyun = new Oyun(arabaPanel);
            label2.Text = Form1.adSoyad;
            label3.Text = Form1.urunAd;
            label11.Text = Form1.urunMiktari;
            kalansurelbl.Text = "120";
            sure = Convert.ToInt32(kalansurelbl.Text);

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            _oyun.Baslat();
            KalanSure.Start();
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            int yatay = arabapicbox.Location.X;
            if(e.KeyCode==Keys.Left && arabapicbox.Left > 0)
            {
                yatay -= 30;
            }
            if (e.KeyCode == Keys.Right && arabapicbox.Width + arabapicbox.Left <595 )
            {
                yatay += 30;
            }
            arabapicbox.Location = new Point(yatay, 0);
        }

        private void KalanSure_Tick(object sender, EventArgs e)
        {
            sure = sure - 1;
            kalansurelbl.Text = Convert.ToString(sure);
        }

        private void malzemeTimer_Tick(object sender, EventArgs e)
        {

        }
    }
}
