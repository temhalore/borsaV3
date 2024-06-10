﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.COMMON.DTO.Enums
{
	public enum MessageCode
	{
		[Description("Uygulamada bir hata olustu")]
        ERROR_500_BIR_HATA_OLUSTU = 500, 
		
		[Description("Yeniden login olunmalı")]
        ERROR_501_YENIDEN_LOGIN_OLMALI = 501,

        [Description("Eksik veri gönderimi")]
        ERROR_502_EKSIK_VERI_GONDERIMI = 502,

        [Description("Geçersiz veri gönderimi")]
        ERROR_503_GECERSIZ_VERI_GONDERIMI = 503,

        [Description("Uygulamada bir hata olustu Yönlendir")]
        ERROR_504_BIR_HATA_OLUSTU = 504,



    }
}
