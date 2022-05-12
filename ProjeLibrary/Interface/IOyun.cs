//Ad Soyad : İBRAHİM ÇELEN
//Numara : B201200014
//Bölüm : BİLİŞİM SİSTEMLERİ MÜHENDİSLİĞİ
using ProjeLibrary.Enum;
using System;
namespace ProjeLibrary.Interface
{
    internal interface IOyun
    {
        void Baslat();
        void Duraklat();
        void kutuHareket(Yon yon);
    }
}
