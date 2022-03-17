$(function(){
  $(window).scroll(function(){
    var $header = $('#header');
    var isPositionFixed = ($header.css('position') === 'fixed');
    if ($(this).scrollTop() > 500 && !isPositionFixed){
      $header.css({'position': 'fixed', 'top': '0px'});
    }
    if ($(this).scrollTop() < 75 && isPositionFixed){
      $header.css({'position': 'static', 'top': '0px'});
    }
  });
});
