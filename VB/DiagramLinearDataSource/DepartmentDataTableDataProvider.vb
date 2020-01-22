Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Linq
Imports System.Web

Namespace DiagramLinearDataSource
	Public Module DepartmentDataTableDataProvider
		Private ReadOnly Property Departments() As DataTable
			Get
				Dim dataTable = TryCast(HttpContext.Current.Session("DiagramDataTableNodes"), DataTable)
				If dataTable Is Nothing Then
					dataTable = New DataTable()

					dataTable.Columns.Add("ID", GetType(Integer))
					dataTable.Columns.Add("ParentID", GetType(Integer))
					dataTable.Columns.Add("DepartmentName", GetType(String))

					dataTable.PrimaryKey = New DataColumn() { dataTable.Columns("ID") }

					dataTable.Rows.Add(1, 0, "Corporate Headquarters")
					dataTable.Rows.Add(2, 1, "Sales and Marketing")
					dataTable.Rows.Add(3, 1, "Finance")
					dataTable.Rows.Add(4, 1, "Engineering")
					dataTable.Rows.Add(5, 2, "Field Office: Canada")
					dataTable.Rows.Add(6, 2, "Field Office: East Coast")
					dataTable.Rows.Add(7, 2, "Pacific Rim Headquarters")
					dataTable.Rows.Add(8, 2, "Marketing")
					dataTable.Rows.Add(9, 4, "Consumer Electronics Div.")
					dataTable.Rows.Add(10, 4, "Software Products Div.")
					dataTable.Rows.Add(11, 7, "Field Office: Singapore")
					dataTable.Rows.Add(12, 7, "Field Office: Japan")
					dataTable.Rows.Add(13, 9, "Software Development")
					dataTable.Rows.Add(14, 10, "Quality Assurance")
					dataTable.Rows.Add(15, 10, "Customer Support")
					dataTable.Rows.Add(16, 10, "Research and Development")
					dataTable.Rows.Add(17, 10, "Customer Services")

					HttpContext.Current.Session("DiagramDataTableNodes") = dataTable
				End If
				Return dataTable
			End Get
		End Property

		<DataObjectMethod(DataObjectMethodType.Select, True)>
		Public Function GetDepartments() As DataTable
			Return Departments
		End Function

		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Function InsertDepartment(ByVal parentId As Integer, ByVal departmentName As String) As Integer
			Dim newId As Integer = DirectCast(Departments.Compute("max([ID])", String.Empty), Integer) + 1
			Departments.Rows.Add(newId, parentId, departmentName)
			Return newId
		End Function

		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Sub UpdateDepartment(ByVal id As Integer, ByVal parentId As Integer, ByVal departmentName As String)
			Dim departmentToUpdate = Departments.Rows.Find(id)
			departmentToUpdate("ParentID") = parentId
			departmentToUpdate("DepartmentName") = departmentName
		End Sub

		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Sub DeleteDepartment(ByVal id As Integer)
			Dim dr As DataRow = Departments.Rows.Find(id)
			Departments.Rows.Remove(dr)
		End Sub
	End Module
End Namespace
