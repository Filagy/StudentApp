using FluentValidation;
using StudentASP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentASP.Application.Validators
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(x => x.NumberGroup).NotEmpty();
            RuleFor(x => x.FirstName).Length(2,20);
            RuleFor(x => x.LastName).Length(2,20);
            RuleForEach(x => x.Subjects).SetValidator(new SubjectValidator());
        }
    }
}
