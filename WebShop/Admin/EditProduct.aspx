<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/NestedMasterPage.master" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="WebShop.Admin.EditProduct" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <link href="../../../Content/edit.product.css" rel="stylesheet" />

    <asp:FormView runat="server"
        RenderOuterTable="false"
        DefaultMode="Edit"
        SelectMethod="GetProduct"
        UpdateMethod="UpdateProduct"
        ItemType="WebShop.Admin.Models.EditProductViewModel">
        <EditItemTemplate>
            <div id="editForm">
                <asp:HiddenField ID="HiddenField1" Value="<%# BindItem.ProductID %>" runat="server" />
                <table>
                    <tr>
                        <td>Материал:</td>
                        <td>
                            <asp:DropDownList
                                ID="DropDownList1"
                                DataTextField="MaterialName"
                                DataValueField="MaterialID"
                                DataSource="<%# Item.Materials %>"
                                SelectedValue="<%# BindItem.MaterialID %>"
                                runat="server">
                            </asp:DropDownList>
                    </tr>
                    <tr>
                        <td>Название:</td>
                        <td>
                            <asp:TextBox ID="txt" runat="server" Text="<%# BindItem.Name %>" /></td>
                    </tr>
                    <tr>
                        <td>Описание:</td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" Text="<%# BindItem.Description %>" /></td>
                    </tr>
                    <tr>
                        <td>Цена, м/грн:</td>
                        <td>
                            <asp:TextBox ID="TextBox2" runat="server" Text="<%# BindItem.PricePerMeter %>" /></td>
                    </tr>
                    <tr>
                        <td>Артикул:</td>
                        <td>
                            <asp:TextBox ID="TextBox3" runat="server" Text="<%# BindItem.SKU %>" /></td>
                    </tr>
                    <tr>
                        <td>Диаметр, мм:</td>
                        <td>
                            <asp:TextBox ID="TextBox4" runat="server" Text="<%# BindItem.Diameter %>" /></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="Button1" runat="server" CommandName="Update" Text="Обновить" /></td>
                    </tr>
                </table>
                <asp:Image ID="Image1" ImageUrl="<%# Item.LargeImgPath %>" runat="server" />
            </div>
        </EditItemTemplate>
    </asp:FormView>
</asp:Content>
