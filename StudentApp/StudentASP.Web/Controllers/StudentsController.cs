using Microsoft.AspNetCore.Mvc;
using StudentASP.Domain.Interfaces;
using StudentASP.Domain.Models;
using StudentASP.Web.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentASP.Web.Controllers
{
    /// <summary>
    /// Controller to work with Students
    /// </summary>
    public class StudentsController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        /// <summary>
        /// All students with scores, class teacher, subjects.
        /// </summary>
        /// <returns>Students</returns>
        [Route("AllStudents")]
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            List<Student> students = await _studentRepository.GetAllStudentsAsync();
            return View(students);
        }
        
    }
}
