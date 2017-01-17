<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/NestedMasterPage.master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="WebShop.Admin.Order" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="../../../Content/order.css" rel="stylesheet" />

    <asp:FormView runat="server"
        ID="formview"
        ClientIDMode="Static"
        RenderOuterTable="false"
        DefaultMode="ReadOnly"
        ItemType="WebShop.Admin.Models.OrderViewModel"
        SelectMethod="GetOrder">
        <ItemTemplate>
            <table id="orderDetails">
                <tr>
                    <td>Имя:</td>
                    <td>Страна:</td>
                    <td>Город:</td>
                    <td>Email:</td>
                    <td>Комментраий к заказу:</td>
                    <td>Суммарная цена заказа:</td>
                    <td>Служба доставки:</td>
                </tr>

                <tr>
                    <td>
                        <%# Item.Customer %></td>
                    <td>
                        <%# Item.Country %></td>
                    <td>
                        <%# Item.Town %></td>
                    <td>
                        <%# Item.Email %></td>
                    <td>
                        <%# Item.Comment %></td>
                    <td>
                        <%# Item.SummaryPrice %></td>
                    <td>
                        <%# Item.DeliveryService %></td>
                </tr>

            </table>


            <asp:Repeater ID="Repeater1"
                ItemType="WebShop.Admin.Models.OrderedProductViewModel"
                DataSource="<%# Item.OrderedItems %>"
                runat="server">
                <HeaderTemplate>
                    <table id="orderedProducts">
                        <tr>
                            <td></td>
                            <td>Название</td>
                            <td>грн/м</td>
                            <td>Длина</td>
                            <td>Кол.</td>
                            <td>Цена</td>
                            <td>Артикул</td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Image ID="Image1" ImageUrl=" <%# Item.ThumbImgPath %>" runat="server" />
                        </td>
                        <td>
                            <a href='<%# string.Format("/шнур/{0}", Item.ProductID) %>'><%# Item.Name %></a></td>
                        <td><%# Item.PricePerItem %></td>
                        <td><%# Item.Length %></td>
                        <td><%# Item.Amount %></td>
                        <td><%# Item.Price %></td>
                        <td><%# Item.SKU %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
