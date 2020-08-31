$(document).ready(function () {
    let categories = [];
    let markas = [];
    $("input[name='CategoryId']").change(function () {

        if ($(this).is(':checked')) {
            categories.push(parseInt($(this).val()));
            search();
            
            //categories.remove(parseInt($(this).val()))
            
        } else {
            categories.pop(parseInt($(this).val()));
            search();
            
        }

       
    });

    $("input[name='MarkaId']").change(function () {
        if ($(this).is(':checked')) {
            markas.push(parseInt($(this).val()));
            search();
            console.log(markas);

        } else {
            markas.pop(parseInt($(this).val()));
            search();
            console.log(markas);
        }

    });


    function search() {

        $.ajax({
            url: "/Shop/Search",
            type: "GET",
            data: {
                categories: JSON.stringify(categories),
                markas: JSON.stringify(markas),
            },
            success: function (res) {

                //console.log(res)
                $("#grid").children().remove();
                $("#grid").html(res)
            }
        });
    }
    //$(document).ready(function () {
    //    $("#searcha").keyup(function () {
    //        var src = $(this).val();
    //        $("#search_list").empty();
    //        if (src.length > 0) {
    //            $.ajax({
    //                url: "Home/Searchh?str=" + src,
    //                type: "GET",
    //                success: function (res) {
    //                    $("#search_list").append(res)
    //                }
    //            });
    //        }
    //    });
    //});
});
    function showpw() {
        var pw = document.getElementById('showpw');
        if (pw.type == "text")
            pw.type = "password";
        else
            pw.type = "text";
    }
    function showpww() {
        var pww = document.getElementById('showpww');
        if (pww.type == "text")
            pww.type = "password";
        else
            pww.type = "text";
    }

    (function ($) {
        "use strict";

        /*--
            WOW active 
        ------------------------- */
        new WOW().init();
        /*--
            stickey menu
        ------------------------- */
        $(window).on('scroll', function () {
            var scroll = $(window).scrollTop();
            if (scroll < 265) {
                $(".sticky-header").removeClass("sticky");
            } else {
                $(".sticky-header").addClass("sticky");
            }
        });

        /*--
            02. jQuery MeanMenu
        ------------------------- */
        $('#mobile-menu-active').meanmenu({
            meanScreenWidth: "991",
            meanMenuContainer: ".mobile-menu-area .mobile-menu",
        });
        /*--
            Nice Select
        ------------------------- */
        $('.nice-select').niceSelect();

        /*--- Vertical-Menu Activation ----*/

        $('.categories-toggler-menu').on('click', function () {
            $('.vertical-menu-list').slideToggle();
        });
        /*---
            3. Category Menu Active
        ---------------------------- */
        $('.categories-more-less').on('click', function () {
            $('.hide-child').slideToggle();
            $(this).toggleClass('rx-change');
        });
        /*--
         owl active
        --------------------------- */
        $('.slider-active').owlCarousel({
            loop: true,
            items: 1,
            autoplay: false,
            dots: true,
            nav: false,
            responsive: {
                0: { items: 1 },
                600: { items: 1 },
                1000: { items: 1 },
                1200: { items: 1 }
            }
        });
        /*--
         owl active
        ------------------------------ */
        $('.slider-active-2').owlCarousel({
            loop: true,
            items: 1,
            dots: true,
            nav: true,
            navText: ['<i class="ion-chevron-left"></i>', '<i class="ion-chevron-right"></i>'],
            responsive: {
                0: { items: 1 },
                600: { items: 1 },
                1000: { items: 1 },
                1200: { items: 1 }
            }
        });
        /*--
     owl active
    ------------------------------ */
        $('.product-h-2.priduct-module-1-active').owlCarousel({
            loop: true,
            items: 1,
            dots: false,
            nav: true,
            margin: 30,
            navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
            responsive: {
                0: { items: 1 },
                767: { items: 2 },
                992: { items: 1 },
                1200: { items: 1 }
            }
        });
        /*--
         owl active
        ------------------------------ */
        $('.priduct-module-1-active').owlCarousel({
            loop: true,
            items: 1,
            dots: false,
            nav: true,
            navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
            responsive: {
                0: { items: 1 },
                600: { items: 1 },
                1000: { items: 1 },
                1200: { items: 1 }
            }
        });

        /*--
         owl active
        ------------------------------ */
        $('.deals-offer-active').owlCarousel({
            loop: true,
            items: 2,
            dots: false,
            nav: true,
            navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
            responsive: {
                0: { items: 1 },
                768: { items: 1 },
                992: { items: 2 },
                1200: { items: 2 }
            }
        });
        /*--
         owl active
        ------------------------------ */
        $('.deals-offer-one-active').owlCarousel({
            loop: true,
            items: 2,
            dots: false,
            nav: true,
            navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
            responsive: {
                0: { items: 1 },
                768: { items: 1 },
                992: { items: 1 },
                1200: { items: 1 }
            }
        });
        /*--
         owl active
        ------------------------------ */
        $('.feategory-active').owlCarousel({
            loop: true,
            items: 5,
            dots: false,
            nav: true,
            navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
            responsive: {
                0: { items: 1 },
                480: { items: 2 },
                768: { items: 4 },
                992: { items: 5 },
                1200: { items: 5 }
            }
        });
        /*--
         owl active
        ------------------------------ */
        $('.prodict-active').owlCarousel({
            loop: true,
            items: 4,
            dots: false,
            nav: true,
            navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
            responsive: {
                0: { items: 1 },
                480: { items: 2 },
                768: { items: 3 },
                992: { items: 4 },
                1200: { items: 4 }
            }
        });
        /*--
         owl active
        ------------------------------ */
        $('.prodict-active-4').owlCarousel({
            loop: true,
            items: 4,
            dots: false,
            nav: true,
            navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
            responsive: {
                0: { items: 1 },
                480: { items: 1 },
                768: { items: 3 },
                992: { items: 3 },
                1200: { items: 3 }
            }
        });
        /*--
         owl active
        ------------------------------ */
        $('.prodict-two-active').owlCarousel({
            loop: true,
            items: 4,
            dots: false,
            nav: true,
            navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
            responsive: {
                0: { items: 1 },
                480: { items: 2 },
                768: { items: 3 },
                992: { items: 4 },
                1200: { items: 5 }
            }
        });
        /*--
         owl active
        ------------------------------ */
        $('.product-three-active').owlCarousel({
            loop: true,
            items: 4,
            dots: false,
            nav: true,
            navText: ['<i class="ion-chevron-left"></i>', '<i class="ion-chevron-right"></i>'],
            responsive: {
                0: { items: 1 },
                480: { items: 2 },
                768: { items: 2 },
                992: { items: 3 },
                1200: { items: 4 }
            }
        });
        /*--
         owl active
        ------------------------------ */
        $('.brand-active').owlCarousel({
            loop: true,
            items: 1,
            margin: 15,
            dots: false,
            nav: false,
            responsive: {
                0: { items: 1 },
                480: { items: 2 },
                768: { items: 4 },
                992: { items: 5 },
                1200: { items: 5 }
            }
        });
        /*--
         owl active
        ------------------------------ */
        $('.product-category-active').owlCarousel({
            loop: true,
            items: 1,
            margin: 15,
            dots: false,
            nav: true,
            navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
            responsive: {
                0: { items: 1 },
                600: { items: 1 },
                1000: { items: 1 },
                1200: { items: 1 }
            }
        });
        /*--
         owl active
        ------------------------------ */
        $('.articles-cont-active').owlCarousel({
            loop: true,
            items: 1,
            margin: 15,
            dots: false,
            nav: false,
            navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
            responsive: {
                0: { items: 1 },
                600: { items: 1 },
                1000: { items: 1 },
                1200: { items: 1 }
            }
        });
        /*--
         owl active
        ------------------------------ */
        $('.single-product-active').owlCarousel({
            loop: false,
            items: 4,
            margin: 15,
            dots: false,
            nav: true,
            navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
            responsive: {
                0: { items: 2 },
                480: { items: 3 },
                768: { items: 4 },
                992: { items: 4 },
                1200: { items: 4 }
            }
        });
        /*--
         owl active
        ------------------------------ */
        $('.from-blog').owlCarousel({
            loop: true,
            items: 2,
            dots: false,
            nav: true,
            navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
            responsive: {
                0: { items: 1 },
                480: { items: 1 },
                768: { items: 2 },
                992: { items: 2 },
                1200: { items: 2 }
            }
        });

        /*--
         owl active
        ------------------------------ */
        $('.post-slider').owlCarousel({
            loop: true,
            items: 1,
            dots: true,
            nav: true,
            navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
            responsive: {
                0: { items: 1 },
                600: { items: 1 },
                1000: { items: 1 },
                1200: { items: 1 }
            }
        });
        /*--
         owl active
        ------------------------------ */

        $('.testimonials-active').owlCarousel({
            loop: true,
            items: 1,
            dots: false,
            nav: false,
            navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
            responsive: {
                0: { items: 1 },
                600: { items: 1 },
                1000: { items: 1 },
                1200: { items: 1 }
            }
        });


        /*--
            elevateZoom
        ------------------------------ */
        $("#zoom1").elevateZoom({
            gallery: 'gallery_01',
            responsive: true,
            zoomType: 'inner',
            cursor: 'crosshair'
        });



        /*--
          11. price-slider active
        -----------------------------*/
        $("#price-slider").slider({
            range: true,
            min: 0,
            max: 145,
            values: [20, 440],
            slide: function (event, ui) {
                $("#min-price").val('$' + ui.values[0]);
                $("#max-price").val('$' + ui.values[1]);
            }
        });
        $("#min-price").val('$' + $("#price-slider").slider("values", 0));
        $("#max-price").val('$' + $("#price-slider").slider("values", 1));




        /*---
            select last tab 
        -------------------------*/

        $('.tabs-categorys-list a[href="#new-arrivals"],.shop-item-filter-list a[href="#grid"],.discription-tab-menu a[href="#description"]').tab('show')

        /*--
            Count Down Timer
        ----------------------------*/
        $('[data-countdown]').each(function () {
            var $this = $(this), finalDate = $(this).data('countdown');
            $this.countdown(finalDate, function (event) {
                $this.html(event.strftime('<span class="cdown day"><span class="time-count">%-D</span> <p>Days</p></span> <span class="cdown hour"><span class="time-count">%-H</span> <p>Hours</p></span> <span class="cdown minutes"><span class="time-count">%M</span> <p>mins</p></span> <span class="cdown second"><span class="time-count">%S</span> <p>secs</p></span>'));
            });
        });


        /*--
          Vertical-Menu Activation
        -----------------------------*/
        $('.categorie-title,.mobile-categorei-menu').on('click', function () {
            $('.vertical-menu-list,.mobile-categorei-menu-list').slideToggle();
        });

        /*--
          Category menu Activation
        ------------------------------*/
        $('#cate-toggle li.has-sub>a,#cate-mobile-toggle li.has-sub>a').on('click', function () {
            $(this).removeAttr('href');
            var element = $(this).parent('li');
            if (element.hasClass('open')) {
                element.removeClass('open');
                element.find('li').removeClass('open');
                element.find('ul').slideUp();
            } else {
                element.addClass('open');
                element.children('ul').slideDown();
                element.siblings('li').children('ul').slideUp();
                element.siblings('li').removeClass('open');
                element.siblings('li').find('li').removeClass('open');
                element.siblings('li').find('ul').slideUp();
            }
        });

        /*--
            Accordion
        -------------------------*/
        $(".faequently-accordion").collapse({
            accordion: true,
            open: function () {
                this.slideDown(300);
            },
            close: function () {
                this.slideUp(300);
            }
        });

        /*--
          showlogin toggle function
        --------------------------*/
        $('#showlogin').on('click', function () {
            $('#checkout-login').slideToggle(500);
        });

        /*--
          showcoupon toggle function
        --------------------------*/
        $('#showcoupon').on('click', function () {
            $('#checkout-coupon').slideToggle(500);
        });

        /*--- Checkout ---*/
        $("#chekout-box").on("change", function () {
            $(".account-create").slideToggle("100");
        });

        /*-- Checkout -----*/
        $("#chekout-box-2").on("change", function () {
            $(".ship-box-info").slideToggle("100");
        });


        /*--
            ScrollUp Active
        -----------------------------------*/
        $.scrollUp({
            scrollText: '<i class="fas fa-chevron-up"></i>',
            easingType: 'linear',
            scrollSpeed: 900,
            animation: 'fade'
        });
        /*--
            Instafeed
        -----------------------------------------*/
        if ($('#instagram-feed').length) {
            var feed = new Instafeed({
                get: 'user',
                userId: 6665768655,
                accessToken: '6665768655.1677ed0.313e6c96807c45d8900b4f680650dee5',
                target: 'instagram-feed',
                resolution: 'thumbnail',
                limit: 6,
                template: '<li><a href="{{link}}" target="_new"><img src="{{image}}" /></a></li>',
            });
            feed.run();
        }



        /*--------
            DateCountdown active 
        ------------------------------------- */
        $(".DateCountdown").TimeCircles({
            direction: "Counter-clockwise",
            fg_width: 0.009,
            bg_width: 0,
            use_background: false,
            time: {
                Days: {
                    text: "Days",
                    color: "#fff"
                },
                Hours: {
                    text: "Hours",
                    color: "#fff"
                },
                Minutes: {
                    text: "Mins",
                    color: "#fff"
                },
                Seconds: {
                    text: "Secs",
                    color: "#fff"
                }
            }

        });
        
    })(jQuery);


