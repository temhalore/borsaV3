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


    //[Dapper.Contrib.Extensions.Table("u1555990_borsav2.t_user")] --ae değişiklik
	[Dapper.Contrib.Extensions.Table("t_user")]

    //public partial class T_u1555990_borsav2_t_user --ae değişiklik
	 public partial class t_user    {
		//public T_u1555990_borsav2_t_user()--ae değişiklik
		public t_user()
		{
		}

        //public static string SchemeName { get { return "u1555990_borsav2"; } }
        public static string GetSchema() { return "u1555990_borsav2"; }

        //[AutoIncrement]
		[Dapper.Contrib.Extensions.Key]
        public int ID { get; set;}
        public string AD { get; set;}
        public string SOYAD { get; set;}
        public string CEP_TELEFON { get; set;}
        public string USER_NAME { get; set;}
        public string EMAIL { get; set;}
        public string SIFRE { get; set;}
        public string AKTIVASYON_KOD { get; set;}
        [Required]
        public int AKTIF { get; set;}
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
	
    
   // public class T_u1555990_borsav2_t_userMapper : AutoClassMapper<T_u1555990_borsav2_t_user> --ae değişiklik
	public class t_userMapper : AutoClassMapper<t_user>
    {
        //public T_u1555990_borsav2_t_userMapper() --ae değişiklik
		public t_userMapper()
            : base()
        {
            Schema("u1555990_borsav2");
        }
    }
 
	//public enum T_u1555990_borsav2_t_user_Properties {--ae değişiklik
	public enum t_user_Properties {

		ID,
		AD,
		SOYAD,
		CEP_TELEFON,
		USER_NAME,
		EMAIL,
		SIFRE,
		AKTIVASYON_KOD,
		AKTIF,
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
