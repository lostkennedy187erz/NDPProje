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
        private readonly Oyun _oyun = new Oyun();
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

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    _oyun.Baslat();
                    break;
                case Keys.Left:
                    _oyun.kutuHareket(Yon.Sol);
                    break;
                case Keys.Right:
                    _oyun.kutuHareket(Yon.Sag);
                    break;
            }
        }
    }
}
