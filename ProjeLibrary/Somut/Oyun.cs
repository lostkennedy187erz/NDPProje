//Ad Soyad : İBRAHİM ÇELEN
//Numara : B201200014
//Bölüm : BİLİŞİM SİSTEMLERİ MÜHENDİSLİĞİ
using ProjeLibrary.Enum;
using ProjeLibrary.Interface;
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeLibrary.Somut
{
    public class Oyun : IOyun
    {
        #region Alanlar
        public readonly Timer _kalanSureTimer = new Timer { Interval = 1000 };
        private TimeSpan _kalanSure;
        private readonly Panel _arabaPanel;
        Random randX = new Random();
        #endregion

        #region Olaylar
        public event EventHandler KalanSureDegisti;
        #endregion

        #region Özellikler
        public bool DevamEdiyorMu { get; private set; }
        public TimeSpan KalanSure 
        {
            get => _kalanSure; 
            private set
            {
                _kalanSure = value;

                KalanSureDegisti?.Invoke(this, EventArgs.Empty);
            } 
        }
        #endregion

        #region Metodlar
        public Oyun(Panel arabaPanel)
        {
            _arabaPanel = arabaPanel;
            
        }

        public void Baslat()
        {
            if (DevamEdiyorMu) return;

            DevamEdiyorMu = true;
        }

        private void Bitir()
        {
            if (!DevamEdiyorMu) return;

            DevamEdiyorMu = false;
        }

        public void Duraklat()
        {
            
        }

        public void kutuHareket(Yon yon)
        {
            
        }
        #endregion

    }
}
