using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Demo.ViewModels;
using Microsoft.EntityFrameworkCore;
namespace Demo.Controllers
{
    public class StudentController : Controller
    {
        ITIEntity context = new ITIEntity();
        public IActionResult GetStudent()
        {
            List<string> branches = new List<string>();
            branches.Add("Alex");
            branches.Add("Assiut");
            branches.Add("Smart");
            branches.Add("Menia");

            ViewData["brc"] = branches;
            // ViewData["temp"] = 44;
            ViewBag.temp = 44;
            
            ViewBag.color = "red";

            ViewData["temp"] = 55;
            ViewData["msg"] = "Hello FRom Action";


            Student stdModel = context.Students.FirstOrDefault();
            return View(stdModel);//view="GetStudent" Model ="student"
        }
        public IActionResult Edit(int id)
        {
            Student student = context.Students.FirstOrDefault(s=>s.Id == id);//Model
            ViewData["DeptList"] = context.Departments.ToList();
            return View(student);
        }

        [HttpPost]
        public IActionResult SaveEdit(int id,Student newStd) 
        {
            Student oldStudent = context.Students.FirstOrDefault(s => s.Id == id);
            if (newStd.Name!=null&& newStd.Age > 10 )
            {
                //get old object
                oldStudent.Name = newStd.Name;
                oldStudent.Address = newStd.Address;
                oldStudent.Age = newStd.Age;
                oldStudent.Image = newStd.Image;
                oldStudent.Dept_Id = newStd.Dept_Id;
                context.SaveChanges();
                return RedirectToAction("Index");
                //save
            }
            //model 
            ViewData["DeptList"] = context.Departments.ToList();

            return View("Edit", newStd);
        }

        public IActionResult Index()
        {
            return View(context.Students.Include(s=>s.Department).ToList());
        }
        public IActionResult GetStudentUsingViewModel(int id)
        {
            //get Model
            Student stdModel=context.Students.FirstOrDefault(s=>s.Id==id);

            List<string> branches = new List<string>();
            branches.Add("Alex");
            branches.Add("Assiut");
            branches.Add("Smart");
            branches.Add("Menia");

            StudentBranchesTempMSgViewModel stdViewModel = 
                new StudentBranchesTempMSgViewModel();
            stdViewModel.StdName = stdModel.Name;
            stdViewModel.StdId = stdModel.Id;
            stdViewModel.Msg = "Hello";
            stdViewModel.Color = "blue";
            stdViewModel.Temp = 20;
            stdViewModel.Branches = branches;

            return View(stdViewModel);

        }
    }
}
