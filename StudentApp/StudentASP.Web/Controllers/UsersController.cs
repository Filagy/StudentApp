using Microsoft.AspNetCore.Mvc;
using StudentASP.Web.Contracts;
using System.Net;
using System.Threading.Tasks;

namespace StudentASP.Web.Controllers
{
    public class UsersController : ApiController
    {
        [HttpPost]
        [ProducesResponseType(typeof(int),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(NewUser newUser)
        {

            return Ok();
        } 
    }
}
