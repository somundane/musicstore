<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfirmUser.aspx.cs" Inherits="FinalProj.ConfirmUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.css" rel="stylesheet" />
    <link href="Styles/masterstyle.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.9.1.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <link rel="stylesheet" type="text/css" href="Styles/preset.css" />

</head>

<body>
    <div class="panel panel-warning">
        <div class="panel-heading">
            <h2>Confirm User Info</h2>
        </div>
        <form id="form2" runat="server">
            <div class="panel-body">
                <td colspan="2">
                    <div class="d-inline" style="font-size: 30px;">
                        <b>
                            <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                        </b>
                    </div>
                    <div class="d-inline" style="font-size: 20px;" style="margin-top: 15px;">
                        <asp:Label ID="lblUn" runat="server" Text=""></asp:Label>
                    </div>
                </td>

                <div class="form-group" style="margin-top:25px;">
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn" OnClick="btnCancel_Click" />
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-success" OnClick="btnSubmit_Click" />
                </div>
            </div>
        </form>
    </div>
</body>
</html>