/* Add Basket Ajax*/
//$(document).ready(function () {
//    $(".add-basket").click(function () {
//    $(".to").css("display", "block");
//    var Id = $(this).attr("data-id");

//    $.ajax({
//        url: "/Cart/Add?=" + Id,
//        //type: "GET",
//        success: function (res) {
//            if (res.status === 200) {
//                $("#cart_count").text(res.data);
//                toastr.options = {
//                    "closeButton": true,
//                    "progressBar": false,
//                    "positionClass": "toast-top-right",
//                    "showDuration": "1500",
//                    "timeOut": "1500"
//                }
//                toastr.success(res.message);
//            }
//        }
//    });
  
//    });
    
//});


///E S A S Budu
//$(document).on("click",".add-basket",function () {
//    $(".to").css("display", "block");
//        var Id = $(this).attr("data-id");
//    $.ajax({
//        url: "/Cart/Add?=" + Id,
//        type: "POST",
//        success: function (res) {
//            if (res.status === 200) {

//                $("#cart_count").text(res.data);

//                toastr.options = {
//                    "closeButton": true,
//                    "progressBar": false,
//                    "positionClass": "toast-top-right",
//                    "showDuration": "1500",
//                    "timeOut": "1500"
//                }
//                toastr.success(res.message);
//            }
//        }
//    });
//});



