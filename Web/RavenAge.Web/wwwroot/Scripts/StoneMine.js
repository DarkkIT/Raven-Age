import { updateResource } from "./UpdateResource.js"

$(`#StoneMineUpgrade`).click(function () {

    $.ajax({
        url: '/api/StoneMine',
        type: 'GET',

        success: function (data) {

            if (data.isUpgraded) {
                updateResource()

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

