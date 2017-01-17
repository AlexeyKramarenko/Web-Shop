<%@ Page Title="Шнуры" EnableViewState="false" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="WebShop.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Content/products.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="server">
    <asp:HiddenField ID="sessionUserId" ClientIDMode="Static" runat="server" />

    <div id="settings">
        <div>
            На странице:
            <asp:DropDownList
                AutoPostBack="false"
                ID="itemsPerPageList"
                ClientIDMode="Static"
                onchange="products.getProducts(true);"
                runat="server">
                <asp:ListItem Text="40"></asp:ListItem>
                <asp:ListItem Text="30"></asp:ListItem>
                <asp:ListItem Text="20"></asp:ListItem>
                <asp:ListItem Text="10"></asp:ListItem>
            </asp:DropDownList>
        </div>

        <div>
            Цена:
                    <select id="sortByPrice" onchange="products.getProducts(true);">
                        <option value="asc">по возрастанию</option>
                        <option value="desc">по убыванию</option>
                    </select>
        </div>

        <div id="materialType">
            Материал:
                    <select id="material" onchange="products.getProducts(true);">
                        <option value="0">Все</option>
                        <option value="1">Хлопок</option>
                        <option value="2">Полипропилен</option>
                        <option value="3">Капрон</option>
                        <option value="4">Полиэфир</option>
                    </select>
        </div>

        <div>
            Диаметр:
                    <select id="sortByDiameter" onchange="products.getProducts(true);">
                        <option value="asc">по возрастанию</option>
                        <option value="desc">по убыванию</option>
                    </select>
        </div>
    </div>
    <div style="width: 50%; margin: 15px auto auto auto;">
        <ul id="topPagination" class="pagination">
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        </ul>
    </div>

    <asp:ListView runat="server"
        ID="listview"
        ClientIDMode="Static"
        SelectMethod="GetProducts"
        ItemType="WebShop.Models.ProductItemViewModel"
        DataKeyNames="ProductID">
        <LayoutTemplate>
            <div id="productList">
                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="cell">
                <a href='<%# string.Format( "/шнур/{0}", Item.ProductID) %>'>
                    <asp:Image ImageUrl="<%# Item.ThumbImgPath %>" CssClass="productImg" runat="server" />
                </a>
                <div class="innerContent">
                    <div class="materialName"><%# Item.MaterialName %></div>
                    <span class="diameter">Ø <b><%# Item.Diameter %></b> мм</span>, длина: 
                        <select class="length">
                            <option value="15">15</option>
                            <option value="25">25</option>
                            <option value="50">50</option>
                            <option value="100">100</option>
                        </select>
                    м
                    <div class="name"><b><%# Item.Name %></b></div>
                    <div class="price"><%# Item.PricePerMeter %> грн/м</div>
                    <div class="sku">Артикул: #<%# Item.SKU %></div>
                </div>
                <a class="button" onclick='cart.addProductToCart(<%# Item.ProductID %>,this)'>
                    <img src="Content/images/cart.png" />
                    Добавить в корзину
                </a>
            </div>
        </ItemTemplate>
    </asp:ListView>

    <div style="width: 50%; margin: 0px auto auto auto;">
        <ul id="bottomPagination" class="pagination">
            <asp:Literal ID="Literal2" runat="server"></asp:Literal>
        </ul>
    </div>

    <script src="/Scripts/promise.js"></script>
    <script src="/Scripts/products.js"></script>


</asp:Content>
