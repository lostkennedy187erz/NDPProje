//Ad Soyad : İBRAHİM ÇELEN
//Numara : B201200014
//Bölüm : BİLİŞİM SİSTEMLERİ MÜHENDİSLİĞİ

using System;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            label2.Text = Form1.adSoyad;
            label3.Text = Form1.urunAd;
            label11.Text = Form1.urunMiktari;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        
        }
            
    }
}
