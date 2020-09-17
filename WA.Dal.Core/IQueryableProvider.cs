using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WA.Dal.Core
{
    public interface IQueryableProvider<T>
    {
        Task<IQueryable<T>> GetQueryableAsync();
    }
}
