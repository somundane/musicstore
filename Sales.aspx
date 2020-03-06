<%@ Page Language="C#" MasterPageFile="Employee.Master" AutoEventWireup="true" CodeBehind="Sales.aspx.cs" Inherits="FinalProj.Sales" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
        <div>
            <asp:GridView ID="grvSale" runat="server" HeaderStyle-CssClass="active" CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ></asp:GridView>
        </div>
</asp:Content>
