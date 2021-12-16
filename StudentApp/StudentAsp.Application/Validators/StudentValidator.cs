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
            RuleFor(x => x.NumberGroup).ExclusiveBetween(134, 136);
            RuleFor(x => x.FirstName).NotNull().Length(2,20);
            RuleFor(x => x.LastName).NotNull().Length(2,20);
            RuleForEach(x => x.Subjects).SetValidator(new SubjectValidator());
        }
    }
}
