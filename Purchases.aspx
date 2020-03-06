<%@ Page Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Purchases.aspx.cs" Inherits="FinalProj.Purchases" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:Panel ID="pnlOut" runat="server"></asp:Panel>
    <div class="d-inline" style="font-size: 15px; margin-top: 15px; text-align: center;">
        <asp:Label ID="lblPurch" runat="server" Text=""></asp:Label>
    </div>

</asp:Content>
