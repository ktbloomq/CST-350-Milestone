// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    $(document).bind("contextmenu", function (e) {
        e.preventDefault();
    });
    $(document).on("mousedown", ".game-button", function (event) {
        //event.preventDefault();
        let buttonNumber = $(this).val();
        switch (event.which) {
            case 1:
                //console.log(buttonNumber);
                getUpdatedCells(buttonNumber);
                break;
            case 3:
                // console.log("right");
                doButtonUpdate(buttonNumber, "/Game/Flag");
                break;
            default:
            // console.log("nothing");

        }
    });
});
//let test;
function getUpdatedCells(buttonNumber) {
    $.ajax({
        datatype: 'json',
        method: 'POST',
        url: '/Game/Reveal',
        data: {
            'buttonNumber': buttonNumber
        },
        success: function (data) {
            //test = data;
            if (data.status === "lose") {
                window.location.href = "/Game/Lose";
            }
            for (let i = 0; i < data.length; i++) {
                doButtonUpdate(data[i], "/Game/ShowOneButton");
            }
        }
    });
}
function doButtonUpdate(buttonNumber, urlString) {
    $.ajax({
        datatype: "json",
        method: "POST",
        url: urlString,
        data: {
            "buttonNumber": buttonNumber
        },
        success: function (data) {
            //console.log(data);
            if (data.status === "lose") {
                window.location.href = "/Game/Lose";
            } else if (data.status === "win") {
                window.location.href = "/Game/Win";
            } else {
                $("#" + buttonNumber).html(data);
            }
        }
    });
}