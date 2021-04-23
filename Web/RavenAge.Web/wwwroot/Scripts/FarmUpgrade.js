import { updateResource } from '../Scripts/UpdateResource.js';

$("#FarmLevel").click(function () {


    $.ajax({
        type: "GET",
        url: "/api/Farm",
        success: function (data) {

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