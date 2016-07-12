jQuery(function ($) {
    "use strict",        

    // Fullscreen background
                $.backstretch("/content/images/background/background.jpg");

    //#main-slider
    $(function () {
        $("#main-slider.carousel").carousel({
            interval: 8000
        });
    });

    /* Modals */
    $(".launch-modal").on("click", function (e) {
        e.preventDefault();
        $("#" + $(this).data("modal-id")).modal();
    });

    // accordian
    $(".accordion-toggle").on("click", function () {
        $(this).closest(".panel-group").children().each(function () {
            $(this).find(">.panel-heading").removeClass("active");
        });

        $(this).closest(".panel-heading").toggleClass("active");
    });

    //Initiat WOW JS
    new WOW().init();

    // portfolio filter
    $(window).load(function () {
        "use strict";
        var $portfolio_selectors = $(".portfolio-filter >li>a");
        var $portfolio = $(".portfolio-items");
        $portfolio.isotope({
            itemSelector: ".portfolio-item",
            layoutMode: "fitRows"
        });

        $portfolio_selectors.on("click", function () {
            $portfolio_selectors.removeClass("active");
            $(this).addClass("active");
            var selector = $(this).attr("data-filter");
            $portfolio.isotope({ filter: selector });
            return false;
        });
    });

    // Contact form
    var form = $("#main-contact-form");
    form.submit(function (event) {
        event.preventDefault();
        var form_status = $("<div class=\"form_status\"></div>");
        $.ajax({
            url: $(this).attr("action"),

            beforeSend: function () {
                form.prepend(form_status.html("<p><i class=\"fa fa-spinner fa-spin\"></i> Email is sending...</p>").fadeIn());
            }
        }).done(function (data) {
            form_status.html("<p class=\"text-success\">" + data.message + "</p>").delay(3000).fadeOut();
        });
    });


    //goto top
    $(".gototop").click(function (event) {
        event.preventDefault();
        $("html, body").animate({
            scrollTop: $("body").offset().top
        }, 500);
    });

    //Pretty Photo
    $("a[rel^='prettyPhoto']").prettyPhoto({
        social_tools: false
    });
});

//Show login wondow if unauthorized is returned
$(document).ajaxError(function (xhr, textStatus) {
    debugger;
    if (xhr.status == "401") {
        $("#modal-login").modal("show");
    }
});

//Hide Login Button and show Logout Button
function LoggedIn() {
    $("#nav-Login").addClass("hidden");
    $("#nav-Logout").removeClass("hidden");
    $("#modal-login").modal("hide");
}
//Show Logout Button