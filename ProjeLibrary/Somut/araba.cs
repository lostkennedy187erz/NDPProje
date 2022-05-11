using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjeLibrary.Somut
{
    internal class Araba : PictureBox
    {
        public Araba(int panelGenisligi)
        {
            Left = (panelGenisligi - Width) / 2;
        }
    }
}