/* Search*/
$("#search").keyup(function () {
    $("#search-list").empty();
    var src = $(this).val();
    if (src.length > 2) {
        $.ajax({
            url: "Home/SearchProduct?str=" + src,
            type: "GET",
            success: function (response) {
                $("#search-list").append(response);
            }
        });
    }
});

//$(document).on("click", ".addCart", function (e) {
//    var id = $(this).attr("data-id");

//    $.ajax({
//        url: "/Cart/Insert/" + id,
//        success: function (res) {
//            console.log(res);
//        }
//    });
//    Swal.fire({
//        position: 'top-end',
//        type: 'success',
//        title: 'Məhsul səbətə əlavə edildi',
//        showConfirmButton: false,
//        timer: 1500
//    });
//});

$("#categories").change(function (e) {
    var catId = $(this).val();

    $.ajax({
        url: "/Home/GetProductByCat/" + catId,
        type: "Post",
        success: function (r,s,xhr) {
            console.log(r);
            console.log(s);
            console.log(xhr);
        }
    });
});

$(document).on("click","#deleteCart", function () {
    var deleteCart = $(this).attr("data-id");
    
    $.ajax({
        url: "/Cart/Remove/" + deleteCart,
        type: "Post",
        success: function (res) {
            console.log(res)
        }
    });
});

 //MESQ
