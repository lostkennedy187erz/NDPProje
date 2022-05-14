//Ad Soyad : İBRAHİM ÇELEN
//Numara : B201200014
//Bölüm : BİLİŞİM SİSTEMLERİ MÜHENDİSLİĞİ

using System;
using ProjeLibrary.Somut;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                "\nOyunu duraklatmak için P, devam etmek için S tuşunu kullanınız.\nHer seferinde toplamda 5 ürün toplanmalıdır.\nHer bir ürün 100 puandır.\nEkstra malzeme puan getirmez." +
                "\nÜrün toplaması bittiğinde kalan süre 3 ile çarpılıp skora eklenir.\nHediye kutuları size (200,800) arası puan kazandıracaktır veya kaybettirecektir.");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hareket etmek için sağ ve sol yön tuşlarını kullanınız." +
                "\nOyunu duraklatmak için P, devam etmek için S tuşunu kullanınız.\nHer seferinde toplamda 5 ürün toplanmalıdır.\nHer bir ürün 100 puandır.\nEkstra malzeme puan getirmez." +
                "\nÜrün toplaması bittiğinde kalan süre 3 ile çarpılıp skora eklenir.\nHediye kutuları size (200,800) arası puan kazandıracaktır veya kaybettirecektir.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adSoyad = textBox2.Text + " " + textBox3.Text;
            urunAd = textBox4.Text;
            urunMiktari = textBox5.Text;
            Form2 fm2 = new Form2(); //oyun ekranına geçiş için
            fm2.Show();
            Visible = false; // oyun ekranı açıldığında giriş ekranının görünmemesi için.
        }
    }
}
