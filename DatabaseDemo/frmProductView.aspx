<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmProductView.aspx.cs" Inherits="DatabaseDemo.frmProductView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="mt-2">
                <asp:FormView ID="fvProduct" runat="server" RenderOuterTable="false" OnModeChanging="fvProduct_ModeChanging" DataKeyNames="ProductId" OnItemUpdating="fvProduct_ItemUpdating" OnItemDeleting="fvProduct_ItemDeleting">
                    <ItemTemplate>
                        <div class="card">
                            <div class="card-title text-center fs-2 fw-bold bg-light text-dark">
                                <p> <%# Eval("Name") %> </p>
                                <hr />
                            </div>
                            <div class="m-2 card-body bg-secondary text-white border border-1 rounded-1 fs-3">
                                <p>Qty: <%# Eval("Qty") %></p>
                                <p>Rate: <%# Eval("Rate") %></p>
                                <p>Category: <%# Eval("Category") %></p>
                            </div>
                            <div class="card-footer">
                                <div class="row">
                                    <div class="col-sm-2">
                                        <asp:Button ID="btnEdit" CssClass="btn btn-dark" CommandName="Edit" runat="server" Text="Edit" Width="50%" />
                                    </div>
                                    <div class="col-sm-2">
                                        <asp:Button ID="btnDelete" CssClass="btn btn-danger" CommandName="Delete" runat="server" Text="Delete" Width="50%" OnClientClick="returnconfirm('Are you sure?')" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <div class="bg-light p-1 border border-1 rounded-1">
                            <div class="row m-1">
                                <div class="col-sm-2">
                                    <asp:Label runat="server" ID="lblName" Text="Name" AssociatedControlID="txtName" CssClass="form-label" />
                                </div>
                                <div class="col-sm-5">
                                    <asp:TextBox runat="server" ID="txtName" Text='<%# Bind("Name") %>' CssClass="form-control" />
                                </div>
                                <div class="col-sm-3 mt-1">
                                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" Text="Product name Required" CssClass="text-danger fw-bold" ValidationGroup="Update" />
                                </div>
                            </div>
                            <div class="row m-1">
                                <div class="col-sm-2">
                                    <asp:Label runat="server" ID="lblQty" Text="Qty" AssociatedControlID="txtQty" CssClass="form-label" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox runat="server" ID="txtQty" Text='<%# Bind("Qty") %>' CssClass="form-control" />
                                    <asp:CompareValidator ID="cvQty" runat="server" ControlToValidate="txtQty" Operator="GreaterThanEqual" Type="Integer" ValueToCompare="1" ErrorMessage="Qty must be at least 1." CssClass="text-danger fw-bold"></asp:CompareValidator>
                                </div>
                                <div class="col-sm-2">
                                    <asp:Label runat="server" ID="lblRate" Text="Rate" AssociatedControlID="txtRate" CssClass="form-label" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox runat="server" ID="txtRate" Text='<%# Bind("Rate") %>' CssClass="form-control" />
                                    <asp:CompareValidator ID="cvRate" runat="server" ControlToValidate="txtRate" Operator="GreaterThanEqual" Type="Double" ValueToCompare="1" ErrorMessage="Rate must be at least 1."></asp:CompareValidator>
                                </div>
                            </div>
                            <div class="row m-1">
                                <div class="col-sm-2">
                                    <asp:Label ID="lblCategory" runat="server" Text="Category" AssociatedControlID="ddlCategory" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlCategory" CssClass="form-select" runat="server" />
                                </div>
                            </div>
                            <div class="row m-1">
                                <div class="col-sm-2">
                                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandName="Update" ValidationGroup="Update" CssClass="btn btn-outline-success" />
                                </div>
                                <div class="col-sm-2">
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CommandName="Cancel" CssClass="btn btn-outline-success" />
                                </div>
                            </div>
                        </div>
                    </EditItemTemplate>
                </asp:FormView>
            </div>
        </div>
    </form>
</body>
</html>
