// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DapperExtensions.Mapper;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prj.DAL.Model
{


    //[Dapper.Contrib.Extensions.Table("u1555990_borsav2.t_doviz_alarm")] --ae değişiklik
	[Dapper.Contrib.Extensions.Table("t_doviz_alarm")]

    //public partial class T_u1555990_borsav2_t_doviz_alarm --ae değişiklik
	 public partial class t_doviz_alarm    {
		//public T_u1555990_borsav2_t_doviz_alarm()--ae değişiklik
		public t_doviz_alarm()
		{
		}

        //public static string SchemeName { get { return "u1555990_borsav2"; } }
        public static string GetSchema() { return "u1555990_borsav2"; }

        //[AutoIncrement]
		[Dapper.Contrib.Extensions.Key]
        public int ID { get; set;}
        [Required]
        public long TELEGRAM_ID { get; set;}
        public string SYMBOL { get; set;}
        public DateTime? TARIH { get; set;}
        [Required]
        public long ALARM_TIP_KOD_ID { get; set;}
        [Required]
        public long ALARM_SURE_TIP_KOD_ID { get; set;}
        public decimal? FIYAT { get; set;}
        public decimal? SON_BILDIRIM_FIYAT { get; set;}
        public DateTime? SON_BILDIRIM_TARIH { get; set;}
        [Required]
        public int ISDELETED { get; set;}
        public long? CREATEDUSER { get; set;}
        public DateTime? CREATEDDATE { get; set;}
        public long? MODIFIEDUSER { get; set;}
        public DateTime? MODIFIEDDATE { get; set;}
    }
	
    
   // public class T_u1555990_borsav2_t_doviz_alarmMapper : AutoClassMapper<T_u1555990_borsav2_t_doviz_alarm> --ae değişiklik
	public class t_doviz_alarmMapper : AutoClassMapper<t_doviz_alarm>
    {
        //public T_u1555990_borsav2_t_doviz_alarmMapper() --ae değişiklik
		public t_doviz_alarmMapper()
            : base()
        {
            Schema("u1555990_borsav2");
        }
    }
 
	//public enum T_u1555990_borsav2_t_doviz_alarm_Properties {--ae değişiklik
	public enum t_doviz_alarm_Properties {

		ID,
		TELEGRAM_ID,
		SYMBOL,
		TARIH,
		ALARM_TIP_KOD_ID,
		ALARM_SURE_TIP_KOD_ID,
		FIYAT,
		SON_BILDIRIM_FIYAT,
		SON_BILDIRIM_TARIH,
		ISDELETED,
		CREATEDUSER,
		CREATEDDATE,
		MODIFIEDUSER,
		MODIFIEDDATE,
		
	}	
}

#pragma warning restore 1591
