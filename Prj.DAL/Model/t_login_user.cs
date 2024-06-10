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


    //[Dapper.Contrib.Extensions.Table("u1555990_borsav2.t_login_user")] --ae değişiklik
	[Dapper.Contrib.Extensions.Table("t_login_user")]

    //public partial class T_u1555990_borsav2_t_login_user --ae değişiklik
	 public partial class t_login_user    {
		//public T_u1555990_borsav2_t_login_user()--ae değişiklik
		public t_login_user()
		{
		}

        //public static string SchemeName { get { return "u1555990_borsav2"; } }
        public static string GetSchema() { return "u1555990_borsav2"; }

        //[AutoIncrement]
		[Dapper.Contrib.Extensions.Key]
        public int ID { get; set;}
        [Required]
        public long USER_ID { get; set;}
        public string USER_NAME { get; set;}
        public string TOKEN { get; set;}
        public string IP_ADRESI { get; set;}
        public string USER_AGENT { get; set;}
        public DateTime? EXP_DATE { get; set;}
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
	
    
   // public class T_u1555990_borsav2_t_login_userMapper : AutoClassMapper<T_u1555990_borsav2_t_login_user> --ae değişiklik
	public class t_login_userMapper : AutoClassMapper<t_login_user>
    {
        //public T_u1555990_borsav2_t_login_userMapper() --ae değişiklik
		public t_login_userMapper()
            : base()
        {
            Schema("u1555990_borsav2");
        }
    }
 
	//public enum T_u1555990_borsav2_t_login_user_Properties {--ae değişiklik
	public enum t_login_user_Properties {

		ID,
		USER_ID,
		USER_NAME,
		TOKEN,
		IP_ADRESI,
		USER_AGENT,
		EXP_DATE,
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
