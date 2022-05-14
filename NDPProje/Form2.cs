//Ad Soyad : İBRAHİM ÇELEN
//Numara : B201200014
//Bölüm : BİLİŞİM SİSTEMLERİ MÜHENDİSLİĞİ

using System;
using System.Drawing;
using System.Windows.Forms;
using ProjeLibrary.Somut;

namespace NDPProje
{
    public partial class Form2 : Form
    {
        public int sure;
        int malzemeHiz = 6;
        Random rnd = new Random();
        public int kalanurun = 5;
        public int yapilanurun = 0;
        public int tekerpuan;
        public int motorpuan;
        public int benzinpuan;
        public int skor = 0;
        public int sureskor;
        public int skorsayac = 0;
        private readonly Oyun _oyun;
        public Form2()
        {
            InitializeComponent();
            //ilk sefenrlik konumlar atandı
            benzinpicbox.Top = rnd.Next(1,200) * -1;
            tekerlekpicbox.Top = rnd.Next(1, 500) * -1;
            motorpicbox.Top = rnd.Next(1, 700) * -1;
            giftbox.Top = rnd.Next(500, 1000) * -1;
            _oyun = new Oyun(oyunPanel);
            label2.Text = Form1.adSoyad;
            label3.Text = Form1.urunAd; // form1 deki bilgiler form2 deki labellere aktarıldı.
            exitbtn.Visible = false;
            kalanurunlbl.Text = Form1.urunMiktari;
            kalansurelbl.Text = "120";
            sure = Convert.ToInt32(kalansurelbl.Text);//süre kalan süre labelindeki değerin int değerini aldı.
            sureskor = Convert.ToInt32(kalansurelbl.Text) * 3;//kalan süre çarpı üç skor.
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Basla();
        }
        public void Basla()
        {
            KalanSure.Start();
            malzemeTimer.Start();
        }
        public void Bitis()
        {
            KalanSure.Stop();
            malzemeTimer.Stop();
            oyunbitislbl.Text = "Oyun Bitti...";
            exitbtn.Visible = true;
            //scorelbl.Text = ("Skor : " + skor.ToString()); // oyun bittiğinde ekran ortasında skor görünecek.
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            int yatay = arabapicbox.Location.X;
            if(e.KeyCode==Keys.Left && arabapicbox.Left > 15)
            {
                yatay -= 35;
            }
            if (e.KeyCode == Keys.Right && arabapicbox.Width + arabapicbox.Left <570)
            {
                yatay += 35;
            }
            arabapicbox.Location = new Point(yatay,530); //yatay eksende yer değiştirir ama düşey eksende sabittir.

            if(e.KeyCode == Keys.P) // P tuşu süreleri ve oyunu durdurur.
            {
                KalanSure.Stop();
                malzemeTimer.Stop();
            }
            else if (e.KeyCode == Keys.S) // S tuşu süreleri ve oyunu kaldığı yerdem devam ettirir.
            {
                KalanSure.Start();
                malzemeTimer.Start();
            }
        }

        private void KalanSure_Tick(object sender, EventArgs e)
        {

            sure--;
            kalansurelbl.Text = Convert.ToString(sure);
            skor = skorsayac;
            scorelbl.Text = ("Skor : " + skor.ToString());
            if (sure == 110) // süre 0 ise oyun sonlanır.
            {
                Bitis();
            }

            //malzemeler panelin aşağısına düştüğünde tekrardan panel üstünde konumlanacak.
        if (tekerlekpicbox.Top > oyunPanel.Height)
        {
            tekerlekpicbox.Top = rnd.Next(1, 100) * -1;
            tekerlekpicbox.Left = rnd.Next(oyunPanel.Width - tekerlekpicbox.Width); 
        }
        else if(benzinpicbox.Top > oyunPanel.Height)
        {
            benzinpicbox.Top = rnd.Next(1, 130) * -1;
            benzinpicbox.Left = rnd.Next(oyunPanel.Width - benzinpicbox.Width);
        }
        else if (motorpicbox.Top > oyunPanel.Height)
        {
            motorpicbox.Top = rnd.Next(1, 170) * -1;
            motorpicbox.Left = rnd.Next(oyunPanel.Width - motorpicbox.Width);
        }
        else if(giftbox.Top > oyunPanel.Height)
            {
                giftbox.Top = rnd.Next(1000, 2000) * -1;
                giftbox.Left = rnd.Next(oyunPanel.Width - giftbox.Width);
            }
            // puanlar stringe dönüştürülerek gösterge panelinde gösterilecek.
            gostergebenzin.Text = benzinpuan.ToString();
            gostergemotor.Text = motorpuan.ToString();
            gostergeteker.Text = tekerpuan.ToString();
        }

