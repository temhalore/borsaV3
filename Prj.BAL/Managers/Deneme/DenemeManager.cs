using AutoMapper;
using Microsoft.AspNetCore.Http;
using Prj.BAL.Managers.Deneme.Interfaces;
using Prj.BAL.Managers.Helper.Interfaces;
using Prj.BAL.Managers.Uygulama.Interfaces;
using Prj.DAL.Model;
using Prj.DAL.Repository;

namespace Prj.BAL.Managers.Deneme
{
    public class DenemeManager : IDenemeManager
    {
     
        private IHelperManager _helperManager;
      private readonly IHttpContextAccessor _httpContextAccessor;
        private IMapper _mapper;
      private IKodManager _kodManager;



        public DenemeManager(
            IHelperManager helperManager
            , IHttpContextAccessor httpContextAccessor
            ,IMapper mapper
            ,IKodManager kodManager
          )

        {

            _helperManager = helperManager;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _kodManager = kodManager;

        }

        public string getTestString()
        {

            return "aaaaaaaaaa";
        }


        public List<string> GetDBTableNameList()
        {
            var repo = new GenericRepository<t_kod>();

            var tableNameList = repo.Query<string>("SELECT  TABLE_SCHEMA+'.'+TABLE_NAME   FROM INFORMATION_SCHEMA.TABLES order by TABLE_SCHEMA+'.'+TABLE_NAME", null).ToList();

            return tableNameList;
        }
    }
}