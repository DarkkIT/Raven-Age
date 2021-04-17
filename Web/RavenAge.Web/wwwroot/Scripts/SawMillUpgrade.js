import { updateResource } from '../Scripts/UpdateResource.js';

$(`#SawMillUpgrade`).click(function () {
    $.ajax({
        url: '/api/SawMill',
        type: 'GET',

        success: function (data) {
            if (data.isUpgraded) {
                updateResource(data);

                $('#SawMillSilverUpgradeCost').text(`Silver: ${data.silverUpgradeCost}`);
                $('#SawMillStoneUpgradeCost').text(`Stone: ${data.stoneUpgradeCost}`);
                $('#SawMillWoodUpgradeCost').text(`Wood: ${data.woodUpgradeCost}`);

                $('#SawMillCurrentProduction').text(`Current Production: ${data.currentProduction}`);
                $('#SawMillNextLevelProduction').text(`Next Level Production: ${data.nextLevelProduction}`);



            }
        }
    })
})
