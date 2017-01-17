
var products = (function () {

    $('.pagination > li > a').click(function () {
        updatePageLinks(this);
        getProducts();
    });

    function updatePageLinks(sender) {
        var currentPageNumber = $('.currentPage').eq(1).text();
        var newPageNumber = $(sender).text();
        if (currentPageNumber != newPageNumber) {
            $('#bottomPagination > li > a').each(function (index, el) {
                $(el).removeClass('currentPage');
                if ($(el).text() == newPageNumber) {
                    $(el).addClass('currentPage');
                }
            });
            $('#topPagination > li > a').each(function (index, el) {
                $(el).removeClass('currentPage');
                if ($(el).text() == newPageNumber) {
                    $(el).addClass('currentPage');
                }
            });
        }
    }
    function getProducts(reset) {

        var sortByDiameter = $('#sortByDiameter').val();
        var sortByPrice = $('#sortByPrice').val();

        var currentPageCount = $('ul#bottomPagination li').length;
        var materialId = $('#material').val();
        var orderByParameter = $('#orderByParameter').val();
        var itemsPerPage = $('#itemsPerPageList').val();
        var currentPageNumber = $('#bottomPagination > li > .currentPage').text();

        var config = {
            url: '/webapi/products/GetProducts/' + materialId + '/' + sortByDiameter + '/' + sortByPrice + '/' + itemsPerPage + '/' + currentPageNumber,
            type: 'GET',
            dataType: 'json'
        };

        $('#productList').empty();
        $.ajax(config).done(onSuccess).fail(onError);

        function onSuccess(data) {
            var content = "";
            for (var i = 0; i < data.model.length; i++) {
                var item = data.model[i];
                content +=
             "<div class='cell'>" +
                "<a href='/шнур/" + item.ProductID + "'>" +
                    "<img src='" + item.ThumbImgPath + "' class='productImg'  />" +
                "</a>"+
                "<div class='innerContent'>" +
                    "<div class='materialName'>" + item.MaterialName + "</div>" +
                    "<span class='diameter'>Ø <b>" + item.Diameter + "</b> мм</span>, длина:" +
                        "<select class='length'>" +
                            "<option value='15'>15</option>" +
                            "<option value='25'>25</option>" +
                            "<option value='50'>50</option>" +
                            "<option value='100'>100</option>" +
                        "</select>" +
                    "<div class='name'><b>" + item.Name + "</b></div>" +
                    "<div class='price'>" + item.PricePerMeter + " грн/м</div>" +
                    "<div class='sku'>Артикул: " + item.SKU + "</div>" +
                "</div>" +
                "<a class='button' onclick='cart.addProductToCart(" + item.ProductID + ",this)'>" +
                     "<img src='/Content/images/cart.png' />Добавить в корзину" +
                "</a>" +
            "</div>";
            }

            $('#productList').html(content);

            var pageLinks = "";
            if (data.pageCount > 0) {
                if (reset == true) {
                    for (var i = 1; i <= data.pageCount; i++) {
                        if (i == 1)
                            pageLinks += "<li><a href='#' class='currentPage' onclick='products.updatePageLinks(this);products.getProducts();'>1</a></li>";
                        else
                            pageLinks += "<li><a href='#' onclick='products.updatePageLinks(this);products.getProducts();'>" + i + "</a></li>";
                    }
                }
                else
                    for (var i = 1; i <= data.pageCount; i++) {
                        if (data.currentPageNumber == i)
                            pageLinks += "<li><a href='#' class='currentPage' onclick='products.updatePageLinks(this);products.getProducts();'>" + i + "</a></li>";
                        else
                            pageLinks += "<li><a href='#' onclick='products.updatePageLinks(this);products.getProducts();'>" + i + "</a></li>";
                    }

                $('.pagination').html(pageLinks);
            }
        }

        function onError(error) {

        }
    }
    return {
        getProducts: getProducts,
        updatePageLinks: updatePageLinks
    }
})();