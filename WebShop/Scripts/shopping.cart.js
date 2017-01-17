
var cart = (function (hub, client, server) {

    var userId = null;

    hub.start().done(function () {
        userId = $('#sessionUserId').val();
        
        connect();
        calculateSummaryPrice();
        $('#deliveryService').change(updateDeliveryPrice);
    });

    client.showCartItemsAmount = showCartItemsAmount;
    client.refreshShoppingCart = refreshShoppingCart;
    client.showSummaryPrice = showSummaryPrice;

    function showCartItemsAmount(amount) {
        $('#cartItemsAmount').text(amount);
    }
    function refreshShoppingCart(products) {

        var summaryAmount = 0;

        var container = $('#productList > table > tbody');
        if (container) {
            var tbody = "";
            for (var i = 0; i < products.length; i++) {
                var Item = products[i];
                tbody +=
                "<tr>" +                
                    "<td><a href='/шнур/"+Item.ProductID+"'>" + Item.Name + "</a></td>" +
                    "<td>#" + Item.SKU + "</td>" +
                    "<td>" + Item.PricePerMeter + "</td>" +
                    "<td>" + Item.Length + "</td>" +
                    "<td>" +
                        "<input type='text' onchange='cart.updateProductInCart(" + Item.ProductID + "," + Item.Length + ", this)' value='" + Item.Amount + "' />" +
                    "</td>" +
                    "<td>" + Item.Price + "</td>" +
                    "<td>" +
                        "<a onclick='cart.removeProductFromCart(" + Item.ProductID + ", " + Item.Length + ")'>" +
                            "<img class='hypDelete' src='/App_Themes/Urban/images/delWhite.png' />" +
                        "</a>" +
                    "</td>" +
                "</tr>";

                summaryAmount += Item.Amount;
            }
            container.html(tbody);
            showCartItemsAmount(summaryAmount);
        }
    };
    function showSummaryPrice(summaryPrice) {
        $('#summaryPrice').text(summaryPrice);
    }
    function connect() {
        server.connect(userId);
    }
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
    function updateDeliveryPrice() {
        var deliveryId = $('#deliveryService').val();
        server.updateDeliveryPrice(userId, deliveryId);
    }

    function calculateSummaryPrice() {
        server.calculateSummaryOrderPrice(userId);
    }
    function removeProductFromCart(productId, length) {
        server.removeProductFromCart(userId, productId, length);
    }
    function updateProductInCart(productId, length, sender) {
        var amount = $(sender).val();
        server.updateProductInCart(userId, productId, length, amount);
    }
   
    return {
        addProductToCart: addProductToCart,
        calculateSummaryPrice: calculateSummaryPrice,
        removeProductFromCart: removeProductFromCart,
        updateDeliveryPrice: updateDeliveryPrice,
        updateProductInCart: updateProductInCart
    }

})($.connection.hub, $.connection.shoppingCart.client, $.connection.shoppingCart.server);
