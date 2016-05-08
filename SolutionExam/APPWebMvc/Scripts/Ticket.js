var _arrayList = new Array();
var _item = 1;
var _totalTicket = 0.00;
var _decimales = 2;
$(document).ready(function () {
    $("input[id*='btn']").click(function () {
        var id = $(this).attr("id").split("_")[1];
        var article = new ObjectSaleArticle(_item,
                                            id,
                                            description = $(("#spnDescription_").concat(id)).html(),
                                            price = $(("#spnPrice_").concat(id)).html().replace(",", "."),
                                            quantity = $(("#txt_").concat(id)).val());
        fn_AddList(article);
    });
    $("input[type='submit']").click(function () {
        fn_SaleTicket();
    });
});
//funciones para la vista
function fn_AddList(article)
{
    _arrayList.push(article);
    $("#tableList tbody").append(fn_CreateRow(article));
    $("#spn_TotalTicket").html(fn_util_RedondearDecimales(article.TotalTicket(),_decimales));
    _item++;
}
function fn_DeleteList(id)
{
    _totalTicket = 0;
    _arrayList.splice(id - 1, 1);
    _item = _arrayList.length + 1;
    $("#tableList > tbody").html("");
    $.each(_arrayList, function (key, value) {
        value.Id = key + 1;
        $("#tableList tbody").append(fn_CreateRow(value));
        _totalTicket += value.Total();
    });
    $("#spn_TotalTicket").html(fn_util_RedondearDecimales(_totalTicket, _decimales));
}
function fn_CreateElement(element)
{
    return $("<td/>").append(element);
}
function fn_CreateRow(article)
{
    return $("<tr>").append(fn_CreateElement(article.Id))
                    .append(fn_CreateElement(article.ArticleSale.Description))
                    .append(fn_CreateElement(fn_util_RedondearDecimales(article.PriceSale, _decimales)))
                    .append(fn_CreateElement(article.Quantity))
                    .append(fn_CreateElement(fn_util_RedondearDecimales(article.Total(), _decimales)))
                    .append($("<a>").attr({ href:"#", onclick: ("fn_DeleteList(").concat(article.Id).concat(")") }).html("Eliminar"))
    ;
}
//Objeto :: patron constructor
function ObjectSaleArticle(id, idArticle, description, priceSale, quantity)
{
    this.Id = id;
    this.ArticleSale = new ObjectArticle(idArticle, description);
    this.Quantity = (quantity == null || quantity == "") ? 0 : quantity;
    this.PriceSale = priceSale;
}
ObjectSaleArticle.prototype.Total = function () {
    return this.PriceSale * this.Quantity;
};
ObjectSaleArticle.prototype.TotalTicket = function () {
    _totalTicket += this.Total();
    return _totalTicket;
};

function ObjectArticle(id, description) {
    this.Id = id;
    this.Description = description;
}
//Utilitario
function fn_util_RedondearDecimales(cantidad, decimales) {
    var val = parseFloat(cantidad);
    if (isNaN(val)) { return (0).toFixed(decimales); }
    val = (parseFloat(cantidad)).toFixed(decimales)
    return val;
}
//CORS
function fn_SaleTicket()
{
    var urlTicket = $("input[type='hidden']").val();
    
}