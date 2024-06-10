using System;
namespace Prj.COMMON.DTO.Enums

{
    public class AppEnums
    {

        public enum Odeme_Yontem
        {
            Empty = 0,
            Kredi_Karti = 1010001,
            Google_pay = 1010002,
            HavaleEft = 1010003,
            BKM_ekspress = 1010004,
            Amerikan_Ekspress = 1010005 //bunda 3d yok
        }
        public enum Odeme_Yontem_Guvenlik
        {
            Empty = 0,
            _2D_guvenlik = 1020001,
            _3D_guvenlik = 1020002 
        }
        public enum Odeme_Durum
        {
            Empty = 0,
            Key_Olusturuldu = 1030001,
            Odeme_Icin_Bekleniyor = 1030002,
            Istek_Bankaya_Gonderildi = 1030003,
            Istek_3d_Dogrulamaya_Gonderildi = 1030007,
            Odeme_Basarili = 1030004,
            Odeme_Basarisiz = 1030005,
            Odeme_Key_Suresi_Doldu = 1030006,
        }

        public enum Araci_Kurum
        {
            Empty = 0,
            HalkBank = 1040001,
            ZiraatBank = 1040002
        }

        public enum KodTipList
        {
            Odeme_Yontem = 101,
            Odeme_Yontem_Guvenlik = 102,
            Odeme_Durum = 103,
            Araci_Kurum = 104
        }

    }
}
