﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.COMMON.DTO.Common
{
    public class KodDTO 
    {
        public int id { get; set; }
        public int tipId { get; set; }
        public string kod { get; set; }
        public string kisaAd { get; set; }
        public int sira { get; set; }

        public string digerUygEnumAd { get; set; }
        public int digerUygEnumDeger { get; set; }
    }
}
