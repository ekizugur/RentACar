


$(document).ready(function () {

    $("#btnSave").click(function (event) {
        event.preventDefault();
        var addUrl = app.Urls.categoryAddUrl;
        var redirectUrl = app.Urls.carAddUrl;

        var categoryAddDto = {
            CategoryName: $('input[id=CategoryName]').val()
        }
        var jsonData = JSON.stringify(categoryAddDto);
        console.log(jsonData);

        $.ajax({
            url: addUrl,
            type: "POST",
            contentType: "application/json; chatset=utf-8",
            dataType:"json",
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