//Ad Soyad : İBRAHİM ÇELEN
//Numara : B201200014
//Bölüm : BİLİŞİM SİSTEMLERİ MÜHENDİSLİĞİ

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ProjeLibrary.Somut;

namespace NDPProje
{
    public partial class Form2 : Form
    {
        public int sure;
        int malzemeHiz = 6;
        Random rnd = new Random();
        public int kalanurun = Form1.urunMiktari; //form1de girilen ürün miktarı buraya yeni değişkene aktarıldı.
        public int yapilanurun = 0;
        public int tekerpuan;
        public int motorpuan;
        public int benzinpuan;
        public int skor = 0;
        public int sureskor;
        public int skorsayac = 0;
        public StreamWriter file; // Sadece ilk oyuncunun skoru kayıt ediliyor.
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
            oyuncuadlbl.Text = Form1.adSoyad;
            urunadlbl.Text = Form1.urunAd; // form1 deki bilgiler form2 deki labellere aktarıldı.
            exitbtn.Visible = false;
            kalanurunlbl.Text = Form1.urunMiktari.ToString();
            kalansurelbl.Text = "120";
            sure = Convert.ToInt32(kalansurelbl.Text);//süre kalan süre labelindeki değerin int değerini aldı.
            //kalan süre çarpı üç skor.
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
            string path = "Best Scores of The Game.txt"; // DOSYANIN ADI!!!

            if (!File.Exists(path))
            {
                file = new StreamWriter(path);
                file.WriteLine(oyuncuadlbl.Text + " : " + skor.ToString()); // sadece ilk oyuncunun skoru kayıt ediliyor.
                file.Close();
            }
            
            skor += sureskor; // oyun bittiğinse kalan skor 3 ile çarpılıp skora eklenecek.
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
                yatay -= 50;
            }
            if (e.KeyCode == Keys.Right && arabapicbox.Width + arabapicbox.Left <570)
            {
                yatay += 50;
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
            if (sure == 0) // süre 0 ise oyun sonlanır.
            {
                Bitis();
            }

            //malzemeler panelin aşağısına düştüğünde tekrardan panel üstünde konumlanacak.
        if (tekerlekpicbox.Top > oyunPanel.Height)
        {
            tekerlekpicbox.Top = -50; // nesneler üst üste birleşik gelmemesi için rastgele değerler atanmadı.
                tekerlekpicbox.Left = rnd.Next(oyunPanel.Width - tekerlekpicbox.Width); 
        }
        else if(benzinpicbox.Top > oyunPanel.Height)
        {
            benzinpicbox.Top = -200;
            benzinpicbox.Left = rnd.Next(oyunPanel.Width - benzinpicbox.Width);
        }
        else if (motorpicbox.Top > oyunPanel.Height)
        {
            motorpicbox.Top = -120;
            motorpicbox.Left = rnd.Next(oyunPanel.Width - motorpicbox.Width);
        }
        else if(giftbox.Top > oyunPanel.Height)
            {
                giftbox.Top = rnd.Next(1000, 2000) * -1;
                giftbox.Left = rnd.Next(oyunPanel.Width - giftbox.Width);
            }
            // puanlar stringe dönüştürülerek gösterge panelinde gösterilecek.
        }


        private void malzemeTimer_Tick(object sender, EventArgs e)
        {
            //malzemelere özgü zaman Ve hızlanma.
            Topla();
            skor = skorsayac;
            sureskor = Convert.ToInt32(kalansurelbl.Text) * 3; // süre skorun değeri belirlenir.
            if (kalanurun == 0)
            {
                skor += sureskor; // oyun ürünler toplam ürün toplandığında kalan süre puanını, ana puana ekler.
            }
            scorelbl.Text = ("Skor : " + skor.ToString()); //güncel skor bilgisini yansıtma.

            if(kalansurelbl.Text == "100")
            {
                malzemeHiz = 9; //her 20 saniyede +3 hız.
            }
            if(kalansurelbl.Text == "80")
            {
                malzemeHiz = 12;
            }
            if(kalansurelbl.Text == "60")
            {
                malzemeHiz = 15;
            }
            if(kalansurelbl.Text == "40")
            {
                malzemeHiz = 18;
            }
            if(kalansurelbl.Text == "20")
            {
                malzemeHiz = 21;
            }

            //nesneler aşağıya düşsün diye += operatörü kullanıldı.
            benzinpicbox.Top += malzemeHiz;
            tekerlekpicbox.Top += malzemeHiz;
            motorpicbox.Top += malzemeHiz;
            giftbox.Top += malzemeHiz;

            //eşzamanlı güncel gösterge bilgileri.
            gostergebenzin.Text = benzinpuan.ToString();
            gostergemotor.Text = motorpuan.ToString();
            gostergeteker.Text = tekerpuan.ToString();

        }
        public void Topla()
        {
            //malzemeler arabaya değdiği gibi sayaçlar çalışcak ve malzemeler tekrardan konumlanacak.
            if (tekerlekpicbox.Bounds.IntersectsWith(arabapicbox.Bounds))
            {
                tekerpuan += 1;
                gostergeteker.Text = tekerpuan.ToString();
                tekerlekpicbox.Top = -50; // nesneler üst üste birleşik gelmemesi için rastgele değerler atanmadı fakat -200 den -100'e ulaşmış bir benzinin üstüne motor spawnlanabilir.
                tekerlekpicbox.Left = rnd.Next(oyunPanel.Width - tekerlekpicbox.Width);
            }
            else if (benzinpicbox.Bounds.IntersectsWith(arabapicbox.Bounds))
            {
                benzinpuan += 1;
                gostergebenzin.Text = benzinpuan.ToString();
                benzinpicbox.Top = -200;
                benzinpicbox.Left = rnd.Next(oyunPanel.Width - benzinpicbox.Width);
            }
            else if (motorpicbox.Bounds.IntersectsWith(arabapicbox.Bounds))
            {
                motorpuan += 1;
                gostergemotor.Text = motorpuan.ToString();
                motorpicbox.Top = -100;
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
                giftbox.Top = rnd.Next(1200, 2200) * -1;
                giftbox.Left = rnd.Next(oyunPanel.Width - giftbox.Width);
            }

            // malzeme ve kalan ürün işlemleri
            if(benzinpuan >= 1 && motorpuan >= 2 && tekerpuan >= 3)
            {
                skorsayac += 100; //yapılan her ürün 100 puan.
                yapilanurun++;
                yapılanurunlbl.Text = Convert.ToString(yapilanurun);
                kalanurun--;
                kalanurunlbl.Text = kalanurun.ToString();
                //her 1 ürün üretildiğinde, 1 ürünlük malzemeler(benzin,motor,tekerlek) göstergeden gerektiği kadar azaltılacaktır.
                //kullanıcı daha iyi oyun anlık bilgisini alması ve gereken malzemeyi hesaplaması için
                benzinpuan--;
                motorpuan -= 2;
                tekerpuan -= 3;

                if (kalanurun == 0)
                {
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
