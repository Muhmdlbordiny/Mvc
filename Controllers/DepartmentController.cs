using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Demo.Controllers
{
    public class DepartmentController : Controller
    {
        ITIEntity context = new ITIEntity();
        public IActionResult NewDept()
        {
            //open page New department
            return View(new Department());//view="New",Model=null
        }
        
        [HttpPost]//<form method="post">
        public IActionResult SaveNEw(Department dept)//property name ==Inpyut name
        {
            #region comment
            //savedb
            //get data from client using request

            //map dept model
            //add new department
            //index-detais
            #endregion
            if (dept.Name != null&&dept.ManagerName !=null)
            {
                context.Departments.Add(dept);
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View("NEw", dept);
            return RedirectToAction("DEatils", new { id = dept.Id });
        }

        public IActionResult Index()
         {
            List<Department> deptList= context.Departments.ToList();

            //return View("Index",deptList);//view =index ,Model = deptlist
            return View(deptList);        //view =Index ,Model =deptList
            //return View("Index");//view=Index,Model=null
            //return View();//view=index ,Model =null
        }
        //department/details/1
        //department/deatils?id=1
        public IActionResult Details(int id)
        {
            Department dept= context.Departments.FirstOrDefault(d => d.Id == id);
            return View("DEtails", dept);
        }
    }
}
