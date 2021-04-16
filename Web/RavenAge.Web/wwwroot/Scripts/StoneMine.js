$(`#StoneMineUpgrade`).click(function () {

    $.ajax({
        url: '/api/StoneMine',
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

                    $('#StoneMineSilverUpgradeCost').text(`Silver: ${data.silverUpgradeCost}`);
                    $('#StoneMineStoneUpgradeCost').text(`Stone: ${data.stoneUpgradeCost}`);
                    $('#StoneMineWoodUpgradeCost').text(`Wood: ${data.woodUpgradeCost}`);

                    $('#StoneMineCurrentProduction').text(`Current Production: ${data.currentProduction}`);
                    $('#StoneMineNextLevelProduction').text(`Next Level Production: ${data.nextLevelProduction}`);


                })
            }
        }
    })
})

