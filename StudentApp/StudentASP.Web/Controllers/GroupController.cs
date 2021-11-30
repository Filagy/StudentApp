using Microsoft.AspNetCore.Mvc;
using StudentASP.Domain.Models;
using StudentASP.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace StudentASP.Web.Controllers
{
    /// <summary>
    /// Controller to work with groups
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class GroupController : Controller
    {
        private readonly IGroupRepository _groupsRepository;

        public GroupController(IGroupRepository groupsRepository)
        {
            _groupsRepository = groupsRepository;
        }

        /// <summary>
        /// Groups with students and class teachers
        /// </summary>
        /// <returns>List groups</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<Group>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetGroups()
        {
            var groups = await _groupsRepository.GetAll();

            //return View(groups);
            return Ok(groups);
        }
    }
}
