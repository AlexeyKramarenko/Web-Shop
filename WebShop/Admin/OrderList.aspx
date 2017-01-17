<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/NestedMasterPage.master" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="WebShop.Admin.OrderList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../../Content/order.list.css" rel="stylesheet" />
    <script src="../../../Scripts/order.js"></script>
     
    <asp:Repeater OnItemCommand="Repeater1_ItemCommand" ID="Repeater1" ItemType="WebShop.Admin.Models.OrderItemViewModel" SelectMethod="GetOrders" runat="server">
        <HeaderTemplate>
            <table id="orderList">
                <tr>
                    <td>ID</td>
                    <td>Заказчик</td>
                    <td>Дата заказа</td>
                    <td></td>
                    <td></td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>#<%# Item.OrderID %></td>
                <td><%# Item.Customer %></td>
                <td><%# Item.Date %></td>
                <td><a href="/админ/заказ/<%# Item.OrderID %>">Открыть</a></td>
                <td>
                    <asp:LinkButton ID="LinkButton1" name="<%# Item.OrderID %>" OnClientClick="return order.orderDeleteConfirmation(this);" CommandArgument="<%# Item.OrderID %>" CommandName="Delete" runat="server">Удалить</asp:LinkButton></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
