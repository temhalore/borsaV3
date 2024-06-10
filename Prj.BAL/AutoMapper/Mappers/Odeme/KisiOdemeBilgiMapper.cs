

//using Prj.BAL.AutoMapper;
//using Prj.BAL.Managers.Uygulama.Interfaces;
//using Prj.COMMON.DTO.Common;
//using Prj.DAL.Model;

//public class KisiOdemeBilgiMapper : MappingProfile
//{
// private IKodManager _kodManager;
// public KisiOdemeBilgiMapper(IKodManager kodManager)
// {
//     _kodManager = kodManager;

// }

//    public KisiOdemeBilgiMapper()
//    {
//        CreateMap<T_Pos_OdemeKisiBilgi, OdemeKisiBilgiDTO>()
//           .ForMember(x => x.id, y => y.MapFrom(z => z.ID))
//                .ForMember(x => x.client_kisi_id, y => y.MapFrom(z => z.CLIENT_KISI_ID.Trim()))
//                .ForMember(x => x.tc, y => y.MapFrom(z => z.TC.Trim()))
//                .ForMember(x => x.pasaportNo, y => y.MapFrom(z => z.PASAPORT_NO.Trim()))
//                .ForMember(x => x.ad, y => y.MapFrom(z => z.AD.Trim()))
//                  .ForMember(x => x.soyad, y => y.MapFrom(z => z.SOYAD.Trim()))
//                //.ForMember(x => x.araciKurumKodDto, y => y.MapFrom(z => _kodManager.GetKodDtoByKodId(z.ARACI_KURUM_KOD_ID)))
//                .ForMember(x => x.email, y => y.MapFrom(z => z.EMAIL.Trim()))
//                .ForMember(x => x.telefon, y => y.MapFrom(z => z.TELEFON.Trim()))
//                 .ForMember(x => x.ulke, y => y.MapFrom(z => z.ULKE.Trim()))
//                 .ForMember(x => x.il, y => y.MapFrom(z => z.IL.Trim()))
//                 .ForMember(x => x.ilce, y => y.MapFrom(z => z.ILCE.Trim()))
//                 .ForMember(x => x.acikAdres, y => y.MapFrom(z => z.ACIK_ADRES.Trim()))
//                 .ForMember(x => x.uygulamaDto, y => y.MapFrom(z => new UygulamaDTO() { id=z.UYGULAMA_ID}))

//        //   ;
//        .ReverseMap()
//                .ForMember(x => x.CLIENT_KISI_ID , y => y.MapFrom(z => z.client_kisi_id.Trim()))
//                .ForMember(x => x.AD , y => y.MapFrom(z => z.ad.Trim()))
//                 .ForMember(x => x.SOYAD , y => y.MapFrom(z => z.soyad.Trim()))
//                  .ForMember(x => x.TC , y => y.MapFrom(z => z.tc.Trim()))
//                .ForMember(x => x.PASAPORT_NO , y => y.MapFrom(z => z.pasaportNo.Trim()))
//                .ForMember(x => x.EMAIL , y => y.MapFrom(z => z.email.Trim()))
//                .ForMember(x => x.TELEFON , y => y.MapFrom(z => z.telefon.Trim()))
//                 .ForMember(x => x.ULKE , y => y.MapFrom(z => z.ulke.Trim()))
//                 .ForMember(x => x.IL , y => y.MapFrom(z => z.il.Trim()))
//                 .ForMember(x => x.ILCE , y => y.MapFrom(z => z.ilce.Trim()))
//                 .ForMember(x => x.ACIK_ADRES , y => y.MapFrom(z => z.acikAdres.Trim()))
//                 .ForMember(x => x.UYGULAMA_ID, y => y.MapFrom(z => z.uygulamaDto.id))



//        ;
//    }
//}
