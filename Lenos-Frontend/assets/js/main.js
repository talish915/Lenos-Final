$(document).ready(function () {
    
    $('.single-item').slick({
        autoplay: true,
        autoplaySpeed: 7000,
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

    $(".add-cart").click(function(){
        $(".add").addClass("d-none")
        $(".add-or-view").removeClass("d-none")
    })

    $(".modal-quick").click(function(){
        $(".product-modal").addClass("d-block")
        $("body").attr("class", "minicart-active")
        $(".product-modal").removeClass("d-none")

        $('.modal-slick').slick({
            autoplay: false,
            arrows: true,
            infinite: false,
        });
    })

    $(".minicart-btn").click(function(){
        $(".minicart").addClass("d-block")
        $("body").attr("class", "minicart-active")
        $(".minicart").removeClass("d-none")
    })
    
    $(".minicart-overlay").click(function(){
        $(".minicart").addClass("d-none")
        $("body").removeAttr("class", "minicart-active")
        $(".minicart").removeClass("d-block")
    })

    $(".modal-overlay , .modal-close").click(function(){
        $(".product-modal").addClass("d-none")
        $("body").removeAttr("class", "minicart-active")
        $(".product-modal").removeClass("d-block")
    })

    $('.pro-qty').prepend('<span class="dec qtybtn">-</span>');
	$('.pro-qty').append('<span class="inc qtybtn">+</span>');
	$('.qtybtn').on('click', function () {
		var $button = $(this);
		var oldValue = $button.parent().find('input').val();
		if ($button.hasClass('inc')) {
			var newVal = parseFloat(oldValue) + 1;
		} else {
			if (oldValue > 0) {
				var newVal = parseFloat(oldValue) - 1;
			} else {
				newVal = 0;
			}
		}
		$button.parent().find('input').val(newVal);
	});

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
        window.scrollTo(0,0)
    })

    window.addEventListener('scroll', () => {
        if (window.scrollY > 200) {
            $(".scroll-top").removeClass("d-none")
        }
        else{
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
		" - $" + rangeSlider.slider("values", 1));
})