using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;

namespace DiagramLinearDataSource
{
    public static class DepartmentDataTableDataProvider
    {
        private static DataTable Departments
        {
            get
            {
                var dataTable = HttpContext.Current.Session["DiagramDataTableNodes"] as DataTable;
                if (dataTable == null)
                {
                    dataTable = new DataTable();

                    dataTable.Columns.Add("ID", typeof(int));
                    dataTable.Columns.Add("ParentID", typeof(int));
                    dataTable.Columns.Add("DepartmentName", typeof(string));

                    dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["ID"] };

                    dataTable.Rows.Add(1, 0, "Corporate Headquarters");
                    dataTable.Rows.Add(2, 1, "Sales and Marketing");
                    dataTable.Rows.Add(3, 1, "Finance");
                    dataTable.Rows.Add(4, 1, "Engineering");
                    dataTable.Rows.Add(5, 2, "Field Office: Canada");
                    dataTable.Rows.Add(6, 2, "Field Office: East Coast");
                    dataTable.Rows.Add(7, 2, "Pacific Rim Headquarters");
                    dataTable.Rows.Add(8, 2, "Marketing");
                    dataTable.Rows.Add(9, 4, "Consumer Electronics Div.");
                    dataTable.Rows.Add(10, 4, "Software Products Div.");
                    dataTable.Rows.Add(11, 7, "Field Office: Singapore");
                    dataTable.Rows.Add(12, 7, "Field Office: Japan");
                    dataTable.Rows.Add(13, 9, "Software Development");
                    dataTable.Rows.Add(14, 10, "Quality Assurance");
                    dataTable.Rows.Add(15, 10, "Customer Support");
                    dataTable.Rows.Add(16, 10, "Research and Development");
                    dataTable.Rows.Add(17, 10, "Customer Services");

                    HttpContext.Current.Session["DiagramDataTableNodes"] = dataTable;
                }
                return dataTable;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static DataTable GetDepartments()
        {
            return Departments;
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static int InsertDepartment(int parentId, string departmentName)
        {
            int newId = (int)Departments.Compute("max([ID])", string.Empty) + 1;
            Departments.Rows.Add(newId, parentId, departmentName);
            return newId;
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static void UpdateDepartment(int id, int parentId, string departmentName)
        {
            var departmentToUpdate = Departments.Rows.Find(id);
            departmentToUpdate["ParentID"] = parentId;
            departmentToUpdate["DepartmentName"] = departmentName;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static void DeleteDepartment(int id)
        {
            DataRow dr = Departments.Rows.Find(id);
            Departments.Rows.Remove(dr);
        }
    }
}
