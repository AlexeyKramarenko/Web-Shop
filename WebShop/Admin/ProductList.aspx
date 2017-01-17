<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/NestedMasterPage.master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="WebShop.Admin.ProductList" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <link href="../../../Content/product.list.css" rel="stylesheet" />
    <script src="../../../Scripts/users.js"></script>

    <div id="material">
        Материал:
        <asp:DropDownList OnSelectedIndexChanged="materialList_SelectedIndexChanged" ID="materialList" AutoPostBack="true" runat="server"></asp:DropDownList>
    </div> 
     
    <asp:Repeater OnItemCommand="Repeater1_ItemCommand" ID="Repeater1" ItemType="WebShop.Admin.Models.ProductItemViewModel" runat="server">
        <HeaderTemplate>
            <table id="products">
                <tr>
                    <td>Название</td>
                    <td>Материал</td>
                    <td>IMG</td>
                    <td></td>
                    <td></td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Item.Name %></td>
                <td><%# Item.MaterialName %></td>
                <td>
                    <asp:Image ImageUrl="<%# Item.ThumbImgPath %>" runat="server" /></td>
                <td><a href="/админ/редактировать_описание/<%# Item.ProductID %>">Редактировать</a></td>
                <td>
                    <asp:LinkButton ID="LinkButton1" name="<%# Item.Name %>" OnClientClick="return users.userDeleteConfirmation(this);" CommandArgument="<%# Item.ProductID %>" CommandName="Delete" runat="server">Удалить</asp:LinkButton></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>

</asp:Content>