//$(document).on("click",".add-basket",function () {
//    $(".to").css("display", "block");
//        var Id = $(this).attr("data-id");
//    $.ajax({
//        url: "/Cart/Add?=" + Id,
//        type: "GET",
//        success: function (res) {
//            var tableBody = $("#product_table");
//            tableBody.empty();
           
//            if (res.status === 200 && res.data.length) {
//                for (var i = 0; i < res.data.length; i++) {
//                    var current = res.data[i];
                   
//                    var tr = $("<tr>");
                    
//                    var tdImage = $("<td>");
//                    $("<img>").attr("src", "/img/" + current.image).appendTo(tdImage);

//                    tdImage.appendTo(tr);
//                    $("<td>").text(current.name).appendTo(tr);
//                    $("<td>").text(current.price).appendTo(tr);
//                    $("<td>").text(current.quantity).appendTo(tr);
//                    tableBody.append(tr);

//                }
              
                
//                toastr.options = {
//                    "closeButton": true,
//                    "progressBar": false,
//                    "positionClass": "toast-top-right",
//                    "showDuration": "1500",
//                    "timeOut": "1500"
//                }
//                toastr.success(res.message);
               
//            }
//            tableBody.parent().parent().parent().parent().removeClass("d-none");
//            console.log(res.data.length);
//        }
//    });
//});






