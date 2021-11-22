using Microsoft.AspNetCore.Mvc;
using StudentASP.Domain.Interfaces;
using StudentASP.Domain.Models;
using StudentASP.Web.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentASP.Web.Controllers
{
    
    public class StudentsController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            List<Student> students = await _studentRepository.GetAllStudentsAsync();
            return View(students);
        }
        
    }
}
