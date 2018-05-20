using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JqueryMVCRazor_DAL
{
    public class employee
    {
        public employee()
        {
            Department = new department();
        }
        public long IdEmployee { get; set; }
        public string NameEmployee { get; set; }
        public department Department;
        public long iddepartament
        {
            get { return Department.IdDepartment; }
            set { Department.IdDepartment = value; }
        }
        public employee(long idEmployee, string nameEmployee, department department)
        {
            this.IdEmployee = idEmployee;
            this.NameEmployee = nameEmployee;
            this.Department = department;
        }

    }

    public class employeeList : List<employee>
    {
        public void Load()
        {
            //TODO: use a real database
            departmentList dl = new departmentList();
            dl.Load();
            this.Add(new employee(1, "Andrei Ignat", dl[0]));
            this.Add(new employee(2, "Someone from HR", dl[1]));
        }

        public employee LoadId(int id)
        {
            //TODO : in real application must read database
            this.Load();
            return this[id];
        }
    }
}
