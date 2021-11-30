using FluentValidation;
using StudentASP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentASP.Application.Validators
{
    public class GroupValidator : AbstractValidator<Group>
    {
        public GroupValidator()
        {
            RuleFor(x => x.NumberGroup).Empty();
            RuleFor(x => x.Students).Empty();
            RuleFor(x => x.TeacherClassroomId).NotEmpty();
        }
    }
}
