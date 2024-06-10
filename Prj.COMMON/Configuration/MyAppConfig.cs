using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using vosetu.work.common.DTO.Security.Auth;

namespace Prj.COMMON.Configuration
{

    /// <summary>
    /// uygulamaya özel config dosyası içindir 
    /// </summary>
    public class MyAppConfig
    {

        public static int OdemeExpDakika { get; set; }
        public static string HalkBankApiUrl { get; set; }
        public static string OdemeSayfasiUrl { get; set; }
        public static string YonlendirmeSayfasiUrl { get; set; }
        public static string DogrulamaMetodu3DApi { get; set; }
        public static string SonucSayfasi { get; set; }

    }
}
