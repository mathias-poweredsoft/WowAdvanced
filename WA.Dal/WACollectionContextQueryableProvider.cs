using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WA.Dal.Core;

namespace WA.Dal
{
    public class WACollectionContextQueryableProvider<T> : IQueryableProvider<T>
        where T : class
    {
        private readonly WAContext collectionContext;

        public WACollectionContextQueryableProvider(WAContext collectionContext)
        {
            this.collectionContext = collectionContext;
        }

        public Task<IQueryable<T>> GetQueryableAsync() => Task.FromResult(collectionContext.GetCollection<T>().AsQueryable());
    }
}
