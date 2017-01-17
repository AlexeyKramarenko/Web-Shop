<%@ Page Title="Оформление заказа"  EnableViewState="false"  Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderInformation.aspx.cs" Inherits="WebShop.OrderInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Content/order.information.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="server">
    
    <asp:FormView runat="server"
        RenderOuterTable="false"
        ID="orderForm"
        DefaultMode="Insert"
        ItemType="WebShop.Models.OrderViewModel"
        InsertMethod="SendOrder">
        <InsertItemTemplate>
            <table id="orderForm">
                <tr class="header">
                    <td colspan="2">ИМЯ</td>
                </tr>
                <tr class="details">
                    <td>Имя :</td>
                    <td>
                        <asp:TextBox ID="TextBox1" Text="<%# BindItem.FirstName %>" runat="server"></asp:TextBox></td>
                </tr>
                <tr class="details">
                    <td>Фамилия :</td>
                    <td>
                        <asp:TextBox ID="TextBox2" Text="<%# BindItem.LastName %>" runat="server"></asp:TextBox></td>
                </tr>
                <tr class="header">
                    <td colspan="3">АДРЕС ДОСТАВКИ</td>
                </tr>
                <tr class="details">
                    <td>Страна :</td>
                    <td>
                        <asp:TextBox ID="TextBox4" Text="<%# BindItem.Country %>" runat="server"></asp:TextBox></td>
                </tr>
                <tr class="details">
                    <td>Город :</td>
                    <td>
                        <asp:TextBox ID="TextBox7" Text="<%# BindItem.Town %>" runat="server"></asp:TextBox></td>
                </tr>
                <tr class="header">
                    <td colspan="3">КОНТАКТНЫЕ ДАННЫЕ</td>
                </tr>
                <tr class="details">
                    <td>Email :</td>
                    <td>
                        <asp:TextBox ID="TextBox5" Text="<%# BindItem.Email %>" runat="server"></asp:TextBox></td>
                </tr>
                <tr class="details">
                    <td>Телефон :</td>
                    <td>
                        <asp:TextBox ID="TextBox3" Text="<%# BindItem.PhoneNumber %>" runat="server"></asp:TextBox></td>
                </tr>
                <tr class="header">
                    <td colspan="2">КОММЕНТАРИЙ К ЗАКАЗУ</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div>
                            <asp:TextBox ID="TextBox6" Text="<%# BindItem.Comment %>" TextMode="Multiline" runat="server"></asp:TextBox>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:LinkButton ID="sendOrder" ClientIDMode="Static" CommandName="Insert" runat="server">Отправить заказ</asp:LinkButton>
                    </td>
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
        DisplayMode="BulletList"
        EnableClientScript="true"
        ForeColor="Red" />

    <asp:Panel ID="panelOrderSucceded" ClientIDMode="Static" Visible="false" runat="server">
        Ваш заказ принят. Подождите когда продавец с Вами свяжится.
    </asp:Panel>
     

</asp:Content>
