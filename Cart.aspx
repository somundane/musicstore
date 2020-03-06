<%@ Page Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="FinalProj.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:Panel ID="pnlOut" runat="server"></asp:Panel>
    <div class="d-inline" style="font-size: 15px; margin-top: 15px; text-align: center;">
        <asp:Label ID="lblCart" runat="server" Text=""></asp:Label>
    </div>
    
    <div class="form-group" style="text-align: center;">
        <asp:Button ID="btnPurch" runat="server" Text="Confirm Purchase" CssClass="btn btn-success" OnClick="btnAdd_Click" />
    </div>

</asp:Content>
