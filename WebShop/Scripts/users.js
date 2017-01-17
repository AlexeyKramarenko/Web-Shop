var users = (function () {
    function userDeleteConfirmation(sender) {
        var productName = $(sender).attr('name');
        return confirm("Вы действительно хотите удалить '" + productName + "'?");
    }
    return {
        userDeleteConfirmation: userDeleteConfirmation
    }
})();