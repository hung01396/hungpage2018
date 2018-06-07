$(function () {
    $("#btn-right").click(function () {
        var position = $("#include-photo").scrollLeft();
        var webH = $("#photo1").width();
        var elmnt = document.getElementById("include-photo");
        var maxScrollLeft = elmnt.scrollWidth;
        var positions = position + webH+5;
        if ((position + webH) >= maxScrollLeft) {

            $("#include-photo").animate({ scrollLeft: 0 }, 0);
        }
        else {
            $("#include-photo").animate({ scrollLeft: positions }, 800);
        }
    });
    $("#include-photo").on("swipeleft", function () {
        var position = $("#include-photo").scrollLeft();
        var webH = $("#photo1").width();
        var elmnt = document.getElementById("include-photo");
        var maxScrollLeft = elmnt.scrollWidth;
        var positions = position + webH;
        if ((position + webH) >= maxScrollLeft) {

            $("#include-photo").animate({ scrollLeft: 0 }, 0);
        }
        else {
            $("#include-photo").animate({ scrollLeft: positions }, 800);
        }
    });

    $("#btn-left").click(function () {
        var position = $("#include-photo").scrollLeft();
        var webH = $("#photo1").width();
        var elmnt = document.getElementById("include-photo");
        var maxScrollLeft = elmnt.scrollWidth;
        var positions = position - webH-5;
        if (position <= 0) {

            $("#include-photo").animate({ scrollLeft: maxScrollLeft }, 0);
        }
        else {
            $("#include-photo").animate({ scrollLeft: positions }, 800);
        }
    });
    $("#include-photo").on("swiperight", function () {
        var position = $("#include-photo").scrollLeft();
        var webH = $("#photo1").width();
        var elmnt = document.getElementById("include-photo");
        var maxScrollLeft = elmnt.scrollWidth;
        var positions = position - webH;
        if (position <= 0) {

            $("#include-photo").animate({ scrollLeft: maxScrollLeft }, 0);
        }
        else {
            $("#include-photo").animate({ scrollLeft: positions }, 800);
        }
    });


    var windowwidth = document.body.clientWidth;
    var bodyWidth = $("#body-include").width();
    var bodyHeight = $("#body-include").height();
    var photoWidth;
    if (windowwidth <= 750) {
        photoWidth = bodyWidth * 1;
    }
    else {
        photoWidth = bodyWidth * 0.75;
    }
    $("#include-photo").css("width", photoWidth);
    $("#include-photo-1").css("width", photoWidth);
    $("img#photo1").css("width", photoWidth);
    $("img#photo").css("width", photoWidth);
    var webH = $("#photo1").height();
    $("#include-photo").css("max-height", webH);
    $("#include-photo-1").css("max-height", webH);
    $("img#btn-left").css("height", webH * 0.1);
    $("img#btn-right").css("height", webH * 0.1);
    $("#include-photo").animate({ scrollLeft: 0 }, 0);

    if (windowwidth < 550) {
        $("#header-logo").css("width", "440");
        $("#logo").css("width", "440");
        $("#header-information").css("width", windowwidth);
    }
    if (windowwidth < 440) {
        $("#header-logo").css("width", windowwidth);
        $("#logo").css("width", windowwidth);
    }
    if (windowwidth > 550) {
        $("#header-logo").css("width", "300");
        $("#logo").css("width", "300");
        
    }

    $(window).resize(function () {
        var windowwidth = document.body.clientWidth;
        var bodyWidth = $("#body-include").width();
        var bodyHeight = $("#body-include").height();
        var photoWidth;
        if (windowwidth <= 750) {
            photoWidth = bodyWidth * 1;
        }
        else {
            photoWidth = bodyWidth * 0.75;
        }
        $("#include-photo").css("width", photoWidth);
        $("#include-photo-1").css("width", photoWidth);
        $("img#photo1").css("width", photoWidth);
        $("img#photo").css("width", photoWidth);
        var webH = $("#photo1").height();
        $("#include-photo").css("max-height", webH);
        $("#include-photo-1").css("max-height", webH);
        $("img#btn-left").css("height", webH * 0.1);
        $("img#btn-right").css("height", webH * 0.1);
        $("#include-photo").animate({ scrollLeft: 0 }, 0);

        if (windowwidth < 550) {
            $("#header-logo").css("width", "440");
            $("#logo").css("width", "440");
            $("#header-information").css("width", windowwidth);
        }
        if (windowwidth < 440) {
            $("#header-logo").css("width", windowwidth);
            $("#logo").css("width", windowwidth);
        }
        if (windowwidth > 550) {
            $("#header-logo").css("width", "300");
            $("#logo").css("width", "300");
           
        }
    });
    $("div#chat-bottom").click(function () {
        var chatstate = $("div#chat-information").css("display");
        if (chatstate == "none") {
            $("div#chat-information").css("display", "block");
        }
        else {
            $("div#chat-information").css("display", "none");
        }
    })
    $("img#msg-close").click(function () {
        var chatstate = $("div#chat-information").css("display");
        if (chatstate == "none") {
            $("div#chat-information").css("display", "block");
        }
        else {
            $("div#chat-information").css("display", "none");
        }
    })

    $("div#chat-bottom2").click(function () {
        var chatstate = $("div#chat-information2").css("display");
        if (chatstate == "none") {
            $("div#chat-information2").css("display", "block");
        }
        else {
            $("div#chat-information2").css("display", "none");
        }
    })
    $("img#msg-close2").click(function () {
        var chatstate = $("div#chat-information2").css("display");
        if (chatstate == "none") {
            $("div#chat-information2").css("display", "block");
        }
        else {
            $("div#chat-information2").css("display", "none");
        }

    })

    


}); 
