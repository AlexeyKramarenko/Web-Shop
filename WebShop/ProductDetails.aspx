<%@ Page Title="Шнур"  EnableViewState="false"  Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="WebShop.ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Content/product.details.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="server">
     
    <asp:HiddenField ID="sessionUserId" ClientIDMode="Static" runat="server" />           
    <asp:FormView runat="server"
        RenderOuterTable="false"
        DefaultMode="ReadOnly"
        ItemType="WebShop.Models.ProductDetailsViewModel"
        SelectMethod="GetProduct">
        <ItemTemplate>
            <div id="form">
                <asp:Image ID="Image1" ImageUrl="<%# Item.LargeImgPath %>" runat="server" />
                <table id="info">
                    <tr>
                        <td colspan="2" style="text-align:center;"><asp:Literal ID="Literal1" Text="<%# Item.Name %>" runat="server"></asp:Literal></td>                        
                    </tr>
                    <tr>
                        <td>Диаметр, мм:</td>
                        <td>
                            <asp:Literal ID="Literal2" Text="<%# Item.Diameter %>" runat="server"></asp:Literal></td>
                    </tr>
                    <tr>
                        <td>Длина мотка, м:</td>
                        <td>
                            <select id="length">
                                <option value="15">15</option>
                                <option value="25">25</option>
                                <option value="50">50</option>
                                <option value="100">100</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><button type="button" onclick ="cart.addProductToCart(<%# Item.ProductID %>)" >Добавить в корзину</button></td>
                    </tr>
                </table>
              
            </div>
        </ItemTemplate>
    </asp:FormView>
    <script>
        function addProductToCart(productId, sender) {
            var length;
            if (sender) {
                var innerContent = $(sender).prev(".innerContent");
                length = $(innerContent).children('.length').val();
            }
            else
                length = $('#length').val();
            server.addProductToCart(userId, productId, length);
        }
    </script>

</asp:Content>
