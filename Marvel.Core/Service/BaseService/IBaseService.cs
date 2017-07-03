using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marvel.Core.Service.BaseService
{
    public interface IBaseService<T> where T : class
    {
        Task<T> Get(string ruta);

    }
}
