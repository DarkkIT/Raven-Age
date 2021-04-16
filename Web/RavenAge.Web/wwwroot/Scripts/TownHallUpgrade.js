$('#TownHallUpgrade').click(function () {
    $.ajax({
        type: "GET",
        url: "/api/TownHall",
        success: function (data) {
            console.log('success');

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
                })

                $('#TownHallSilverCost').text(`Silver: ${data.silverUpgradeCost}`);
                $('#TownHallWoodCost').text(`Wood: ${data.woodUpgradeCost}`);
                $('#TownHallStoneCost').text(`Stone: ${data.stoneUpgradeCost}`);
                $('#ArmyLimit').text(`Army limit: ${data.armyLimit}`);
            }

        }

    })
});