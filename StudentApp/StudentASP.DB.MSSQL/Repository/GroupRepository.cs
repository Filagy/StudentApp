using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentASP.Domain.Interfaces;
using StudentASP.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentASP.DataAccess.MSSQL.Repository
{

    public class GroupRepository : IGroupsRepository
    {

        private readonly StudentAppDbContext _studentAppDbContext;
        private readonly IMapper _mapper;

        public GroupRepository(
            StudentAppDbContext studentAppDbContext,
            IMapper mapper)
        {
            _studentAppDbContext = studentAppDbContext;
            _mapper = mapper;
        }
        public async Task<List<Group>> GetGroupsAsync()
        {
            var groups = await _studentAppDbContext.Groups
                //.Include(x=>x.TeacherClassroom)
                //.Include(x=>x.Students)
                //.ThenInclude(x=>x.Scores)
                .ToListAsync();

            return _mapper.Map<List<Entities.Group>, List<Group>>(groups);
        }
    }
}
