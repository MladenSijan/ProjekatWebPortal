﻿$(document).ready(function () {
    $('.edit').on("click", function () {
        console.log('radi nova sskripta');
        setTimeout(
              function () {
                  $('input, textarea').each(function () {

                      if ($(this).val().length !== 0) {
                          $(this).prev().filter(".matDesignLabel").addClass("fokusiraniMatDesignLabel");
                      }
                      else {
                          console.log("prazan sam input")
                      }
                  });
              }, 200);
        


    });

});