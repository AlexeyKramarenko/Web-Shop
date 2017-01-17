var order = (function () {
    function orderDeleteConfirmation(sender) {
        var orderId = $(sender).attr('name');
        return confirm("Вы действительно хотите удалить заказ '#" + orderId + "'?");
    }
    return {
        orderDeleteConfirmation: orderDeleteConfirmation
    }
})()