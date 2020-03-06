<%@ Page Language="C#" MasterPageFile="Employee.Master" AutoEventWireup="true" CodeBehind="EmpDefault.aspx.cs" Inherits="FinalProj.EmpDefault" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="panel panel-info">
        <div class="panel-heading">
            <h2 style="text-align: center;">Welcome to work</h2>
        </div>
        <div class="panel-body">
            <h3>Profile</h3>
            <img src="Images/default-profile-picture1.jpg" style="display: block; margin: auto; margin-top: 25px; height: 100px; width: 100px;" />
            <div style="text-align: center; margin-top:10px; font-weight:bold; font-size: 20px;">
                <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
                <h5> Employee since forever ago </h5>
            </div>
            <h3>Tasks</h3>
            <h5> Maybe one day employee tasks can be set here</h5>
            <h3>Shift details</h3>
            <h5>Maybe one day shift details can be put here</h5>

        </div>
    </div>
</asp:Content>
