    $("input[value='Hire']").each(function (el) {
        $(this).click(function () {

            var input = $(this).prev().children('input');
            var quantity = parseInt(input.val())
            input.val('0');
            var unit = input.attr('name');
            var data = {};
            data[`${unit}`] = quantity;
            console.log(data);

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

                    $('span.resource').each(function (index) {
                        var resource;
                        if ($(this).text().includes('Silver')) {
                            resource = (`Silver - ${Number($(this).text().split('Silver - ').filter(Boolean)) - data.silverSpent}`);
                            $(this).text(resource);
                        }
                        else {
                            resource = (`Wood - ${Number($(this).text().split('Wood - ').filter(Boolean)) - data.woodSpent}`);
                            $(this).text(resource);
                        }
                    })

                    var newUnitQuantity = Number($(`#${data.unitType}`).text().split(`${data.unitType} `).filter(Boolean)) + data.unitQuantity;
                    $(`#${data.unitType}`).text(`${data.unitType} ${newUnitQuantity}`)
                },
            })

        })
    })
