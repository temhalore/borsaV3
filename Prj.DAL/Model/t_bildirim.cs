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


    //[Dapper.Contrib.Extensions.Table("u1555990_borsav2.t_bildirim")] --ae değişiklik
	[Dapper.Contrib.Extensions.Table("t_bildirim")]

    //public partial class T_u1555990_borsav2_t_bildirim --ae değişiklik
	 public partial class t_bildirim    {
		//public T_u1555990_borsav2_t_bildirim()--ae değişiklik
		public t_bildirim()
		{
		}

        //public static string SchemeName { get { return "u1555990_borsav2"; } }
        public static string GetSchema() { return "u1555990_borsav2"; }

        //[AutoIncrement]
		[Dapper.Contrib.Extensions.Key]
        public int ID { get; set;}
        [Required]
        public long BILDIRIM_TIP_KOD_ID { get; set;}
        public DateTime? BILDIRIM_TARIH { get; set;}
        public string SYMBOL { get; set;}
        public decimal? FIYAT { get; set;}
        public string ACIKLAMA { get; set;}
        [Required]
        public int IS_BILDIRIM_TELEGRAMDAN_GONDERILDI { get; set;}
        public DateTime? TELEGRAM_BILDIRIM_GONDERIM_TARIH { get; set;}
        public string COLUMN2 { get; set;}
        public string COLUMN3 { get; set;}
        public string COLUMN4 { get; set;}
        [Required]
        public int ISDELETED { get; set;}
        public long? CREATEDUSER { get; set;}
        public DateTime? CREATEDDATE { get; set;}
        public long? MODIFIEDUSER { get; set;}
        public DateTime? MODIFIEDDATE { get; set;}
    }
	
    
   // public class T_u1555990_borsav2_t_bildirimMapper : AutoClassMapper<T_u1555990_borsav2_t_bildirim> --ae değişiklik
	public class t_bildirimMapper : AutoClassMapper<t_bildirim>
    {
        //public T_u1555990_borsav2_t_bildirimMapper() --ae değişiklik
		public t_bildirimMapper()
            : base()
        {
            Schema("u1555990_borsav2");
        }
    }
 
	//public enum T_u1555990_borsav2_t_bildirim_Properties {--ae değişiklik
	public enum t_bildirim_Properties {

		ID,
		BILDIRIM_TIP_KOD_ID,
		BILDIRIM_TARIH,
		SYMBOL,
		FIYAT,
		ACIKLAMA,
		IS_BILDIRIM_TELEGRAMDAN_GONDERILDI,
		TELEGRAM_BILDIRIM_GONDERIM_TARIH,
		COLUMN2,
		COLUMN3,
		COLUMN4,
		ISDELETED,
		CREATEDUSER,
		CREATEDDATE,
		MODIFIEDUSER,
		MODIFIEDDATE,
		
	}	
}

#pragma warning restore 1591
