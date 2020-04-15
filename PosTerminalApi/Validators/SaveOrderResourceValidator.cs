using FluentValidation;
using PosTerminalApi.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosTerminalApi.Validators
{
    public class SaveOrderResourceValidator : AbstractValidator<SaveOrderResource>
    {
        public SaveOrderResourceValidator()
        {
            RuleFor(m => m.OrderedProducts)
                .NotEmpty()
                .MaximumLength(200);
        }
    }
}
