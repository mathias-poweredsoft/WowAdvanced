using FluentValidation;
using FluentValidation.Validators;
using PoweredSoft.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WA.Dal.Collections;
using WA.Dal.Core;
using WA.Test.Core.Models;

namespace WA.Test.Validators
{
    public class AddTestValidator : AbstractValidator<AddTestModel>
    {
        static List<string> BadWords = new List<string>{
            "BadWord",
            "AnOtherBadWord"
        };
        private readonly IQueryableProvider<TestCollection> testQueryableProvider;
        private readonly IAsyncQueryableService queryableService;

        public AddTestValidator(IQueryableProvider<TestCollection> testQueryableProvider, IAsyncQueryableService queryableService)
        {
            this.testQueryableProvider = testQueryableProvider;
            this.queryableService = queryableService;

            RuleFor(t => t.IsTrusted)
                .NotEmpty();

            RuleFor(t => t.Value)
                .NotEmpty()
                .CustomAsync(ValueValidation);
        }

        private async Task ValueValidation(string value, CustomContext context, CancellationToken cancellationToken)
        {
            // lower case all the words in the list
            var list = BadWords.Select(t => t.ToLower());

            if (list.Contains(value.ToLower()))
                context.AddFailure("Hey! Don't use bad words.");

            var queryable = await testQueryableProvider.GetQueryableAsync();
            if (await queryableService.AnyAsync(queryable.Where(t => t.Value.ToLower() == value.ToLower())))
                context.AddFailure($"{value} already exist.");
        }
    }
}
