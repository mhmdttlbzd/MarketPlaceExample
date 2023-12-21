// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
   
    var sWith = $('.ts').width() / 2;
    $('.slide').css('width', sWith);
    $('.ts').css('height', sWith);
    var slideWidth = $('.slide').width();
    var slideCount = $('.slide').length;
    var totalWidth = slideWidth * slideCount;

    $('.slider').css('width', totalWidth);

    function nextSlide() {
        
        var currentMargin = parseInt($('.slider').css('margin-right'));
        if (currentMargin > -totalWidth + slideWidth) {
            $('.slider').animate({ 'margin-right': '-=' + slideWidth }, 'slow');
        }
    }

    function prevSlide() {
        
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



   
    var msWith = $('.tm').width() / 2;

    $('.mSlide').css('width', msWith);
    $('.tm').css('height', msWith);

    var mSlideWidth = msWith;

    var mSlideCount = $('.mSlide').length;
    var mtotalWidth = mSlideWidth * mSlideCount;


    $('.mSlider').css('width', mtotalWidth);

    function mNextSlide() {
       
        var currentMargin = parseInt($('.mSlider').css('margin-right'));
        if (currentMargin > -mtotalWidth + mSlideWidth) {
            $('.mSlider').animate({ 'margin-right': '-=' + mSlideWidth }, 'slow');
        }
    }

    function mPrevSlide() {
        
        var currentMargin = parseInt($('.mSlider').css('margin-right'));
        if (currentMargin < 0) {
            $('.mSlider').animate({ 'margin-right': '+=' + mSlideWidth }, 'slow');
        }
    }

    $('#mNextBtn').click(function () {
        mNextSlide();
    });

    $('#mPrevBtn').click(function () {
        mPrevSlide();
    });
});

