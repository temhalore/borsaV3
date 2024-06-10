
using Prj.COMMON.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.BAL.BaseManager.Elasticsearch.Interfaces
{
    public interface IElasticsearchManager
    {
        void DeleteLogs(DateTime beginDatetime, string levels, string patern, string message, int page = 0);
        object GetLogsByOysToken(LogRequestDTO logRequestDTO);
        object GetLogsByOysTokenList(List<string> oysTokenlist, LogRequestDTO logRequestDTO);
    }
}
