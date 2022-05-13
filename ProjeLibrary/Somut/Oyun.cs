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
        Random rnd = new Random();
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
            else if (benzinpicbox.Top > 750)
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
        #endregion

    }
}
