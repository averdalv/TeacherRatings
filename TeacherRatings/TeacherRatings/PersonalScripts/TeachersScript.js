$(function () {
    $("ul.nav.nav-tabs li").first().addClass("active");
    $("ul.nav.nav-tabs li:first a").click();
    $("ul.nav.nav-tabs li").bind("click", function () {
        $("ul.nav.nav-tabs li.active").removeClass("active");
        $(this).addClass("active");
    })
});


