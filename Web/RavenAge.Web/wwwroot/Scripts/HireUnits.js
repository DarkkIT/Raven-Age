import { updateResource } from './UpdateResource.js';

$("input[value='Hire']").each(function (el) {
        $(this).click(function () {

            let input = $(this).prev().children('input');
            let quantity = parseInt(input.val())
            input.val('0');
            let unit = input.attr('name');
            let data = {};
            data[`${unit}`] = quantity;
            let cityId = $('#cityId').val();
            data['cityId'] = cityId;
            console.log(cityId);

            var antiForgeryToken = $('input[name=__RequestVerificationToken]').val();

            $.ajax({
                type: "POST",
                url: "/api/Barracks",
                data: JSON.stringify(data),
                dataType: 'json',
                contentType: 'application/json',
                headers: {
                    'X-CSRF-TOKEN': antiForgeryToken
                },
                
                success: function (data) {

                    console.log(data);
                    updateResource(data);

                    //let newUnitQuantity = Number($(`#${data.unitType}`).text().split(`${data.unitType} `).filter(Boolean)) + data.unitQuantity;
                    $(`#${data.unitType}`).text(`${data.unitType} ${data.unitQuantity}`)
                },
            })

        })
    })
