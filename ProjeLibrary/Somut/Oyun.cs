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
        #endregion

        #region Olaylar
        #endregion

        #region Özellikler
        #endregion

        #region Metodlar
        public Oyun(Panel arabaPanel)
        {
            
        }
        #endregion

    }
}
