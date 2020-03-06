<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditItem.aspx.cs" Inherits="FinalProj.EditItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.css" rel="stylesheet" />
    <link href="Styles/masterstyle.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.9.1.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <link rel="stylesheet" type="text/css" href="Styles/preset.css"/>
    <script src="Scripts/JavaScript.js"></script>

</head>
<body>

    <div class="panel panel-success">
        <div class="panel-heading">
            <h2>Edit Item</h2>
        </div>
        <div class="panel-body">
            <form id="form2" runat="server">
                <div class="form-group">
                    <asp:Label ID="Label1" runat="server" Text="SKU"></asp:Label>
                    <asp:TextBox ID="txtSKU" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label2" runat="server" Text="Album Title"></asp:Label>
                    <asp:TextBox ID="txtAlbum" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label5" runat="server" Text="Artist Name"></asp:Label>
                    <asp:TextBox ID="txtArtist" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label3" runat="server" Text="Quantity"></asp:Label>
                    <asp:TextBox ID="txtQty" runat="server" CssClass="form-control" onkeypress="return allowOnlyNumber(event);"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label4" runat="server" Text="Price"></asp:Label>
                    <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" onkeypress="return allowNumDot(event);"></asp:TextBox>
                </div>

                <div style ="margin: 15px 0px 15px 0px;">
                    <asp:FileUpload ID="flUpload" runat="server" />
                </div>

                <div class="form-group">
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn" OnClick="btnCancel_Click" />
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-success" OnClick="btnSubmit_Click" />
                </div>

                <div class="form-group">
                    <asp:Button ID="btnDel" runat="server" Text="Delete this item" CssClass="btn-link" OnClick="btnDel_Click" OnClientClick="if(!confirm('Are you sure you want to delete this entry?')) return false;"/>
                </div>
            </form>
        </div>
    </div>


</body>
</html>
