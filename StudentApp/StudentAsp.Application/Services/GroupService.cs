using AutoMapper;
using StudentASP.Application.Exeptions;
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

        public Task<IEnumerable<Group>> Get()
        {
            var groups = _groupRepository.GetAll();

            if (groups == null)
                throw new ApplicationException("Группы еще не были добавлены");
            else
                return groups;
        }

        public Task<string> Create(Group group)
        {
            throw new NotImplementedException();
        }

        public Task<string> Delete(int numberGroup)
        {
            throw new NotImplementedException();
        }



        public Task<string> Update()
        {
            throw new NotImplementedException();
        }
    }
}
