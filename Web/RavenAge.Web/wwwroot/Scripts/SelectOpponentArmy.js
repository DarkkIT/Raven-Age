$(".opponent-select").each(function () {
    $(this).click(function () {

        let userId = $(this).attr('data-defenderId');
        let archers = $(this).attr('data-archers');
        let infantry = $(this).attr('data-infantry');
        let cavalry = $(this).attr('data-cavalry');
        let artillery = $(this).attr('data-artillery');

        $(".opponent div.unit").each(function () {

            if ($(this).hasClass('archers')) {
                $(this).text(`${archers}`);
            }
            else if ($(this).hasClass('infantry')) {
                $(this).text(`${infantry}`);
            }
            else if ($(this).hasClass('cavalry')) {
                $(this).text(`${cavalry}`);
            }
            else if ($(this).hasClass('artillery')) {
                $(this).text(`${artillery}`);
            }
        })
    })
});