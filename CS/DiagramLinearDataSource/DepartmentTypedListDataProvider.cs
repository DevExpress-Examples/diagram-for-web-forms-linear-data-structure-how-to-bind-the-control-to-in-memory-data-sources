using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DiagramLinearDataSource
{
    public class Department
    {
        public int ID { set; get; }
        public int ParentID { set; get; }
        public string DepartmentName { set; get; }

        public Department() { }

        public Department(int id, int parentId, string departmentName)
        {
            ID = id;
            ParentID = parentId;
            DepartmentName = departmentName;
        }
    }
    public static class DepartmentTypedListDataProvider
    {
        private static List<Department> Departments
        {
            get
            {
                var data = HttpContext.Current.Session["DiagramTypeListNodes"] as List<Department>;
                if (data == null)
                {
                    data = new List<Department>
                    {
                        new Department(1, 0, "Corporate\nHeadquarters"),
                        new Department(2, 1, "Sales and \nMarketing"),
                        new Department(3, 1, "Finance"),
                        new Department(4, 1, "Engineering"),
                        new Department(5, 2, "Field Office: \nCanada"),
                        new Department(6, 2, "Field Office:\nEast Coast"),
                        new Department(7, 2, "Pacific Rim \nHeadquarters"),
                        new Department(8, 2, "Marketing"),
                        new Department(9, 4, "Consumer \nElectronics Div."),
                        new Department(10, 4, "Software \nProducts Div."),
                        new Department(11, 7, "Field Office: \nSingapore"),
                        new Department(12, 7, "Field Office: \nJapan"),
                        new Department(13, 9, "Software \nDevelopment"),
                        new Department(14, 10, "Quality \nAssurance"),
                        new Department(15, 10, "Customer \nSupport"),
                        new Department(16, 10, "Research and \nDevelopment"),
                        new Department(17, 10, "Customer \nServices")
                    };
                    HttpContext.Current.Session["DiagramTypeListNodes"] = data;
                }
                return data;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Department> GetDepartments()
        {
            return Departments;
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static int InsertDepartment(Department department)
        {
            List<Department> departments = Departments;
            department.ID = Departments.Count == 0 ? 1 : Departments.Max(i => i.ID) + 1;
            departments.Add(department);
            return department.ID;
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static void UpdateDepartment(Department department)
        {
            List<Department> departments = Departments;
            var departmentToUpdate = departments.Find(i => i.ID == department.ID);
            departmentToUpdate.ParentID = department.ParentID;
            departmentToUpdate.DepartmentName = department.DepartmentName;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static void DeleteDepartment(Department department)
        {
            List<Department> nodes = Departments;
            nodes.RemoveAll(x => x.ID == department.ID);
        }
    }
}