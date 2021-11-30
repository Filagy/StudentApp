using FluentValidation;
using StudentASP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentASP.Application.Validators
{
    public class ScoreValidator : AbstractValidator<Score>
    {
        public ScoreValidator()
        {
            RuleFor(x => x.StudentId).NotEmpty();
            RuleFor(x => x.Date).NotEmpty();
            RuleFor(x => x.Value).NotEmpty();
            RuleFor(x => x.Subject).NotEmpty();
        }
    }
}
