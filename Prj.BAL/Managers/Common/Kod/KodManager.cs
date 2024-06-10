using AutoMapper;
using Microsoft.AspNetCore.Http;
using Prj.BAL.Managers.Uygulama.Interfaces;
using Prj.COMMON.Configuration;
using Prj.COMMON.DTO.Common;
using Prj.COMMON.DTO.Enums;
using Prj.COMMON.DTO.Kip;
using Prj.COMMON.Extensions;
using Prj.COMMON.Models;
using Prj.DAL.Model;
using Prj.DAL.Repository;
using System.Net;


namespace Prj.BAL.Managers.Common.Kod
{
    public class KodManager : IKodManager
    {
        public static List<KodDTO> _allKodDtoList = new List<KodDTO>();
        public List<KodDTO> getAllKodDtoList { get { return allKodDtoList(); } }

        private IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public KodManager(IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            //_modelDtoConverterHelper = modelDtoConverterHelper;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
       

        }

        /// <summary>
        /// cacheYenilensinMi = true giderse db den tüm kod alanlarını tekrardan listeye yazar
        /// </summary>
        /// <param name="cacheYenilensinMi"></param>
        /// <returns></returns>
        public List<KodDTO> allKodDtoList(bool cacheYenilensinMi = false)
        {

            if (_allKodDtoList.Count == 0 || _allKodDtoList == null)
            {
                cacheYenilensinMi = true;
            }

            if (cacheYenilensinMi)
            {
                var repo = new GenericRepository<T_Pos_Kod>();

                var data = repo.GetList();

                foreach (var item in data)
                {


                    KodDTO dto = new KodDTO();
                    try
                    {
                        dto = _mapper.Map<T_Pos_Kod, KodDTO>(item);
                      //  dto = _modelDtoConverterHelper.T_oys_KodToKodDTO(item);
                    }
                    catch (Exception e)
                    {

                        dto.id = item.ID;
                        dto.kod = item.KOD;
                        dto.sira = Convert.ToInt32(item.SIRA);
                        dto.tipId = Convert.ToInt32(item.TIP_ID);
                        dto.kisaAd = item.KISA_AD;
                        dto.digerUygEnumDeger = Convert.ToInt32(item.DIGER_UYG_ID);
                        dto.digerUygEnumAd = item.DIGER_UYG_ENUM_AD;
                    }

                    //yoksa ekle
                    if (!_allKodDtoList.Select(x => x.id).ToList().Contains(dto.id)) _allKodDtoList.Add(dto);
                }

                //_allKodDtoList = Mapper.Map<List<T_OSS_KOD>, List<KodDTO>>(data);

            }

            return _allKodDtoList;
        }


        public bool checkKodDTOIdInTipList(KodDTO kodDto, AppEnums.KodTipList enumTip, string hataMesaji = "")
        {

            bool returnDeger = checkKodDTOIsNull(kodDto, hataMesaji);

            string mesaj = "Seçilen bir alan kendi listesinin dışında gelen Id: " + kodDto.id;
            if (!String.IsNullOrWhiteSpace(hataMesaji) && !String.IsNullOrEmpty(hataMesaji))
            {
                mesaj = hataMesaji;
            }

            if (!_allKodDtoList.Where(x => x.tipId == ((int)enumTip)).Select(x => x.id).ToList().Contains(kodDto.id))
            {
                returnDeger = false;
            }

            if (!returnDeger)
            {
                throw new AppException(MessageCode.ERROR_503_GECERSIZ_VERI_GONDERIMI, mesaj);
            }

            return returnDeger;
        }

        public bool checkKodDTOIsNull(KodDTO kodDto, string hataMesaji = "")
        {
            {
                bool returnDeger = false;
                if (kodDto != null && kodDto.id > 0)
                {
                    //kod listler arısnnda gelen id varmı buda tutarlılık için önemli
                    if (_allKodDtoList.Select(x => x.id).ToList().Contains(kodDto.id))
                    {
                        returnDeger = true;
                    }
                }

                string mesaj = "Seçilmesi zorunlu bir alan seçilmemiş.";
                if (!String.IsNullOrWhiteSpace(hataMesaji) && !String.IsNullOrEmpty(hataMesaji))
                {
                    mesaj = hataMesaji;
                }

                if (!returnDeger)
                {
                    throw new AppException(MessageCode.ERROR_502_EKSIK_VERI_GONDERIMI, mesaj);
                }

                return returnDeger;
            }
        }

        public KodDTO GetKodDtoByKodId(int kodId)
        {
                var repoKod = new GenericRepository<T_Pos_Kod>();
                var kod = repoKod.Get(kodId);
           var  dto = _mapper.Map<T_Pos_Kod, KodDTO>(kod);
            return dto;
            }

        public List<KodDTO> GetKodDtoListByKodTipId(int kodTipID)
            {
                var dtoList = getAllKodDtoList.Where(x => x.tipId == kodTipID).ToList();
                var clone = GeneralExtensions.Clone<List<KodDTO>>(dtoList);
                return clone;
            }
      

        public string refreshKodListCache()
        {
            allKodDtoList(true);
            return "KodDtoList yenilendi";
        }

    
    }
}
