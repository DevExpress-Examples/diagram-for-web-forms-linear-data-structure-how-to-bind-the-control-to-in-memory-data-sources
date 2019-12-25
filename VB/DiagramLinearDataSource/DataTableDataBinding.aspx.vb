Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace DiagramLinearDataSource
	Partial Public Class DataTableDataBinding
		Inherits System.Web.UI.Page

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

		End Sub

		Protected Sub ResetButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			Session.Clear()
		End Sub
	End Class
End Namespace