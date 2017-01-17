<%@ Page Title="Контакты"  EnableViewState="false"  Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contacts.aspx.cs" Inherits="WebShop.Contacts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Content/contacts.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="server">
    
    <asp:FormView runat="server"
         RenderOuterTable="false"
        DefaultMode="Insert"
        ItemType="WebShop.Models.MessageViewModel"
        InsertMethod="SendMessage">
        <InsertItemTemplate>
            <table id="contactsForm">
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>Имя:</td>
                    <td>
                        <asp:TextBox ID="TextBox1" Text="<%# BindItem.UserName %>" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Email:</td>
                    <td>
                        <asp:TextBox ID="TextBox2" Text="<%# BindItem.Email %>" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Сообщение:</td>
                    <td>
                        <asp:TextBox ID="TextBox3" TextMode="MultiLine" Text="<%# BindItem.Text %>" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button CommandName="Insert"
                            runat="server"
                            Text="Отправить" /></td>
                </tr>
            </table>
        </InsertItemTemplate>
    </asp:FormView>
      <asp:ValidationSummary
        ID="valSummary"
        runat="server"
        ClientIDMode="Static"
        HeaderText="Исправьте следующие ошибки:"
        ShowModelStateErrors="true"
        DisplayMode="List"
        EnableClientScript="true"
        ForeColor="Red" />
</asp:Content>
