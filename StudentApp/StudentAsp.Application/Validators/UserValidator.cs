using FluentValidation;
using StudentASP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentASP.Application.Validators
{
    class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).MinimumLength(8).MaximumLength(20);
        }
    }
}