        private void malzemeTimer_Tick(object sender, EventArgs e)
        {
            //malzemelere özgü zaman Ve hızlanma.
            Topla();
            benzinpicbox.Top += malzemeHiz;
            tekerlekpicbox.Top += malzemeHiz;
            motorpicbox.Top += malzemeHiz;
            giftbox.Top += malzemeHiz;

        }
        public void Topla()
        {
            //malzemeler arabaya değdiği gibi sayaçlar çalışcak ve malzemeler tekrardan konumlanacak.
            if (tekerlekpicbox.Bounds.IntersectsWith(arabapicbox.Bounds))
            {
                tekerpuan += 1;
                gostergeteker.Text = tekerpuan.ToString();
                tekerlekpicbox.Top = rnd.Next(70, 400) * -1;
                tekerlekpicbox.Left = rnd.Next(oyunPanel.Width - tekerlekpicbox.Width);
            }
            else if (benzinpicbox.Bounds.IntersectsWith(arabapicbox.Bounds))
            {
                benzinpuan += 1;
                gostergebenzin.Text = benzinpuan.ToString();
                benzinpicbox.Top = rnd.Next(40, 200) * -1;
                benzinpicbox.Left = rnd.Next(oyunPanel.Width - benzinpicbox.Width);
            }
            else if (motorpicbox.Bounds.IntersectsWith(arabapicbox.Bounds))
            {
                motorpuan += 1;
                gostergemotor.Text = motorpuan.ToString();
                motorpicbox.Top = rnd.Next(20, 350) * -1;
                motorpicbox.Left = rnd.Next(oyunPanel.Width - motorpicbox.Width);
            }
            else if (giftbox.Bounds.IntersectsWith(arabapicbox.Bounds))
            {
                int sans = rnd.Next(1, 3); // yüzde 50 şans
                if(sans == 1)
                {
                    skorsayac += rnd.Next(1, 100);
                }
                else if(sans == 2)
                {
                    skorsayac += rnd.Next(1, 100) * -1;
                }
                giftbox.Top = rnd.Next(1000, 2000) * -1;
                giftbox.Left = rnd.Next(oyunPanel.Width - giftbox.Width);
            }

            // malzeme ve kalan ürün işlemleri
            if(benzinpuan >= 1 && motorpuan >= 2 && tekerpuan >= 3)
            {
                skorsayac = skorsayac + 100; //yapılan her ürün 100 puan.
                yapilanurun++;
                yapılanurunlbl.Text = Convert.ToString(yapilanurun);
                kalanurun--;
                kalanurunlbl.Text = kalanurun.ToString();
                //her 1 ürün üretildiğinde, 1 ürünlük malzemeler(benzin,motor,tekerlek) göstergeden gerektiği kadar azaltılacaktır.
                //kullanıcı daha iyi oyun anlık bilgisini alması ve gereken malzemeyi hesaplaması için
                benzinpuan--;
                motorpuan = motorpuan - 2;
                tekerpuan = tekerpuan - 3;
                if(kalanurun == 0)
                {
                    skor += sureskor;
                    Bitis();
                }
            }
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
