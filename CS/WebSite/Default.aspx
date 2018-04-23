<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dx:ASPxGridView ID="ASPxGridView1" DataSourceID="nwd" Settings-ShowHeaderFilterButton="true" OnHeaderFilterFillItems="ASPxGridView1_HeaderFilterFillItems" runat="server"></dx:ASPxGridView>
        <asp:AccessDataSource ID="nwd" DataFile="~/App_Data/Northwind.mdb" runat="server" SelectCommand="SELECT [CategoryID], [CategoryName], [Description] FROM [Categories]" ></asp:AccessDataSource>
    </div>
    </form>
</body>
</html>
