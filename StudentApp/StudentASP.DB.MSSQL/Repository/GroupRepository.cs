using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentASP.Domain.Models;
using StudentASP.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentASP.DataAccess.MSSQL.Repository
{
    public class GroupRepository : IGroupRepository
    {
        private readonly DiaryAppDbContext _diaryAppDbContext;
        private readonly IMapper _mapper;

        public GroupRepository(
            DiaryAppDbContext diaryAppDbContext,
            IMapper mapper)
        {
            _diaryAppDbContext = diaryAppDbContext;
            _mapper = mapper;
        }

        public async Task<int> Create(Group newGroup)
        {
            if (newGroup is null)
            {
                throw new ArgumentNullException(nameof(newGroup));
            }

            var group = _mapper.Map<Group, Entities.Group>(newGroup);

            await _diaryAppDbContext.Groups.AddAsync(group);
            await _diaryAppDbContext.SaveChangesAsync();

            return group.NumberGroup;
        }

        public async Task Delete(Group deleteGroup)
        {
            if (deleteGroup is null)
                throw new ArgumentNullException(nameof(deleteGroup));

            var group = _mapper.Map<Group, Entities.Group>(deleteGroup);

            _diaryAppDbContext.Groups.Remove(group);
            await _diaryAppDbContext.SaveChangesAsync();
        }


        public async Task<Group> GetById(int? numberGroup)
        {
            if (numberGroup is null)
            {
                throw new ArgumentNullException(nameof(numberGroup));
            }

            var group = await _diaryAppDbContext.Groups
                .Where(x => x.NumberGroup == numberGroup)
                .FirstOrDefaultAsync();

            return _mapper.Map<Entities.Group, Group>(group);

        }

        public async Task<List<Group>> GetAll()
        {
            var groups = await _diaryAppDbContext.Groups
               .Include(x => x.TeacherClassroom)
               .Include(x => x.Students)
               .ThenInclude(x => x.Scores)
               .ToListAsync();

            return _mapper.Map<List<Entities.Group>, List<Group>>(groups);
        }


        public async Task Update(Group obj)
        {
            if (obj is null)
                throw new ArgumentNullException(nameof(obj));

            _diaryAppDbContext.Update(obj).State = EntityState.Modified;
            await _diaryAppDbContext.SaveChangesAsync();
        }

        public void Dispose() => _diaryAppDbContext.Dispose();
    }
}
