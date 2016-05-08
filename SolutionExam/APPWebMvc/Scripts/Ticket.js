var _arrayList = new Array();
var _item = 1;
var _totalTicket = 0.00;
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
        fn_VenderTicket();
    });
});

function fn_AddList(article)
{
    _arrayList.push(article);
    $("#tableList tbody").append(fn_CreateRow(article));
    $("#spn_TotalTicket").html(fn_util_RedondearDecimales(article.TotalTicket(),2));
    _item++;
}
function fn_CreateElement(element)
{
    return $("<td/>").append(element);
}
function fn_CreateRow(article)
{
    return $("<tr>").append(fn_CreateElement(article.Id))
                    .append(fn_CreateElement(article.ArticleSale.Description))
                    .append(fn_CreateElement(fn_util_RedondearDecimales(article.PriceSale, 2)))
                    .append(fn_CreateElement(article.Quantity))
                    .append(fn_CreateElement(fn_util_RedondearDecimales(article.Total(), 2)))
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
    if (isNaN(val)) { return "0.00"; }
    val = (parseFloat(cantidad)).toFixed(decimales)
    return val;
}
//CORS
function fn_VenderTicket()
{
    var urlTicket = $("input[type='hidden']").val();
    
}