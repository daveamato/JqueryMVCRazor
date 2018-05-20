using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JqueryMVCRazor_DAL;
using JqueryMVCRazor_Repository;

namespace JqueryMVCRazor_Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome jquery demo for MVC(please click on each button)!";
            ListEmployeesViewModel lee = new ListEmployeesViewModel();
            lee.Initialize();           
            return View(lee);
        }

        public ActionResult About()
        {
            return View();
        }
        public ActionResult AddNewEmployee()
        {
            
            EditEmployeeViewModel evm = new EditEmployeeViewModel();
            evm.DepartmentList = new departmentList();
            evm.DepartmentList.Load();
            evm.Employee = new employee(0,"New !",evm.DepartmentList[0]);
            return PartialView("~/Views/Shared/EditorTemplates/EditEmployeeViewModel.cshtml", evm);//TODO: use T4MVC
        }
        
        [HttpPost]
        public ActionResult DeleteEmployee(int id)
        {
            try
            {
                if(id %2 ==0 )
                    throw new ArgumentException(" this employee can not be deleted! " + id+ " % 2 == 0");
                return Json(new {ok = true, message = ""});
            }
            catch (Exception ex)
            {
                return Json(new {ok = false, message = ex.Message});
            }
        }
        [HttpPost]
        public ActionResult GetEmployeesForDepartment(long id)
        {
            try
            {
                //in real application made a better load / retrieving
                var emp = new employeeList();
                emp.Load();
                emp.RemoveAll(item => item.iddepartament != id);
                
                return Json(new { ok = true, data = emp, message = "ok" });
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, message = ex.Message });
            }
        }
    [HttpPost]
        public ActionResult DepartmentList()
    {
        try
        {
            departmentList dep = new departmentList();
            dep.Load();
            
            return Json(new { ok = true,data=dep, message = "ok"});
        }
        catch (Exception ex)
        {
            return Json(new { ok = false, message = ex.Message });
        }
    }
        [HttpPost]
        public ActionResult SaveEmployee(employee emp)
        {
            try
            {
                
                if (emp.IdEmployee % 2 == 0)
                    throw new ArgumentException(" this "+emp.NameEmployee +" can not be saved! " + emp.IdEmployee + " % 2 == 0");
                
                return Json(new { ok = true, message = "saved employee " + emp.NameEmployee });
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, message = ex.Message });
            }
        }
    }
}
