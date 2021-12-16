using AutoMapper;
using StudentASP.Application.Exceptions;
using StudentASP.Application.Validators;
using StudentASP.Domain.Models;
using StudentASP.Domain.Repositories;
using StudentASP.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentASP.Application.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;

        public GroupService(
            IGroupRepository groupRepository,
            IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }


        public async Task<Group> Get(int numberGroup)
        {
            if (numberGroup <= default(int))
                throw new ArgumentNullException();

            var group = await _groupRepository.GetById(numberGroup);

            if (group == null)
                throw new NotFoundException(nameof(group), group);
            else
                return group;
        }

        public Task<List<Group>> Get()
        {
            var groups = _groupRepository.GetAll();

            if (groups is null)
                throw new ApplicationException("Группы еще не были добавлены");
            else
                return groups;
        }

        public async Task<int> Create(Group newGroup)
        {
            if (newGroup is null)
            {
                throw new ArgumentNullException(nameof(newGroup));
            }

            var validator = new GroupValidator();
            var validationResult = await validator.ValidateAsync(newGroup);
            if (validationResult.IsValid == false)
            {
                var errors = validationResult.ToString(", ");
                throw new InvalidOperationException(errors);
            }

            var existedGroup = _groupRepository.GetById(newGroup.NumberGroup);
            if (existedGroup is null)
            {
                throw new ApplicationException("This group already exist");
            }

           return await _groupRepository.Create(newGroup);
        }

        public Task<string> Delete(int numberGroup)
        {
            throw new NotImplementedException();
        }



        public Task<int> Update(Group group)
        {
            throw new NotImplementedException();
        }
    }
}
