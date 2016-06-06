$(function () {
    var page = +$("#CurrentPage").text();
    $(".Page").eq(page - 1).addClass("active");
   $(".Pages").bind("click", function () {
       $(".Pages.active").removeClass("active");
       $(this).addClass("active");
   })
});