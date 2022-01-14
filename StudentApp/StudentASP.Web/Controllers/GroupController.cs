using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentASP.Domain.Services;
using StudentASP.Web.Contracts;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace StudentASP.Web.Controllers
{
    /// <summary>
    /// Controller to work with groups
    /// </summary>
    public class GroupController : ApiController
    {
        private readonly IGroupService _groupService;
        private readonly IMapper _mapper;

        public GroupController(
            IGroupService groupService,
            IMapper mapper)
        {
            _groupService = groupService;
            _mapper = mapper;
        }

        /// <summary>
        /// Groups with students and class teachers
        /// </summary>
        /// <returns>List groups</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<Domain.Models.Group>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var groups = await _groupService.Get();
            var listGroups = _mapper
                .Map<IEnumerable<Domain.Models.Group>, IEnumerable<Contracts.Group>>(groups);
            
            return Ok(new GroupList { groups = listGroups });
        }

        [HttpGet("{numberGroup}")]
        public async Task<IActionResult> Get(int numberGroup)
        {
            var groupService = await _groupService.Get(numberGroup);
            var groupContract = _mapper.Map<Domain.Models.Group, Contracts.Group>(groupService);

            return Ok(groupContract);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NewGroup newGroup)
        {
            var group = _mapper.Map<Contracts.NewGroup, Domain.Models.Group>(newGroup);
            var id = await _groupService.Create(group);
            return Ok(id);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int numberGroup)
        {
            return Ok();
        }

    }
}
