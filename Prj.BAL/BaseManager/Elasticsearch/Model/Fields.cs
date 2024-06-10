using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.BAL.BaseManager.Elasticsearch.Model
{
    public class Fields
    {
        public string oysToken { get; set; }
        public string SourceContext { get; set; }
        public string Application { get; set; }
        public string RemoteIPAddress { get; set; }
        public string Elapsed { get; set; }

    }
}
