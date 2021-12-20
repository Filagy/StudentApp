using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentASP.Domain.Interfaces;
using StudentASP.Domain.Services;
using StudentASP.Web.Contracts;
using StudentASP.Web.ViewModels;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace StudentASP.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    /// <summary>
    /// Controller to work with Students
    /// </summary>
    public class StudentController : ControllerBase
    {
        private readonly IStudentsService _studentsService;
        private readonly IMapper _mapper;

        public StudentController(
            IStudentsService studentsService,
            IMapper mapper)
        {
            _studentsService = studentsService;
            _mapper = mapper;
        }

        /// <summary>
        /// All students with scores, class teacher, subjects.
        /// </summary>
        /// <returns>Students</returns>
        [HttpGet]
        [ProducesResponseType(typeof(StudentsList), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var students = await _studentsService.Get();

            var result = _mapper
                .Map<List<Domain.Models.Student>, List<Student>>(students);

            return Ok(new StudentsList { Students = result });
        }

        /// <summary>
        /// One student with scores, class teacher, subjects.
        /// </summary>
        /// <returns>Student</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Student), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            var student = await _studentsService.Get(id);

            var result = _mapper
                .Map<Domain.Models.Student, Student>(student);

            return Ok(result);
        }

    }
}
