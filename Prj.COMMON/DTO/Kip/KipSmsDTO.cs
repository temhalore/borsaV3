using Prj.COMMON.DTO.Base;


namespace Prj.COMMON.DTO.Kip
{
    public class KipSmsDTO : BaseDTO
    {
        public string aliciCepTel { get; set; }
        public string mesaj { get; set; }
        public string gonderenBaslik { get; set; }

    }
}