$(document).on("click",".add-basket",function () {
    $(".to").css("display", "block");
        var Id = $(this).attr("data-id");
    $.ajax({
        url: "/Cart/Add?=" + Id,
        type: "GET",
        success: function (res) {
            var tableBody = $(".home .wish-cart");
            tableBody.empty();
            var totalPrice = 0;
            if (res.status === 200 && res.data.length) {
                for (var i = 0; i < res.data.length; i++) {
                    var current = res.data[i];

      tableBody.append($("<div>").addClass("wish-item")
                        .append($("<div>").addClass("cat")
                            .append($("<img>").attr("src", "/img/" + current.image))
                            .append($("<div>").addClass("cat_two").attr('style', 'width:150px')
                                .append($("<p>").html(`${current.name}`).attr('style', 'overflow-x:hidden'))
                                .append($("<p>").text(`${current.quantity} x ${current.price}₼`)))
                            .append(` <div class="cat_icon">
                                         <a asp-controller="Cart" asp-action="Remove">
                                         <i class="fa fa-times"></i>
                                         </a>
                                      </div>`)));
                }
                //tableBody.parent().append($("<div>").addClass("wish-item")
                //    .append($("<div>").addClass("cat_bottom")
                //        .append($("<div>").addClass("cat_d cart-two n7")
                //            .append($("<a>").attr("href", "/Cart/Index")
                //                .append($("<strong>").text("Sifarişi rəsmiləşdir"))))))
                

                toastr.options = {
                    "closeButton": true,
                    "progressBar": false,
                    "positionClass": "toast-top-right",
                    "showDuration": "1500",
                    "timeOut": "1500"
                }
                toastr.success(res.message);

            }
            tableBody.parent().parent().removeClass("d-none");
            console.log(res.data.length);
        }
    });
});

