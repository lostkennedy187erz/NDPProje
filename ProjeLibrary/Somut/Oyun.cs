using ProjeLibrary.Enum;
using ProjeLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeLibrary.Somut
{
    public class Oyun : IOyun
    {
        public bool DevamEdiyorMu { get; private set; }
        public TimeSpan KalanSure => throw new NotImplementedException();

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
            throw new NotImplementedException();
        }

        public void kutuHareket(Yon yon)
        {
            throw new NotImplementedException();
        }
    }
}
