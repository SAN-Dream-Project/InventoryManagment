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

  /*Setting Every Input Field Label Width Same*/
  $(document).on('click', "button.btn.btn-success, button.btn.btn-info", function() {
    var maxWidth = 0;
    $("form .input-group").each(function(){
      var currentItemWidth = $(this).find(".input-group-text").outerWidth();
      if(currentItemWidth > maxWidth) {
        maxWidth = currentItemWidth;
      }
    });
    $("form .input-group").each(function(){
      $(this).find(".input-group-text").outerWidth(maxWidth+'px');
    });
  });
});
