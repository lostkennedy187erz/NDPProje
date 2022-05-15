//Ad Soyad : İBRAHİM ÇELEN
//Numara : B201200014
//Bölüm : BİLİŞİM SİSTEMLERİ MÜHENDİSLİĞİ

using System;
using System.IO;
using System.Windows.Forms;

namespace NDPProje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();     
        }
        public static string adSoyad = ""; //form1den form2 ye data göndermek için üretilen değişkenler.
        public static string urunAd = "";
        public static string urunMiktari = "";
        private void label9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hareket etmek için sağ ve sol yön tuşlarını kullanınız." +
                "\nOyunu duraklatmak için P, devam etmek için S tuşunu kullanınız.\nSüre bittiğinde oyun sona erer." +
                "\nHer seferinde toplamda 5 ürün toplanmalıdır.\nHer 20 saniyede bir oyun hızlanacaktır" +
                "\nHer bir ürün 100 puandır.\nEkstra malzeme puan kazandırmaz." +
                "\nÜrün toplaması bittiğinde kalan süre 3 ile çarpılıp skora eklenir.\nHediye kutuları size (1,100) arası puan kazandıracaktır veya kaybettirecektir.");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hareket etmek için sağ ve sol yön tuşlarını kullanınız." +
                "\nOyunu duraklatmak için P, devam etmek için S tuşunu kullanınız.\nSüre bittiğinde oyun sona erer." +
                "\nHer seferinde toplamda 5 ürün toplanmalıdır.\nHer 20 saniyede bir oyun hızlanacaktır" +
                "\nHer bir ürün 100 puandır.\nEkstra malzeme puan kazandırmaz." +
                "\nÜrün toplaması bittiğinde kalan süre 3 ile çarpılıp skora eklenir.\nHediye kutuları size (1,100) arası puan kazandıracaktır veya kaybettirecektir.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //BASLA BUTONU
            adSoyad = isimbox.Text + " " + soyadbox.Text;
            urunAd = urunbox.Text;
            urunMiktari = urunmiktarbox.Text;
            Form2 fm2 = new Form2(); //oyun ekranına geçiş için
            fm2.Show();
            Visible = false; // oyun ekranı açıldığında giriş ekranının görünmemesi için.
        }

        private void label10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Skor Okuma Yapılamadı.");
        }
    }
}
