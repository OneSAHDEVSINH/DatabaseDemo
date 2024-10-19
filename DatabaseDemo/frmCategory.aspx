<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCategory.aspx.cs" Inherits="DatabaseDemo.frmCategory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lblState" runat="server" />
        <asp:LinkButton ID="lnlbtnNewCategory" Text="New Category"
            runat="server" OnClick="lnlbtnNewCategory_Click" />
        <div>
            <asp:GridView ID="gvCategory" runat="server" AutoGenerateColumns="false" DataKeyNames="CategoryId" AllowPaging="true" PagerSettings-Position="Bottom" OnPageIndexChanging="gvCategory_PageIndexChanging"
                PagerSettings-Mode="NextPreviousFirstLast" PagerSettings-PreviousPageText="P" PagerSettings-NextPageText="N" PagerSettings-LastPageText="L"  PagerSettings-FirstPageText="F" PageSize="3" PageIndex="0"
               OnSelectedIndexChanged="gvCategory_SelectedIndexChanged1" AlternatingRowStyle-BackColor="Tomato">
                <Columns>
                    <asp:BoundField HeaderText="Category" DataField="Name" />
                    <asp:BoundField HeaderText="Is Active" DataField="IsActive" />
                    <asp:CheckBoxField HeaderText="Is Active" DataField="IsActive" />

                    <asp:ButtonField Text="Edit" CommandName="Select" HeaderText="Edit" ButtonType="Link"/>


                </Columns>
                </asp:GridView>
        </div>
        <asp:Panel ID="pnlCategory" runat="server" GroupingText="Category" Visible="false">
        <div>
            
            <asp:Label ID="lblCategoryName" runat="server" Text="Category Name"
                AssociatedControlID="txtCategoryName" />
            <asp:TextBox runat="server" ID="txtCategoryName" />
        </div>
        <div>
            <asp:Label ID="lblIsActive" runat="server"
                AssociatedControlID="chkIsActive" Text="Is Active" />
            <asp:CheckBox ID="chkIsActive" Checked="true" runat="server" />
        </div>
        <div>
            <asp:Button ID="btnSave" runat="server" Text="Save"
                OnClick="btnSave_Click" />
            <asp:Button ID="btnReset" runat="server" Text="Reset"
                OnClick="btnReset_Click" />
            <asp:Button ID="btnClose" runat="server" Text="Close"
                OnClick="btnClose_Click"/>
            

        </div>
            </asp:Panel>
    </form>
</body>
</html>
