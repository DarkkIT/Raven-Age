$(".playsound").on("click", function (e) {
    var url = $(this).attr('href');
    $("#playTarget").attr("src", url);
});