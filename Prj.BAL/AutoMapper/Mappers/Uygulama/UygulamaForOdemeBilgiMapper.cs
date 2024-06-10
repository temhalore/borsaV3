

//using Prj.BAL.AutoMapper;
//using Prj.BAL.Managers.Uygulama.Interfaces;
//using Prj.COMMON.DTO.Common;
//using Prj.COMMON.DTO.Uygulama;
//using Prj.DAL.Model;

//public class UygulamaForOdemeBilgiMapper : MappingProfile
//{
// private IKodManager _kodManager;
// public UygulamaForOdemeBilgiMapper(IKodManager kodManager)
// {
//     _kodManager = kodManager;

// }

//    public UygulamaForOdemeBilgiMapper()
//    {
//        CreateMap<T_Pos_Uygulama, UygulamaDTOForOdemeBilgi>()
//           .ForMember(x => x.id, y => y.MapFrom(z => z.ID))
//                  .ForMember(x => x.uygulamaKey, y => y.MapFrom(z => z.UYGULAMA_KEY))
//                .ForMember(x => x.aciklama, y => y.MapFrom(z => z.ACIKLAMA))
//                 .ForMember(x => x.isAktif, y => y.MapFrom(z => Convert.ToBoolean(z.IS_AKTIF)))
//        //   ;
//        .ReverseMap()
//        .ForMember(x => x.ID, y => y.MapFrom(z => z.id))
//            .ForMember(x => x.UYGULAMA_KEY, y => y.MapFrom(z => z.uygulamaKey))
//                .ForMember(x => x.ACIKLAMA, y => y.MapFrom(z => z.aciklama))
//                .ForMember(x => x.IS_AKTIF, y => y.MapFrom(z => z.isAktif))
//        ;
//    }
//}