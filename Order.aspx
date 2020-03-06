<%@ Page Language="C#" MasterPageFile="~/Employee.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="FinalProj.Order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:Panel ID="pnlOut" runat="server"></asp:Panel>
    <div class="d-inline" style="font-size: 15px; margin-top: 15px; text-align: center;">
        <asp:Label ID="lblOrd" runat="server" Text=""></asp:Label>
    </div>

</asp:Content>
