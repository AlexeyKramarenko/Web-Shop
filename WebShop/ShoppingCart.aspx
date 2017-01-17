<%@ Page Title="Корзина товаров" EnableViewState="false"  Theme="Urban" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="WebShop.WebForm1" %>

<%@ Register Src="~/Controls/DeliveryServiceControl.ascx" TagPrefix="cart" TagName="DeliveryServiceControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Content/shopping.cart.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="server">
    
    <asp:HiddenField ID="sessionUserId" ClientIDMode="Static" runat="server" />

    <div id="productList">
        <asp:ListView runat="server"
            ItemType="WebShop.Models.CartItemViewModel"
            ClientIDMode="Static"
            SelectMethod="GetShoppingCart"
            DataKeyNames="ProductID">
            <LayoutTemplate>
                <table>
                    <thead>
                        <tr>
                            <td>ТОВАР</td>
                            <td>АРТИКУЛ</td>
                            <td>грн/м</td>
                            <td>Длина, м</td>
                            <td>Кол.</td>
                            <td>ЦЕНА, грн</td>
                            <td></td>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                    </tbody>
                    <tfoot>
                        <tr>
                            <td colspan="7" rowspan="2"></td>
                        </tr>
                    </tfoot>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><a href="<%# string.Format("/шнур/{0}", Item.ProductID) %>"><%# Item.Name %></a></td>
                    <td>#<%# Item.SKU %></td>
                    <td><%# Item.PricePerMeter %></td>
                    <td><%# Item.Length %></td>
                    <td>
                        <input type="text" onchange="cart.updateProductInCart(<%# Item.ProductID%>, <%# Item.Length%>, this)" value="<%# Item.Amount %>" />
                    </td>
                    <td><%# Item.Price %></td>
                    <td>
                        <a onclick="cart.removeProductFromCart(<%# Item.ProductID%>,<%# Item.Length %>)">
                            <img class="hypDelete" src="/App_Themes/Urban/images/delWhite.png" />
                        </a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>     
    </div>

</asp:Content>
