$(`#SawMillUpgrade`).click(function () {
    $.ajax({
        url: '/api/SawMill',
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

                    $('#SawMillSilverUpgradeCost').text(`Silver: ${data.silverUpgradeCost}`);
                    $('#SawMillStoneUpgradeCost').text(`Stone: ${data.stoneUpgradeCost}`);
                    $('#SawMillWoodUpgradeCost').text(`Wood: ${data.woodUpgradeCost}`);

                    $('#SawMillCurrentProduction').text(`Current Production: ${data.currentProduction}`);
                    $('#SawMillNextLevelProduction').text(`Wood: ${data.nextLevelProduction}`);


                })
            }
        }
    })
})
