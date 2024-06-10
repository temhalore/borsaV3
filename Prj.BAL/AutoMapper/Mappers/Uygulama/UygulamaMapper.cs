

//using Prj.BAL.AutoMapper;
//using Prj.BAL.Managers.Uygulama.Interfaces;
//using Prj.COMMON.DTO.Common;
//using Prj.COMMON.DTO.Uygulama;
//using Prj.DAL.Model;

//public class UygulamaMapper : MappingProfile
//{
// private IKodManager _kodManager;
// public UygulamaMapper(IKodManager kodManager)
// {
//     _kodManager = kodManager;

// }

//    public UygulamaMapper()
//    {
//        CreateMap<T_Pos_Uygulama, UygulamaDTO>()
//           .ForMember(x => x.id, y => y.MapFrom(z => z.ID))
//                .ForMember(x => x.logoUrl, y => y.MapFrom(z => z.LOGO_URL))
//                .ForMember(x => x.uygulamaSifre, y => y.MapFrom(z => z.UYGULAMA_SIFRE))
//                  .ForMember(x => x.uygulamaKey, y => y.MapFrom(z => z.UYGULAMA_KEY))
//                .ForMember(x => x.araciKurumKodDto, y => y.MapFrom(z => _kodManager.GetKodDtoByKodId(z.ARACI_KURUM_KOD_ID)))
//                .ForMember(x => x.aciklama, y => y.MapFrom(z => z.ACIKLAMA))
//                .ForMember(x => x.araciKurumApiKey, y => y.MapFrom(z => z.ARACI_KURUM_API_KEY))
//                 .ForMember(x => x.araciKurumApiSifre, y => y.MapFrom(z => z.ARACI_KURUM_API_SIFRE))
//                 .ForMember(x => x.araciKurumApiStoreKey, y => y.MapFrom(z => z.ARACI_KURUM_STORE_KEY))
//                  .ForMember(x => x.isAktif, y => y.MapFrom(z => Convert.ToBoolean(z.IS_AKTIF)))

//        //   ;
//        .ReverseMap()
//        .ForMember(x => x.ID, y => y.MapFrom(z => z.id))
//        .ForMember(x => x.LOGO_URL, y => y.MapFrom(z => z.logoUrl.Trim()))
//          .ForMember(x => x.UYGULAMA_SIFRE, y => y.MapFrom(z => z.uygulamaSifre))
//            .ForMember(x => x.UYGULAMA_KEY, y => y.MapFrom(z => z.uygulamaKey))
//              .ForMember(x => x.ARACI_KURUM_KOD_ID, y => y.MapFrom(z => z.araciKurumKodDto.id))
//                .ForMember(x => x.ACIKLAMA, y => y.MapFrom(z => z.aciklama))
//                  .ForMember(x => x.ARACI_KURUM_API_KEY, y => y.MapFrom(z => z.araciKurumApiKey))
//                   .ForMember(x => x.ARACI_KURUM_API_SIFRE, y => y.MapFrom(z => z.araciKurumApiSifre))
//                     .ForMember(x => x.ARACI_KURUM_STORE_KEY , y => y.MapFrom(z => z.araciKurumApiStoreKey))
//                    .ForMember(x => x.IS_AKTIF, y => y.MapFrom(z => z.isAktif))
//        ;
//    }
//}
