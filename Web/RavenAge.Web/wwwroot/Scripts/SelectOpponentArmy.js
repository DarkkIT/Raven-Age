$(".opponent-select").each(function () {
    $(this).click(function () {

        let userToAttackId = $(this).attr('data-defenderId');
        userId = parseInt(userToAttackId);
        let hrefVal = $('#LaunchAttack').attr('href');
        if (!hrefVal.endsWith('/Attack')) {
            hrefVal = '/Arena/Attack'
        }
        hrefResult = hrefVal.concat('/').concat(userToAttackId);
        console.log(hrefResult);

        $('#LaunchAttack').attr('href', hrefResult);

        let archers = $(this).attr('data-archers');
        let infantry = $(this).attr('data-infantry');
        let cavalry = $(this).attr('data-cavalry');
        let artillery = $(this).attr('data-artillery');

        $('#LaunchAttack').removeClass('disabled');

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