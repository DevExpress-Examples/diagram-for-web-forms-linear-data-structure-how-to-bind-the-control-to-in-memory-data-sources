<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="DataTableDataBinding.aspx.vb" Inherits="DiagramLinearDataSource.DataTableDataBinding" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dx:ASPxDiagram ID="Diagram" runat="server" Width="100%" Height="600px" SimpleView="true"
            NodeDataSourceID="DepartmentDataSource">
            <Mappings>
                <Node Key="ID" Text="DepartmentName" ParentKey="ParentID" />
            </Mappings>
        </dx:ASPxDiagram>

        <dx:ASPxButton ID="ResetButton" runat="server" Text="Reset" OnClick="ResetButton_Click"></dx:ASPxButton>

        <asp:ObjectDataSource ID="DepartmentDataSource" runat="server"
            TypeName="DiagramLinearDataSource.DepartmentDataTableDataProvider"
            SelectMethod="GetDepartments" 
            InsertMethod="InsertDepartment"
            UpdateMethod="UpdateDepartment"
            DeleteMethod="DeleteDepartment">
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>