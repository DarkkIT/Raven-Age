function updateResource(data) {
    $('span.resource').each(function (index) {

        if ($(this).text().includes('Silver')) {


            if (data.silverAvailable > 999999) {
                $(this).text(`Silver - ${(data.silverAvailable * 1.0 / 1000000).toFixed(3)} M`);
            }
            else if (data.silverAvailable > 999) {
                $(this).text(`Silver - ${(data.silverAvailable * 1.0 / 1000).toFixed(2)} k`);
            }

            else{
                $(this).text(`Silver - ${data.silverAvailable}`);
            }

        }

        else if ($(this).text().includes('Stone')) {

            if (data.stoneAvailable > 999999) {
                $(this).text(`Stone - ${(data.stoneAvailable * 1.0 / 1000000).toFixed(3)} M`);
            }
            else if (data.stoneAvailable > 999) {
                $(this).text(`Stone - ${(data.stoneAvailable * 1.0 / 1000).toFixed(2)} k`);
            }

            else {
                $(this).text(`Stone - ${data.stoneAvailable}`);
            }

        }

        else {

            if (data.woodAvailable > 999999) {
                $(this).text(`Wood - ${(data.woodAvailable * 1.0 / 1000000).toFixed(3)} M`);
            }
            else if (data.woodAvailable > 999) {
                $(this).text(`Wood - ${(data.woodAvailable * 1.0 / 1000).toFixed(2)} k` );
            }

            else {
                $(this).text(`Wood - ${data.woodAvailable}`);
            }

        }
    })
}

export { updateResource };