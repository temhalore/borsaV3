using Prj.COMMON.DTO.Base;

namespace Prj.COMMON.DTO.Kip
{
    public class KipMailDTO : BaseDTO
    {
        public List<string> aliciMailAdresList { get; set; } = new List<string>();
        public string gonderenMailAdres { get; set; }

        public string gondericiAdSoyad { get; set; }

        public string konu { get; set; }

        public string yanitMailAdres { get; set; }

        public string mesaj { get; set; }


    }

}
