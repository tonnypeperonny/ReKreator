//    $(".list-group-item").click(function () {
//        $(".list-group-item").removeClass("active");
//        $(this).addClass("active");
//});

$(document).ready(function () {
    
    var id = $.cookie("menu");
    if (id === null) {
        id = "moviesMenu";
        $.cookie("menu", id, { path: "/"});
    }
    var contents = $("#" + id);
    contents.addClass("active");
});

$(".list-group-item").click(function () {
    $.removeCookie("menu");
    var id = $(this).attr("id");
    $.cookie("menu", id, {path:"/"});
});


function clearCookie() {
    $.removeCookie("menu", { path: "/" });
    var id = "moviesMenu";
    $.cookie("menu", id, { path: "/" });
};