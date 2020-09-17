using PoweredSoft.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WA.Dal;
using WA.Dal.Collections;
using WA.Dal.Core;
using WA.Test.Core;
using WA.Test.Core.Models;

namespace WA.Test
{
    public class TestRepository : ITestRepository
    {
        private readonly WAContext collectionContext;
        private readonly IQueryableProvider<TestCollection> testQueryableProvider;
        private readonly IAsyncQueryableService queryableService;

        public TestRepository(WAContext collectionContext, IQueryableProvider<TestCollection> testQueryableProvider, IAsyncQueryableService queryableService)
        {
            this.collectionContext = collectionContext;
            this.testQueryableProvider = testQueryableProvider;
            this.queryableService = queryableService;
        }

        public async Task<string> AddAsync(AddTestModel model)
        {
            var collection = new TestCollection();
            collection.CreatedTime = DateTime.Now;
            collection.Value = model.Value;
            collection.IsTrusted = model.IsTrusted;

            await collectionContext.Tests.AddAsync(collection);
            return collection.Id;
        }

        public async Task<IEnumerable<TestModel>> FindAllAsync(FindAllTestModel model)
        {
            var queryable = await testQueryableProvider.GetQueryableAsync();

            if (model.IsTrusted.HasValue)
                queryable = queryable.Where(t => t.IsTrusted == model.IsTrusted.Value);

            if (string.IsNullOrWhiteSpace(model.Value))
                queryable = queryable.Where(t => t.Value.ToLower().Contains(model.Value.ToLower()));

            var result = await queryableService.ToListAsync(queryable);
            return result.Select(t => new TestModel()
            {
                CreatedTime = t.CreatedTime,
                Id = t.Id,
                IsTrusted = t.IsTrusted,
                Value = t.Value
            });
        }
    }
}
