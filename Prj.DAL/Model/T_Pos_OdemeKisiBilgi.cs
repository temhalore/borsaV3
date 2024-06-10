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


    [Dapper.Contrib.Extensions.Table("Pos.OdemeKisiBilgi")]

    public partial class T_Pos_OdemeKisiBilgi    {
		public T_Pos_OdemeKisiBilgi()
		{
		}

        //public static string SchemeName { get { return "Pos"; } }
        public static string GetSchema() { return "Pos"; }

        //[AutoIncrement]
		[Dapper.Contrib.Extensions.Key]
        public int ID { get; set;}
        [Required]
        public string CLIENT_KISI_ID { get; set;}
        [Required]
        public string AD { get; set;}
        [Required]
        public string SOYAD { get; set;}
        public string EMAIL { get; set;}
        public string TELEFON { get; set;}
        public string TC { get; set;}
        public string PASAPORT_NO { get; set;}
        public string ULKE { get; set;}
        public string IL { get; set;}
        public string ILCE { get; set;}
        public string ACIK_ADRES { get; set;}
        [Required]
        public int UYGULAMA_ID { get; set;}
        [Required]
        public bool ISDELETED { get; set;}
        public long? CREATEDUSER { get; set;}
        public DateTime? CREATEDDATE { get; set;}
        public long? MODIFIEDUSER { get; set;}
        public DateTime? MODIFIEDDATE { get; set;}
        public string CREATEDIP { get; set;}
        public string MODIFIEDIP { get; set;}
    }
	
    
    public class T_Pos_OdemeKisiBilgiMapper : AutoClassMapper<T_Pos_OdemeKisiBilgi>
    {
        public T_Pos_OdemeKisiBilgiMapper()
            : base()
        {
            Schema("Pos");
        }
    }
 
	public enum T_Pos_OdemeKisiBilgi_Properties {

		ID,
		CLIENT_KISI_ID,
		AD,
		SOYAD,
		EMAIL,
		TELEFON,
		TC,
		PASAPORT_NO,
		ULKE,
		IL,
		ILCE,
		ACIK_ADRES,
		UYGULAMA_ID,
		ISDELETED,
		CREATEDUSER,
		CREATEDDATE,
		MODIFIEDUSER,
		MODIFIEDDATE,
		CREATEDIP,
		MODIFIEDIP,
		
	}	
}

#pragma warning restore 1591
