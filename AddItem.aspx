<%@ Page Language="C#" MasterPageFile="Employee.Master" AutoEventWireup="true" CodeBehind="AddItem.aspx.cs" Inherits="FinalProj.AddItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

        <div class="panel panel-success">
            <div class="panel-heading">
                <h2>Add Inventory Item</h2>
            </div>
            <div class="panel-body">
                <div class="form-group">
                        <asp:Label ID="Label1" runat="server" Text="SKU"></asp:Label>
                        <asp:RequiredFieldValidator ID="reqSKU" ForeColor="Red" runat="server" controltovalidate="txtSKU" ErrorMessage="*"></asp:RequiredFieldValidator>             
                    <asp:RegularExpressionValidator ID="valSKU" ControlToValidate="txtSKU" runat="server" ErrorMessage="Input must be numeric" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                    <asp:TextBox ID="txtSKU" runat="server" CssClass="form-control" MaxLength="6" onkeypress="return allowOnlyNumber(event);"></asp:TextBox>
                       
                </div>
                <div class="form-group">
                     <asp:Label ID="Label2" runat="server" Text="Album Title"></asp:Label>
                    <asp:RequiredFieldValidator ID="reqAlbum" ForeColor="Red" runat="server" controltovalidate="txtAlbum" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtAlbum" runat="server" CssClass="form-control"></asp:TextBox>             
                </div>
                 <div class="form-group">
                     <asp:Label ID="Label5" runat="server" Text="Artist Name"></asp:Label>
                     <asp:RequiredFieldValidator ID="reqArtist" ForeColor="Red" runat="server" controltovalidate="txtArtist" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtArtist" runat="server" CssClass="form-control"></asp:TextBox>             
                </div>
                <div class="form-group">
                     <asp:Label ID="Label3" runat="server" Text="Quantity"></asp:Label>
                    <asp:RequiredFieldValidator ID="reqQty" ForeColor="Red" runat="server" controltovalidate="txtQty" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtQty" runat="server" CssClass="form-control" onkeypress="return allowOnlyNumber(event);"></asp:TextBox>             
                </div>

                <div class="form-group">
                     <asp:Label ID="Label4" runat="server" Text="Price"></asp:Label>
                    <asp:RequiredFieldValidator ID="reqPrice" ForeColor="Red" runat="server" controltovalidate="txtPrice" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" onkeypress="return allowNumDot(event);"></asp:TextBox>             
                </div>

                <div style ="margin: 15px 0px 15px 0px;">
                    <asp:RequiredFieldValidator ID="reqFile" ForeColor="Red" runat="server" controltovalidate="flUpload" ErrorMessage="*Album cover required"></asp:RequiredFieldValidator>
                    <asp:FileUpload ID="flUpload" runat="server" />
                </div>

                <div class="form-group">
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn" OnClick="btnCancel_Click" CausesValidation="false" />
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-success" OnClick="btnSubmit_Click"/>
                </div>
            </div>
        </div>
   
</asp:Content>