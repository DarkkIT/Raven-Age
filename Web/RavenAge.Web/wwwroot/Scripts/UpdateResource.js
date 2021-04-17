function updateResource(data) {
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
    })
}

export { updateResource };