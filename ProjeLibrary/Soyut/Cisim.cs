using ProjeLibrary.Enum;
using ProjeLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjeLibrary.Soyut
{
    internal abstract class Cisim : PictureBox
    {
        public Size HareketAlanboyutları { get; }
        public int HareketMesafesi { get;}
        protected Cisim(Size hareketAlaniBoyutlari)
        {
            SizeMode = PictureBoxSizeMode.AutoSize;
        }
        public bool HareketEttir(Yon yon)
        {
            throw (null);
        }
    }
}
