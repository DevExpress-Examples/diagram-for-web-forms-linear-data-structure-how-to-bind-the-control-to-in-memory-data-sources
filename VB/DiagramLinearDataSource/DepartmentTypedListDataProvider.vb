Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports System.Web

Namespace DiagramLinearDataSource
	Public Class Department
		Public Property ID() As Integer
		Public Property ParentID() As Integer
		Public Property DepartmentName() As String

		Public Sub New()
		End Sub

		Public Sub New(ByVal id As Integer, ByVal parentId As Integer, ByVal departmentName As String)
			Me.ID = id
			Me.ParentID = parentId
			Me.DepartmentName = departmentName
		End Sub
	End Class
	Public Module DepartmentTypedListDataProvider
		Private ReadOnly Property Departments() As List(Of Department)
			Get
				Dim data = TryCast(HttpContext.Current.Session("DiagramTypeListNodes"), List(Of Department))
				If data Is Nothing Then
					data = New List(Of Department) From {
						New Department(1, 0, "Corporate Headquarters"),
						New Department(2, 1, "Sales and Marketing"),
						New Department(3, 1, "Finance"),
						New Department(4, 1, "Engineering"),
						New Department(5, 2, "Field Office: Canada"),
						New Department(6, 2, "Field Office: East Coast"),
						New Department(7, 2, "Pacific Rim Headquarters"),
						New Department(8, 2, "Marketing"),
						New Department(9, 4, "Consumer Electronics Div."),
						New Department(10, 4, "Software Products Div."),
						New Department(11, 7, "Field Office: Singapore"),
						New Department(12, 7, "Field Office: Japan"),
						New Department(13, 9, "Software Development"),
						New Department(14, 10, "Quality Assurance"),
						New Department(15, 10, "Customer Support"),
						New Department(16, 10, "Research and Development"),
						New Department(17, 10, "Customer Services")
					}
					HttpContext.Current.Session("DiagramTypeListNodes") = data
				End If
				Return data
			End Get
		End Property

		<DataObjectMethod(DataObjectMethodType.Select, True)>
		Public Function GetDepartments() As List(Of Department)
			Return Departments
		End Function

		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Function InsertDepartment(ByVal department As Department) As Integer
'INSTANT VB NOTE: The variable departments was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim departments_Renamed As List(Of Department) = Departments
			department.ID = If(Departments.Count = 0, 1, Departments.Max(Function(i) i.ID) + 1)
			departments_Renamed.Add(department)
			Return department.ID
		End Function

		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Sub UpdateDepartment(ByVal department As Department)
'INSTANT VB NOTE: The variable departments was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim departments_Renamed As List(Of Department) = Departments
			Dim departmentToUpdate = departments_Renamed.Find(Function(i) i.ID = department.ID)
			departmentToUpdate.ParentID = department.ParentID
			departmentToUpdate.DepartmentName = department.DepartmentName
		End Sub

		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Sub DeleteDepartment(ByVal department As Department)
			Dim nodes As List(Of Department) = Departments
			nodes.RemoveAll(Function(x) x.ID = department.ID)
		End Sub
	End Module
End Namespace
