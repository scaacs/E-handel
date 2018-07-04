<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Project2___E_handel.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListBox ID="ListBoxProducts" runat="server" Height="400px" Width="250px" OnSelectedIndexChanged="ListBoxProducts_SelectedIndexChanged"></asp:ListBox>
    <asp:TextBox ID="TextBoxProductName" runat="server"></asp:TextBox>
</asp:Content>
