using ProjeLibrary.Enum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeLibrary.Interface
{
    internal interface IHareketEden
    {
        Size HareketAlanBoyutları { get; }
        bool HareketEttir(Yon yon);
    }
}
