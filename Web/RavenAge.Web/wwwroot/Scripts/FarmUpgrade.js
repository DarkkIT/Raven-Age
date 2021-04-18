import { updateResource } from '../Scripts/UpdateResource.js';

$("#FarmLevel").click(function () {
    console.log('clicked!');

    const silverCost = $('#FarmSilverCost').text().split('Silver: ').filter(Boolean);
    const woodCost = $('#FarmWoodCost').text().split('Wood: ').filter(Boolean);
    const stoneCost = $('#FarmStoneCost').text().split('Stone: ').filter(Boolean);

    $.ajax({
        type: "GET",
        url: "/api/Farm",
        success: function (data) {
            console.log('success!');

            if (data.isUpgraded) {
                updateResource(data);


                $('#CurrentFarmProduction').text(`Current Production: ${data.currentProduction}`);
                $('#NextLevelFarmProduction').text(`Next Level Production: ${data.nextLevelProduction}`);

                $('#FarmSilverCost').text(`Silver: ${data.silverUpgradeCost}`);
                $('#FarmWoodCost').text(`Wood: ${data.woodUpgradeCost}`);
                $('#FarmStoneCost').text(`Stone: ${data.stoneUpgradeCost}`);

            }
        }
    })
});