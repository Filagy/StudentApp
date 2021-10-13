using Microsoft.AspNetCore.Mvc;
using StudentASP.Interfaces;
using StudentASP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentASP.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudents _allStudents;
        private readonly IStudents _badStudents;

        public StudentController(IStudents allStudents)
        {
            _allStudents = allStudents;
        }

        public ViewResult AllStudents()
        {
            var obj = new StudentListViewModel() { AllStudents = _allStudents.AllStudents, 
            Teachers = _allStudents.AllTeachers};
            
            return View(obj); 
        }
        public ViewResult BadStudents()
        {
            var obj = new StudentListViewModel()
            {
                BadStudents = _allStudents.BadStudents,
                Teachers = _allStudents.AllTeachers
            };

            return View(obj);
        }
    }
}
