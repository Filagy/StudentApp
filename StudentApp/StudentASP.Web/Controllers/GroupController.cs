using Microsoft.AspNetCore.Mvc;
using StudentASP.Domain.Interfaces;
using StudentASP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentASP.Web.Controllers
{
    
    public class GroupController : Controller
    {
        private readonly IGroupsRepository _groupsRepository;

        public GroupController(IGroupsRepository groupsRepository)
        {
            _groupsRepository = groupsRepository;
        }

        [Route("GetAllGroups")]
        [HttpGet]
        public async Task<IActionResult> GetGroups()
        {
            List<Group> groups = await _groupsRepository.GetGroupsAsync();

            return View(groups);
        }
    }
}
