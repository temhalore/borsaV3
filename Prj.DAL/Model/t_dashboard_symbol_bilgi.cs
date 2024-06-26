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


    //[Dapper.Contrib.Extensions.Table("u1555990_borsav2.t_dashboard_symbol_bilgi")] --ae değişiklik
	[Dapper.Contrib.Extensions.Table("t_dashboard_symbol_bilgi")]

    //public partial class T_u1555990_borsav2_t_dashboard_symbol_bilgi --ae değişiklik
	 public partial class t_dashboard_symbol_bilgi    {
		//public T_u1555990_borsav2_t_dashboard_symbol_bilgi()--ae değişiklik
		public t_dashboard_symbol_bilgi()
		{
		}

        //public static string SchemeName { get { return "u1555990_borsav2"; } }
        public static string GetSchema() { return "u1555990_borsav2"; }

        //[AutoIncrement]
		[Dapper.Contrib.Extensions.Key]
        public int ID { get; set;}
        public DateTime? TARIH { get; set;}
        public string SYMBOL { get; set;}
        [Required]
        public decimal FIYAT { get; set;}
        [Required]
        public decimal DEGISIM { get; set;}
        [Required]
        public decimal VOLUME { get; set;}
        [Required]
        public decimal EN_YUKSEK_ANLIK { get; set;}
        [Required]
        public decimal EN_DUSUK_ANLIK { get; set;}
        [Required]
        public decimal EN_YUKSEK_SON24 { get; set;}
        [Required]
        public decimal EN_DUSUK_SON24 { get; set;}
        [Required]
        public decimal ALICI_ANLIK_TEKLIF { get; set;}
        [Required]
        public decimal SATICI_ANLIK_TEKLIF { get; set;}
        [Required]
        public decimal ONCEKI_GUN_KAPANIS { get; set;}
        public DateTime? ACILIS_TARIH { get; set;}
        [Required]
        public decimal ACILIS_FIYATI { get; set;}
        public string PERIYOT_1 { get; set;}
        [Required]
        public decimal P1_MA7 { get; set;}
        [Required]
        public decimal P1_MA_25 { get; set;}
        [Required]
        public decimal P1_MA_99 { get; set;}
        [Required]
        public decimal P1_RSI { get; set;}
        [Required]
        public decimal P1_MACD_HISTOGRAM { get; set;}
        public string PERIYOT_2 { get; set;}
        [Required]
        public decimal P2_MA7 { get; set;}
        [Required]
        public decimal P2_MA_25 { get; set;}
        [Required]
        public decimal P2_MA_99 { get; set;}
        [Required]
        public decimal P2_RSI { get; set;}
        [Required]
        public decimal P2_MACD_HISTOGRAM { get; set;}
        public string PERIYOT_3 { get; set;}
        [Required]
        public decimal P3_MA7 { get; set;}
        [Required]
        public decimal P3_MA_25 { get; set;}
        [Required]
        public decimal P3_MA_99 { get; set;}
        [Required]
        public decimal P3_RSI { get; set;}
        [Required]
        public decimal P3_MACD_HISTOGRAM { get; set;}
        [Required]
        public int ISDELETED { get; set;}
        public long? CREATEDUSER { get; set;}
        public DateTime? CREATEDDATE { get; set;}
        public long? MODIFIEDUSER { get; set;}
        public DateTime? MODIFIEDDATE { get; set;}
    }
	
    
   // public class T_u1555990_borsav2_t_dashboard_symbol_bilgiMapper : AutoClassMapper<T_u1555990_borsav2_t_dashboard_symbol_bilgi> --ae değişiklik
	public class t_dashboard_symbol_bilgiMapper : AutoClassMapper<t_dashboard_symbol_bilgi>
    {
        //public T_u1555990_borsav2_t_dashboard_symbol_bilgiMapper() --ae değişiklik
		public t_dashboard_symbol_bilgiMapper()
            : base()
        {
            Schema("u1555990_borsav2");
        }
    }
 
	//public enum T_u1555990_borsav2_t_dashboard_symbol_bilgi_Properties {--ae değişiklik
	public enum t_dashboard_symbol_bilgi_Properties {

		ID,
		TARIH,
		SYMBOL,
		FIYAT,
		DEGISIM,
		VOLUME,
		EN_YUKSEK_ANLIK,
		EN_DUSUK_ANLIK,
		EN_YUKSEK_SON24,
		EN_DUSUK_SON24,
		ALICI_ANLIK_TEKLIF,
		SATICI_ANLIK_TEKLIF,
		ONCEKI_GUN_KAPANIS,
		ACILIS_TARIH,
		ACILIS_FIYATI,
		PERIYOT_1,
		P1_MA7,
		P1_MA_25,
		P1_MA_99,
		P1_RSI,
		P1_MACD_HISTOGRAM,
		PERIYOT_2,
		P2_MA7,
		P2_MA_25,
		P2_MA_99,
		P2_RSI,
		P2_MACD_HISTOGRAM,
		PERIYOT_3,
		P3_MA7,
		P3_MA_25,
		P3_MA_99,
		P3_RSI,
		P3_MACD_HISTOGRAM,
		ISDELETED,
		CREATEDUSER,
		CREATEDDATE,
		MODIFIEDUSER,
		MODIFIEDDATE,
		
	}	
}

#pragma warning restore 1591
