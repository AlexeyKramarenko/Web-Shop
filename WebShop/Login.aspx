<%@ Page Title="Логин"  EnableViewState="false"  Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebShop.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Content/login.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="server">

    <div id="login">
        <div>
            <asp:FormView runat="server"
                RenderOuterTable="false"
                DefaultMode="Insert"
                ItemType="WebShop.Models.LoginViewModel"
                InsertMethod="LoginUser">
                <InsertItemTemplate>
                    <table>
                        <tr>
                            <td>Имя:</td>
                            <td>
                                <asp:TextBox ID="TextBox1" Text="<%# BindItem.UserName %>" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Пароль:</td>
                            <td>
                                <asp:TextBox ID="TextBox2" TextMode="Password" Text="<%# BindItem.Password %>" runat="server"></asp:TextBox></td>
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
            
        </div>
        <asp:ValidationSummary
                ID="valSummary"
                runat="server"
                ClientIDMode="Static"
                HeaderText="Исправьте следующие ошибки:"
                ShowModelStateErrors="true"
                DisplayMode="BulletList"
                EnableClientScript="true"
                ForeColor="Red" />
    </div>
</asp:Content>
