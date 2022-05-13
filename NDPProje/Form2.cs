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
        int malzemeHiz = 6;
        Random rnd = new Random();
        public int tekerpuan;
        public int motorpuan;
        public int benzinpuan;
        private readonly Oyun _oyun;
        public Form2()
        {
            InitializeComponent();
            benzinpicbox.Top = rnd.Next(1,200) * -1;
            tekerlekpicbox.Top = rnd.Next(1, 500) * -1;
            motorpicbox.Top = rnd.Next(1, 700) * -1;
            _oyun = new Oyun(oyunPanel);
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
            malzemeTimer.Start();
            _oyun.Topla();
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            int yatay = arabapicbox.Location.X;
            if(e.KeyCode==Keys.Left && arabapicbox.Left > 15)
            {
                yatay -= 30;
            }
            if (e.KeyCode == Keys.Right && arabapicbox.Width + arabapicbox.Left <570)
            {
                yatay += 30;
            }
            arabapicbox.Location = new Point(yatay,530);
            if(e.KeyCode == Keys.P)
            {
                KalanSure.Stop();
                malzemeTimer.Stop();
            }
            else if (e.KeyCode == Keys.S)
            {
                KalanSure.Start();
                malzemeTimer.Start();
            }
        }

        private void KalanSure_Tick(object sender, EventArgs e)
        {
            sure = sure - 1;
            kalansurelbl.Text = Convert.ToString(sure);
        }

        private void malzemeTimer_Tick(object sender, EventArgs e)
        {
            benzinpicbox.Top += malzemeHiz;
            tekerlekpicbox.Top += malzemeHiz;
            motorpicbox.Top += malzemeHiz;
        }
        public void Topla()
        {
            if (tekerlekpicbox.Bounds.IntersectsWith(arabapicbox.Bounds))
            {
                tekerpuan += 1;
                gostergeteker.Text = tekerpuan.ToString();
                tekerlekpicbox.Top = rnd.Next(1, 200) * -1;
                tekerlekpicbox.Left = rnd.Next(1, 300);
            }
            else if (benzinpicbox.Bounds.IntersectsWith(arabapicbox.Bounds))
            {
                benzinpuan += 1;
                gostergebenzin.Text = benzinpuan.ToString();
                benzinpicbox.Top = rnd.Next(1, 700) * -1;
                benzinpicbox.Left = rnd.Next(1, 400);
            }
            else if (motorpicbox.Bounds.IntersectsWith(arabapicbox.Bounds))
            {
                motorpuan += 1;
                gostergemotor.Text = motorpuan.ToString();
                motorpicbox.Top = rnd.Next(1, 500) * -1;
                motorpicbox.Left = rnd.Next(1, 400);
            }
            else if (tekerlekpicbox.Top > 750)
            {
                tekerlekpicbox.Top = rnd.Next(1, 200) * -1;
                tekerlekpicbox.Left = rnd.Next(1, 300);
            }
            else if(benzinpicbox.Top > 750)
            {
                benzinpicbox.Top = rnd.Next(1, 700) * -1;
                benzinpicbox.Left = rnd.Next(1, 400);
            }
            else if (motorpicbox.Top > 750)
            {
                motorpicbox.Top = rnd.Next(1, 500) * -1;
                motorpicbox.Left = rnd.Next(1, 400);
            }
        }


    }
}
