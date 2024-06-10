using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.DAL.Repository
{
    public class GenericRepository<T> : _BaseRepository<T> where T : class
    {
        
        public GenericRepository() : base()
        {
        }

    }
}
