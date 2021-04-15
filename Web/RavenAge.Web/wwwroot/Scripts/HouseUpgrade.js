import { updateResource } from "./UpdateResource.js"


$("#UpgradeHouse").click(function () {

    $.ajax({
        url: "/api/House",
        type: 'GET',

        success: function (data) {

            if (data.isUpgraded) {
                updateResource();

                    $('#HouseSilverUpgradeCost').text(`Silver: ${data.silverUpgradeCost}`);
                    $('#HouseStoneUpgradeCost').text(`Stone: ${data.stoneUpgradeCost}`);
                    $('#HouseWoodUpgradeCost').text(`Wood: ${data.woodUpgradeCost}`);

                    $('#HouseCurrentWorkers').text(`Curent workers: ${data.currentWorkersCount}`);
                    $('#HouseIncomePerWorker').text(`Income per Worker: ${data.incomePerWorker}`);
                    $('#HouseTotalIncome').text(`Silver income: ${data.incomePerWorker * data.currentWorkersCount}`);

                    $('#WorkerLimit').text(`Workers limit: ${data.workerLimit}`);

                })
            }
        }
    })
})