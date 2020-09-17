using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WA.Test.Core;
using WA.Test.Core.Models;

namespace WA.Api.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class TestController : BaseController
    {
        private readonly ITestRepository testRepository;

        public TestController(ITestRepository testRepository)
        {
            this.testRepository = testRepository;
        }

        [HttpPost]
        public async Task<string> AddAsync([FromBody]AddTestModel model) => await this.testRepository.AddAsync(model);

        [HttpPost]
        public async Task<IEnumerable<TestModel>> FindAllAsync([FromBody]FindAllTestModel model) => await this.testRepository.FindAllAsync(model);
    }
}
