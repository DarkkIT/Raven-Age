import { updateResource } from '../Scripts/UpdateResource.js';

$('#TownHallUpgrade').click(function () {
    $.ajax({
        type: "GET",
        url: "/api/TownHall",
        success: function (data) {
            console.log('success');

            if (data.isUpgraded) {

                updateResource(data);

                $('#TownHallSilverCost').text(`Silver: ${data.silverUpgradeCost}`);
                $('#TownHallWoodCost').text(`Wood: ${data.woodUpgradeCost}`);
                $('#TownHallStoneCost').text(`Stone: ${data.stoneUpgradeCost}`);
                $('#ArmyLimit').text(`Army limit: ${data.armyLimit}`);
            }

        }

    })
});