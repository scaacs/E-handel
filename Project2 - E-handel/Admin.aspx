<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Project2___E_handel.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    &nbsp;
 <table style="width: 10%;" class ="textboxes">
                <tr>
                    <td>Art nr</td>
                    <td>Produktnamn</td>
                    <td>Pris</td>
                    <td>Kategori</td>
                    <td>Beskrivning</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TextBoxArtNr" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBoxProductName" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBoxPrice" runat="server"></asp:TextBox></td>
                      <td>
                        <asp:TextBox ID="TextBoxCategory" runat="server"></asp:TextBox></td>
                      <td>
                        <asp:TextBox ID="TextBoxDescription" runat="server"></asp:TextBox></td>
                </tr>
            </table>
    <asp:ListBox ID="ListBoxProducts" runat="server" AutoPostBack="True" Height="293px" OnSelectedIndexChanged="ListBoxProducts_SelectedIndexChanged" Width="929px"></asp:ListBox>
    <asp:Button ID="ButtonCreateProduct" runat="server" OnClick="ButtonCreateProduct_Click" Text="Lägg till produkt" />
    <asp:Button ID="ButtonUpdate" runat="server" OnClick="ButtonUpdate_Click" Text="Uppdatera produkt" />
    <asp:Button ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" Text="Ta bort produkt" />
    <asp:Button ID="ButtonBackToMain" runat="server" OnClick="ButtonBackToMain_Click" Text="Till startsidan" />
</asp:Content>
