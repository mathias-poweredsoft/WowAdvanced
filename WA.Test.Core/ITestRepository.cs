using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WA.Test.Core.Models;

namespace WA.Test.Core
{
    public interface ITestRepository
    {
        Task<string> AddAsync(AddTestModel model);

        Task<IEnumerable<TestModel>> FindAllAsync(FindAllTestModel model);
    }
}
