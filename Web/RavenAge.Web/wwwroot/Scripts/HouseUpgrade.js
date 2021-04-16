
$("#UpgradeHouse").click(function () {

    $.ajax({
        url: "/api/House",
        type: 'GET',

        success: function (data) {

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