<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DeliveryServiceControl.ascx.cs" Inherits="WebShop.Controls.DeliveryServiceControl" %>


<div id="shipping">
    <div>
        Выберете службу доставки:          
                <br />
        <asp:DropDownList ID="deliveryService" ClientIDMode="Static" runat="server">
        </asp:DropDownList>
    </div>
    <div>
        Цена заказа:
                <span id="summaryPrice"></span>
    </div>
    <a href="/оформление_заказа">Оформить заказ</a>
</div>
