using Microsoft.AspNetCore.Mvc;
using StudentASP.Domain.Interfaces;
using StudentASP.Web.ViewModels;

namespace StudentASP.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentsRepository _allStudents;

        public StudentsController(IStudentsRepository allStudents)
        {
            _allStudents = allStudents;
        }

        public async Task<IActionResult> GetAllStudents()
        {

            return View();
        }
        public ViewResult BadStudents()
        {


            return View();
        }
    }
}
