using System.Collections.Generic;
using JqueryMVCRazor_DAL;

namespace JqueryMVCRazor_Repository
{
    public class ListEmployeesViewModel
    {
       
        //public employeeList EmployeeList;
        public List<EditEmployeeViewModel> EmployeeListViewModel;
        public void Initialize()
        {
           var DepartmentList = new departmentList();
            DepartmentList.Load();
            EmployeeListViewModel = new List<EditEmployeeViewModel>();
            var EmployeeList = new employeeList();
            EmployeeList.Load();//TODO: in real application make paging/sorting
            foreach (var item in EmployeeList)
            {
                EditEmployeeViewModel evm = new EditEmployeeViewModel();
                evm.DepartmentList = DepartmentList;
                evm.Employee = item;
                EmployeeListViewModel.Add(evm);
            }


        }
    }
    public class EditEmployeeViewModel
    {
        public departmentList DepartmentList{get;set;}//need the list to put in dropdown
        public employee Employee { get; set; }
        public EditEmployeeViewModel()
        {
            
        }
        public EditEmployeeViewModel(int id)
        {
            DepartmentList = new departmentList();
            DepartmentList.Load();
            var EmployeeList = new employeeList();
            Employee=EmployeeList.LoadId(id);
        }
         
    }
}
