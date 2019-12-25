<!-- default file list -->
*Files to look at*:

* [TypedListDataBinding.aspx](./CS/DiagramLinearDataSource/TypedListDataBinding.aspx) (VB: [TypedListDataBinding.aspx](./VB/DiagramLinearDataSource/TypedListDataBinding.aspx))
* [DepartmentTypedListDataProvider.cs](./CS/DiagramLinearDataSource/NodesTypedListDataProvider.cs) (VB: [DepartmentTypedListDataProvider.vb](./VB/DiagramLinearDataSource/NodesTypedListDataProvider.vb))
* [DataTableDataBinding.aspx](./CS/DiagramLinearDataSource/DataTableDataBinding.aspx) (VB: [DataTableDataBinding.aspx](./VB/DiagramLinearDataSource/DataTableDataBinding.aspx))
* [DepartmentDataTableDataProvider.cs](./CS/DiagramLinearDataSource/DepartmentDataTableDataProvider.cs) (VB: [DepartmentDataTableDataProvider.vb](./VB/DiagramLinearDataSource/DepartmentDataTableDataProvider.vb))
<!-- default file list end -->

# Diagram for Web Forms - Tree from Linear Data Structure - How to bind the control to in-memory data sources

Unlike declarative *DataSource controls (such as AccessDataSource, SqlDataSource, LinqDataSource, EntityDataSource, and so on), custom in-memory data sources (such as List\<T>, DataTable and so on) do not allow you to automatically perform CRUD operations. These custom CRUD operations' logic can be implemented with the help of ObjectDataSource. This example demonstrates how to bind the Diagram control to ObjectDataSource and implement custom CRUD operations at the data source level. 

In this example, the Diagram control transform a linear data structure to a tree-like diagram. The  [NodeDataSourceID](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxDiagram.ASPxDiagram.NodeDataSourceID)  property specifies which data source the control is bound to. To transform a linear data structure to hierarchical, the data source should contain two additional fields:

-   The first field - assigned to the  [Key](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxDiagram.DiagramMappingInfo.Key)  property and contains unique values.
-   The second field - assigned to the  [ParentKey](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxDiagram.DiagramNodeMappingInfo.ParentKey)  property and contains values that indicate the current node's parent nodes.

You can bind other node settings to the data source. Assign field values to the corresponding settings in the  [Mappings.Node](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxDiagram.DiagramNodeMappingInfo._properties)  property.