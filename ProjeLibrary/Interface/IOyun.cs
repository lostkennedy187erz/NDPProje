using ProjeLibrary.Enum;
using System;
namespace ProjeLibrary.Interface
{
    internal interface IOyun
    {
        event EventHandler KalanSureDegisti;
        void Baslat();
        void Duraklat();
        void kutuHareket(Yon yon);
        TimeSpan KalanSure { get; }

    }
}
