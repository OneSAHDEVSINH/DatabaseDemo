<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmProduct.aspx.cs" Inherits="DatabaseDemo.frmProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <div class="container m-2">
    <form id="form1" runat="server">
        <div class="row m-1">
            <div class="col-sm-2 mt-1">
            <asp:Label ID="lblCategory" Text="Category" runat="server" CssClass="form-label"></asp:Label>
            </div>
            <div class ="col-sm-4">
                <asp:DropDownList ID="ddlcategory" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
            <div class="col-sm-3">
                <asp:Button ID="btnSearch" CssClass="btn btn-success" runat="server" OnClick="btnSearch_Click" Text="Search" />
            </div>
        </div>
        <hr />
        <div class ="mt-2">
            <asp:DataList ID="dlProduct" runat="server" AlternatingItemStyle-CssClass="bg-light"
                RepeatDirection="Horizontal" DataKeyField="ProductId" OnSelectedIndexChanged="dlProduct_SelectedIndexChanged" RepeatLayout="Flow">
                <HeaderTemplate>
                    <div class="row border fs-4 border-1 rounded-1 bg-secondary text-light">
                        <div class="col-sm-3">
                            <asp:Label ID="tblName" Text="Name" runat="server"></asp:Label>
                        </div>
                        <div class="col-sm-2">
                            <asp:Label ID="lblQty" Text="Qty" runat="server"></asp:Label>
                         </div>
                        <div class="col-sm-2">
                             <asp:Label ID="lblRate" Text="Rate" runat="server"></asp:Label>
                        </div>
                        <div class="col-sm-2">
                              <asp:Label ID="lblCategory" Text="Category" runat="server"></asp:Label>
                        </div>
                        <div class="col-sm-2">
                              <asp:Label ID="lblAction" Text="Action" runat="server"></asp:Label>
                        </div>
                    </div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="row bg-light border-top border-1 rounded-1 border-info fs-4">
                        <div class="col-sm-3">
                            <%# Eval("Name") %>
                        </div>
                        <div class="col-sm-2">
                            <%# Eval("Qty") %>
                        </div>
                        <div class="col-sm-2">
                            <%# Eval("Rate") %>
                        </div>
                        <div class="col-sm-2">
                            <%# Eval("Category") %>
                        </div>
                        <div class="col-sm-2">
                            <asp:LinkButton ID="lnkbtnSelect" runat="server" Text="Select" CssClass="text-dark" CommandName="Select"></asp:LinkButton>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </form>
        </div>
    <script src="Scripts/jquery-3.7.1.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</body>
</html>