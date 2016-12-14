﻿jQuery(document).ready(function () {
    jQuery("#menu-icon").on("click", function () { jQuery(".sf-menu").slideToggle(); jQuery(this).toggleClass("active"); }); if (jQuery('.container').width() < 724) {
        jQuery('.sf-menu').removeClass('sf-js-enabled').find('li.parent').append('<strong></strong>'); jQuery('.sf-menu li.parent strong').on("click", function () {
            if (jQuery(this).attr('class') == 'opened') { jQuery(this).removeClass().parent('li.parent').find('> ul').slideToggle(); }
            else { jQuery(this).addClass('opened').parent('li.parent').find('> ul').slideToggle(); } 
        });
    }; if (jQuery('.container').width() < 724) { jQuery('.truncated span').click(function () { jQuery(this).parent().find('.truncated_full_value').stop().slideToggle(); }) }
    else { jQuery('.truncated span').hover(function () { jQuery(this).parent().find('.truncated_full_value').stop().slideToggle(); }) }; if (jQuery('.container').width() < 724) {
        jQuery.fn.slideFadeToggle = function (speed, easing, callback) { return this.animate({ opacity: 'toggle', height: 'toggle' }, speed, easing, callback); }; jQuery('.box-collateral').not('.box-up-sell').find('h2').append('<span class="toggle"></span>'); jQuery('.form-add').find('.box-collateral-content').css({ 'display': 'block' }).parents('.form-add').find('> h2 > span').addClass('opened'); jQuery('.box-collateral > h2').click(function () {
            OpenedClass = jQuery(this).find('> span').attr('class'); if (OpenedClass == 'toggle opened') { jQuery(this).find('> span').removeClass('opened'); }
            else { jQuery(this).find('> span').addClass('opened'); }
            jQuery(this).parents('.box-collateral').find(' > .box-collateral-content').slideFadeToggle()
        });
    }; if (jQuery('.container').width() < 724) {
        jQuery('.sidebar .block .block-title').append('<span class="toggle"></span>'); jQuery('.sidebar .block .block-title').on("click", function () {
            if (jQuery(this).find('> span').attr('class') == 'toggle opened') { jQuery(this).find('> span').removeClass('opened').parents('.block').find('.block-content').slideToggle(); }
            else { jQuery(this).find('> span').addClass('opened').parents('.block').find('.block-content').slideToggle(); } 
        });
    }; if (jQuery('.container').width() < 724) {
        jQuery('.footer .footer-col > h4').append('<span class="toggle"></span>'); jQuery('.footer h4').on("click", function () {
            if (jQuery(this).find('span').attr('class') == 'toggle opened') { jQuery(this).find('span').removeClass('opened').parents('.footer-col').find('.footer-col-content').slideToggle(); }
            else { jQuery(this).find('span').addClass('opened').parents('.footer-col').find('.footer-col-content').slideToggle(); } 
        });
    }; if (jQuery('.container').width() > 800) {
        jQuery('.header-button ul').css({ 'display': 'none' }); jQuery('.header-button').not('.top-login').hover(function () {
            jQuery(this).find('a').css({ 'background-color': 'transparent' }).parent().find('ul').toggle()
            jQuery(this).addClass('active');
        }, function () {
            jQuery(this).find('a').css({ 'background-color': 'transparent' }).parent().find('ul').toggle()
            jQuery(this).removeClass('active');
        });
    }
    else {
        jQuery('.header-button').not('.top-login').click(function () {
            Ulheight = jQuery(this).find('ul').css('display'); if (Ulheight == 'none') { jQuery('.header-button').find('ul').hide(0); jQuery(this).find('ul').show(0); jQuery(this).find('a').addClass('active'); }
            else { jQuery(this).find('ul').hide(0); jQuery(this).find('a').removeClass('active'); } 
        })
    }; jQuery('.products-grid .add-to-links li > a ').tooltip('hide')
    qwe = jQuery('.lang-list ul li span').text(); jQuery('.lang-list > a').text(qwe); jQuery('.block-cart-header .cart-content').hide(); if (jQuery('.container').width() < 800) { jQuery('.block-cart-header .summary, .block-cart-header .cart-content, .block-cart-header .empty').click(function () { jQuery('.block-cart-header .cart-content').stop(true, true).slideToggle(300); }) }
    else { jQuery('.block-cart-header .summary, .block-cart-header .cart-content, .block-cart-header .empty').hover(function () { jQuery('.block-cart-header .cart-content').stop(true, true).slideDown(400); }, function () { jQuery('.block-cart-header .cart-content').stop(true, true).delay(400).slideUp(300); }); };
}); jQuery(function () { jQuery(window).scroll(function () { if (jQuery(this).scrollTop() > 100) { jQuery('#back-top').fadeIn(); } else { jQuery('#back-top').fadeOut(); } }); jQuery('#back-top a').click(function () { jQuery('body,html').stop(false, false).animate({ scrollTop: 0 }, 800); return false; }); }); jQuery(document).ready(function () { jQuery('.sidebar .block').last().addClass('last_block'); jQuery('.sidebar .block').first().addClass('first'); jQuery('.box-up-sell li').eq(2).addClass('last'); jQuery(' .form-alt li:last-child').addClass('last'); jQuery('.product-collateral #customer-reviews dl dd, #cart-sidebar .item').last().addClass('last'); jQuery('.product-view .product-img-box .more-views li:nth-child(4)').last().addClass('item-4'); jQuery('.header .row-2 .links').first().addClass('LoginLink'); jQuery('#checkout-progress-state li:odd').addClass('odd'); jQuery('.product-view .product-img-box .product-image').append('<span></span>'); if (jQuery('.container').width() < 766) { jQuery('.my-account table td.order-id').prepend('<strong>Order #:</strong>'); jQuery('.my-account table td.order-date').prepend('<strong>Date: </strong>'); jQuery('.my-account table td.order-ship').prepend('<strong>Ship To: </strong>'); jQuery('.my-account table td.order-total').prepend('<strong>Order Total: </strong>'); jQuery('.my-account table td.order-status').prepend('<strong>Status: </strong>'); jQuery('.my-account table td.order-sku').prepend('<strong>SKU: </strong>'); jQuery('.my-account table td.order-price').prepend('<strong>Price: </strong>'); jQuery('.my-account table td.order-subtotal').prepend('<strong>Subtotal: </strong>'); jQuery('.multiple-checkout td.order-qty, .multiple-checkout th.order-qty').prepend('<strong>Qty: </strong>'); jQuery('.multiple-checkout td.order-shipping, .multiple-checkout th.order-shipping, ').prepend('<strong>Send To: </strong>'); jQuery('.multiple-checkout td.order-subtotal, .multiple-checkout th.order-subtotal').prepend('<strong>Subtotal: </strong>'); jQuery('.multiple-checkout td.order-price, .multiple-checkout th.order-price').prepend('<strong>Price: </strong>'); } }); jQuery(window).bind('load resize', function () { var maxHeight = 0; function setHeight(column) { column = jQuery(column); column.each(function () { if (jQuery(this).height() > maxHeight) { maxHeight = jQuery(this).height(); ; } }); column.height(maxHeight); }; sw = jQuery('.container').width(); if (sw > 723) { setHeight('.products-grid .product-shop'); } else { jQuery('.products-grid .product-shop').removeAttr('style'); }; }); jQuery(document).ready(function () {
    if (jQuery('.container').width() < 450) { jQuery('.related-carousel').jcarousel({ vertical: false, visible: 1, scroll: 1 }); }
    else { jQuery('.related-carousel').jcarousel({ vertical: false, visible: 3, scroll: 1 }); } 
});