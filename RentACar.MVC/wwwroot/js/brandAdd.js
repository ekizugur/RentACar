


$(document).ready(function () {

    $("#btnSaveBrand").click(function (event) {
        event.preventDefault();
        var addUrl = app.Urls.brandAddUrl;
        var redirectUrl = app.Urls.carAddUrl;

        var brandAddDto = {
            Name: $('input[id=BrandName]').val()
        }
        var jsonData = JSON.stringify(brandAddDto);
        console.log(jsonData);

        $.ajax({
            url: addUrl,
            type: "POST",
            contentType: "application/json; chatset=utf-8",
            dataType: "json",
            data: jsonData,
            success: function (data) {
                setTimeout(function () {
                    window.location.href = redirectUrl;
                }, 1500);
            },
            error: function () {

                console.log("Bir Hata oluştu");
            }

        });
    })

});