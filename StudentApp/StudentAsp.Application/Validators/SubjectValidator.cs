using FluentValidation;
using StudentASP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentASP.Application.Validators
{
    public class SubjectValidator : AbstractValidator<Subject>
    {
        public SubjectValidator()
        {
            RuleFor(x => x.TeacherId).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
        }
    }
}
