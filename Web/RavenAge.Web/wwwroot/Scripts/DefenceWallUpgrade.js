import { updateResource } from "./UpdateResource.js"

$(`#DefenceWallUpgrade`).click(function () {
    $.ajax({
        url: '/api/Defencewall',
        type: 'GET',

        success: function (data) {
            if (data.isUpgraded) {
                updateResource();

                $('#DefenceWallSilverUpgradeCost').text(`Silver: ${data.silverUpgradeCost}`);
                $('#DefenceWallStoneUpgradeCost').text(`Stone: ${data.stoneUpgradeCost}`);
                $('#DefenceWallWoodUpgradeCost').text(`Wood: ${data.woodUpgradeCost}`);

                $('#DefencePoints').text(`Curent defence score: ${data.defencePoints}`);
            }
        }
    })
})