<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/NestedMasterPage.master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="WebShop.Admin.AddProduct" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="../../Content/add.product.css" rel="stylesheet" />

    <div id="errors" style="width: 400px; margin: 20px auto 0 auto;">
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


    <asp:FormView runat="server"
        ID="formview"
        ClientIDMode="Static"
        RenderOuterTable="false"
        DefaultMode="Edit"
        ItemType="WebShop.Admin.Models.NewProductViewModel"
        SelectMethod="InitFormView"
        UpdateMethod="AddNewProduct">
        <EditItemTemplate>
            <table id="formViewTable">
                <tr>
                    <td>Материал:</td>
                    <td>
                        <asp:DropDownList
                            ID="DropDownList1"
                            DataValueField="MaterialID"
                            DataTextField="MaterialName"                            
                            DataSource="<%# Item.Materials %>"
                            SelectedValue="<%# BindItem.MaterialID %>"
                            runat="server">
                        </asp:DropDownList>
                </tr> 
                <tr>
                    <td>Выберите изображение:</td>
                    <td>
                        <asp:FileUpload
                            ID="largeImg"
                            runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Выберите миниатюрную
                <br />
                        копию изображения:</td>
                    <td>
                        <asp:FileUpload
                            ID="thumbImg"
                            runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Диаметр:</td>
                    <td><asp:TextBox ID="TextBox1" Text="<%# BindItem.Diameter %>" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Название:</td>
                    <td>
                        <asp:TextBox ID="TextBox2" Text="<%# BindItem.Name %>" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Описание:</td>
                    <td>
                        <asp:TextBox ID="TextBox3" TextMode="Multiline" Text="<%# BindItem.Description %>" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Артикул:</td>
                    <td>
                        <asp:TextBox ID="TextBox4" Text="<%# BindItem.SKU %>" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Цена грн. за 1 м:</td>
                    <td>
                        <asp:TextBox ID="TextBox5" Text="<%# BindItem.PricePerMeter %>" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button
                            ID="btnSave"
                            runat="server"
                            Text="Сохранить"
                            CommandName="Update" /></td>
                </tr>
            </table>
        </EditItemTemplate>
    </asp:FormView>


</asp:Content>
