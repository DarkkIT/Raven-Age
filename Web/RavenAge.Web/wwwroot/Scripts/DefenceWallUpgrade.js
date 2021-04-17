import { updateResource } from '../Scripts/UpdateResource.js';

$(`#DefenceWallUpgrade`).click(function () {
    $.ajax({
        url: '/api/Defencewall',
        type: 'GET',

        success: function (data) {
            if (data.isUpgraded) {
                updateResource(data);

                $('#DefenceWallSilverUpgradeCost').text(`Silver: ${data.silverUpgradeCost}`);
                $('#DefenceWallStoneUpgradeCost').text(`Stone: ${data.stoneUpgradeCost}`);
                $('#DefenceWallWoodUpgradeCost').text(`Wood: ${data.woodUpgradeCost}`);

                $('#DefencePoints').text(`Curent defence score: ${data.defencePoints}`);

            }
        }
    })
})