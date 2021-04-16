$(`#DefenceWallUpgrade`).click(function () {
    $.ajax({
        url: '/api/Defencewall',
        type: 'GET',

        success: function (data) {
            if (data.isUpgraded) {
                $('span.resource').each(function (index) {

                    if ($(this).text().includes('Silver')) {
                        $(this).text(`Silver - ${data.silverAvailable}`);
                    }

                    else if ($(this).text().includes('Stone')) {
                        $(this).text(`Stone - ${data.stoneAvailable}`);
                    }

                    else {
                        $(this).text(`Wood - ${data.woodAvailable}`);
                    }

                    $('#DefenceWallSilverUpgradeCost').text(`Silver: ${data.silverUpgradeCost}`);
                    $('#DefenceWallStoneUpgradeCost').text(`Stone: ${data.stoneUpgradeCost}`);
                    $('#DefenceWallWoodUpgradeCost').text(`Wood: ${data.woodUpgradeCost}`);

                    $('#DefencePoints').text(`Curent defence score: ${data.defencePoints}`);
                })
            }
        }
    })
})