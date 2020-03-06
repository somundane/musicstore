<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserReg.aspx.cs" Inherits="FinalProj.UserReg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.css" rel="stylesheet" />
    <link href="Styles/masterstyle.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.9.1.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/JavaScript.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="panel panel-success">
            <div class="panel-heading">
                <h2>Create New User</h2>
            </div>
            <div class="panel-body">

                <div class="form-group">
                    <asp:Label ID="Label6" runat="server" Text="First Name"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ControlToValidate="txtFn" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtFn" runat="server" CssClass="form-control" style="text-transform: capitalize;"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label2" runat="server" Text="Last Name"></asp:Label>
                    <asp:RequiredFieldValidator ID="reqAlbum" ForeColor="Red" runat="server" ControlToValidate="txtLn" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtLn" runat="server" CssClass="form-control" style="text-transform: capitalize;"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label5" runat="server" Text="Username"></asp:Label>
                    <asp:RequiredFieldValidator ID="reqArtist" ForeColor="Red" runat="server" ControlToValidate="txtUn" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtUn" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label3" runat="server" Text="Password"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server" ControlToValidate="txtPass" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label7" runat="server" Text="Re-Enter Password"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" runat="server" ControlToValidate="txtPass2" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtPass2" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn" OnClick="btnCancel_Click" CausesValidation="false" />
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-success" OnClick="btnSubmit_Click"/>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
