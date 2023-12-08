// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    console.log("..");
    var slideWidth = $('.slide').width();
    var slideCount = $('.slide').length;
    var totalWidth = slideWidth * slideCount;

    $('.slider').css('width', totalWidth);

    function nextSlide() {
        console.log(".,.")
        var currentMargin = parseInt($('.slider').css('margin-right'));
        if (currentMargin > -totalWidth + slideWidth) {
            $('.slider').animate({ 'margin-right': '-=' + slideWidth }, 'slow');
        }
    }

    function prevSlide() {
        console.log(".,.")
        var currentMargin = parseInt($('.slider').css('margin-right'));
        if (currentMargin < 0) {
            $('.slider').animate({ 'margin-right': '+=' + slideWidth }, 'slow');
        }
    }

    $('#nextBtn').click(function () {
        nextSlide();
    });

    $('#prevBtn').click(function () {
        prevSlide();
    });
});

