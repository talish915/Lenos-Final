﻿$(document).ready(function () {
    function bodyShow() {
        document.getElementById("header").style.opacity = 1;
        document.getElementById("main").style.opacity = 1;
        document.getElementById("footer").style.opacity = 1;
    }
    $.blockUI({
        message: $('#input-gif'),
        css: {
            top: ($(window).height() - 100) / 2 + 'px',
            left: ($(window).width() - 500) / 2 + 'px',
            width: '0px',
            opacity: 1
        },
        overlayCSS: {
            opacity: 1
        }
    });
    setTimeout(bodyShow, 1000)
    setTimeout($.unblockUI, 2000)

    $('.single-item').slick({
        autoplay: true,
        autoplaySpeed: 3000,
        arrows: false,
        dots: true,
    });

    $('.instagram-slick').slick({
        autoplay: true,
        autoplaySpeed: 3000,
        arrows: false,
        infinite: true,
        slidesToShow: 5,
    });

    // prodct details slider active
    $('.product-large-slider').slick({
        fade: true,
        arrows: false,
        asNavFor: '.pro-nav'
    });


    // product details slider nav active
    $('.pro-nav').slick({
        slidesToShow: 4,
        asNavFor: '.product-large-slider',
        arrows: false,
        focusOnSelect: true
    });

    $(".add-cart").click(function () {
        $(".add").addClass("d-none")
        $(".add-or-view").removeClass("d-none")
    })

    $(".modal-quick").click(function () {
        $(".product-modal").addClass("d-block")
        $("body").attr("class", "minicart-active")
        $(".product-modal").removeClass("d-none")
    })

    $(".minicart-btn").click(function () {
        $(".minicart").addClass("d-block")
        $("body").attr("class", "minicart-active")
        $(".minicart").removeClass("d-none")
    })

    $(".minicart-overlay").click(function () {
        $(".minicart").addClass("d-none")
        $("body").removeAttr("class", "minicart-active")
        $(".minicart").removeClass("d-block")
    })

    $(".modal-overlay , .modal-close").click(function () {
        $(".product-modal").addClass("d-none")
        $("body").removeAttr("class", "minicart-active")
        $(".product-modal").removeClass("d-block")
    })

    var header = document.getElementById("sticky-header");
    var stickyPosition = header.offsetTop + header.offsetHeight;
    window.onscroll = function () {
        if (window.pageYOffset > stickyPosition) {
            header.classList.add("sticky");
            header.style.padding = "1rem 0"
            document.querySelectorAll('body')[0].style.marginTop = header.offsetHeight + "px";
        } else {
            header.classList.remove("sticky");
            header.style.padding = "2rem 0"
            document.querySelectorAll('body')[0].style.marginTop = "0px";
        }

        $(".scroll-top").on("click", function () {
            window.scrollTo(0, 0)
        })

        window.addEventListener('scroll', () => {
            if (window.scrollY > 200) {
                $(".scroll-top").removeClass("d-none")
            }
            else {
                $(".scroll-top").addClass("d-none")
            }
        })
    };

    $('select').niceSelect();

    var rangeSlider = $(".price-range"),
        amount = $("#amount"),
        minPrice = rangeSlider.data('min'),
        maxPrice = rangeSlider.data('max');
    rangeSlider.slider({
        range: true,
        min: minPrice,
        max: maxPrice,
        values: [minPrice, maxPrice],
        slide: function (event, ui) {
            amount.val("$" + ui.values[0] + " - $" + ui.values[1]);
        }
    });
    amount.val(" $" + rangeSlider.slider("values", 0) +
        " - $" + rangeSlider.slider("values", 1)
    );


    $("#share").jsSocials({
        showLabel: false,
        showCount: false,
        shares: [{
            share: "facebook",
            logo: "i: bi bi-facebook"
        }, {
            share: "twitter",
            logo: "i: bi bi-twitter"
        }, {
            share: "pinterest",
            logo: "i: bi bi-pinterest"
        }]
    });
    $("#tabs").tabs();
    $('#stars').raty({ starType: 'i' });




    $(document).on("click", ".addToBasket", function (e) {
        e.preventDefault();
        let url = $(this).attr("href");
        fetch(url).then(res => {
            return res.text()
        }).then(data => {
            $(".minicart").html(data);
            UpdateBasketCount()
        })
    })

    $(document).on("click", ".addbasketbtn", function (e) {
        e.preventDefault()
        let url = $(this).attr("href");
        let count = $("#productcount").val();

        url = url + "?count=" + count;
        fetch(url).then(response => {
            return response.text();
        }).then(data => {
            $(".minicart").html(data)
            UpdateBasketCount()
        })
    })

    function UpdateBasketCount() {
        fetch("/basket/GetBasketCount").then(
            response => response.json()
        ).then(data => {
            $('.notification').text(data.count);
        })
    }

    $(document).on("click", ".shop-list", function (e) {
        e.preventDefault();

        let url = $(this).attr("href");

        fetch(url).then(response => response.text())
            .then(data => {
                $(".shop").html(data)
            })
    })

    $(document).on("click", ".productdetail", function (e) {
        e.preventDefault();

        let url = $(this).attr("href");

        fetch(url).then(response => response.text())
            .then(data => {
                $(".product-modal").html(data)

                $('.modal-slick').slick({
                    autoplay: false,
                    arrows: true,
                    infinite: false,
                });

                $(".modal-overlay , .modal-close").click(function () {
                    $(".product-modal").addClass("d-none")
                    $("body").removeAttr("class", "minicart-active")
                    $(".product-modal").removeClass("d-block")
                })
            })
    })
    $(document).on("click", ".qtybtn", function (e) {
        e.preventDefault()
        let url = $(this).attr("href");
        var count = $(this).parent().find('input').val();
        var id = $(this).parent().find('input').attr("data-id");

        if ($(this).hasClass("dec")) {

            if (count != 1) {
                count--;
            }
        }
        else {
            count++;
        }

        fetch("Basket/Update" + "?id=" + id + "&count=" + count).then(response => {

            fetch("Basket/GetBasket").then(response => response.text())
                .then(data => $(".minicart").html(data))
            return response.text()

        }).then(data => $(".basketContainer").html(data))

        $(this).parent().find('input').val(parseFloat(count));
    })


    $(document).on("click", ".deletecard", function (e) {
        e.preventDefault();

        let url = $(this).attr("href");

        fetch(url).then(response => {
            fetch("Basket/GetBasket").then(response => response.text()).then(data => $(".header-cart").html(data))

            return response.text()
        }).then(data => {
            $(".basketContainer").html(data)
            UpdateBasketCount()
        })
    })

    $(document).on("click", ".deletebasket", function (e) {
        e.preventDefault();

        let url = $(this).attr("href");
        console.log(url)

        fetch(url).then(response => {
            fetch("Basket/GetBasket").then(response => response.text()).then(data => $(".basketContainer").html(data))

            return response.text()
        }).then(data => {
            $(".minicart").html(data)
            UpdateBasketCount()

            $(".minicart-overlay").click(function () {
                $(".minicart").addClass("d-none")
                $("body").removeAttr("class", "minicart-active")
                $(".minicart").removeClass("d-block")
            })
        })

    })
})