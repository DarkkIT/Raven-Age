import { updateResource } from "./UpdateResource.js"

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
                $('#SilverAvailable').text('Silver - ' + ($('#SilverAvailable').text().split('Silver - ').filter(Boolean) - silverCost));

                $('#WoodAvailable').text('Wood - ' + ($('#WoodAvailable').text().split('Wood - ').filter(Boolean) - woodCost));

                $('#StoneAvailable').text('Stone - ' + ($('#StoneAvailable').text().split('Stone - ').filter(Boolean) - stoneCost));

                $('#CurrentFarmProduction').text(`Current Production: ${data.currentProduction}`);
                $('#NextLevelFarmProduction').text(`Next Level Production: ${data.nextLevelProduction}`);

                $('#FarmSilverCost').text(`Silver: ${data.silverUpgradeCost}`);
                $('#FarmWoodCost').text(`Wood: ${data.woodUpgradeCost}`);
                $('#FarmStoneCost').text(`Stone: ${data.stoneUpgradeCost}`);

            }
        }
    })
});