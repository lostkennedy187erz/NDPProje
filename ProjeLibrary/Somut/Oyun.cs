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
            _kalanSureTimer.Tick -= KalanSureTimer_Tick;
        }
        private void KalanSureTimer_Tick(object sender, EventArgs e)
        {
            KalanSure -= TimeSpan.FromSeconds(1);
        }
        public void Baslat()
        {
            if (DevamEdiyorMu) return;

            DevamEdiyorMu = true;
            _kalanSureTimer.Start();

            ArabaOlustur();

        }

        private void ArabaOlustur()
        {
            var araba = new Araba(_arabaPanel.Width) 
            { 
                Image = Image.FromFile($@"C:\Users\İbrahim Çelen\Downloads\araba.png") 
            };
            _arabaPanel.Controls.Add(araba);
        }

        private void Bitir()
        {
            if (!DevamEdiyorMu) return;

            DevamEdiyorMu = false;
        }

        public void Duraklat()
        {
            _kalanSureTimer.Stop();
        }

        public void kutuHareket(Yon yon)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
