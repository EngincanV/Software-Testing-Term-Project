$(document).ready(function () {
    var chooseDate = $("#chooseDate");

    chooseDate.change(function (e) {
        $("#disabledOption").prop("disabled", true);
        $("#showMessage").hide();
        var jsonData = JSON.stringify({
            SelectedDate: e.target.value
        });

        $.ajax({
            type: "POST",
            url: "/Stats/Index",
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            data: jsonData,
            success: function (data) {
                drawBasic(data);
            }
        });
    });

    $(window).resize(function () {
        drawBasic();
    });
});


google.charts.load('current', { packages: ['corechart', 'bar'] });
google.charts.setOnLoadCallback(drawBasic);

//Tarihe Göre Not Görüntüle
function drawBasic(countOfTrue) {

    var data = google.visualization.arrayToDataTable([
        ["Stats", "Notunuz", { role: "style" }],
        ["Not", countOfTrue * 2, "#1B9E77"]
    ]);

    var view = new google.visualization.DataView(data);
    view.setColumns([0, 1,
        {
            calc: "stringify",
            sourceColumn: 1,
            type: "string",
            role: "annotation"
        },
    ]);

    var options = {
        title: "Girilen Tarihe Göre Not Durumu",
        height: 400,
        is3D: true,
        vAxis: {
            format: '#'
        },
        bar: { groupWidth: "95%" },
        legend: { position: "none" },
    };
    var chart = new google.visualization.ColumnChart(document.getElementById("columnchart_values"));
    chart.draw(view, options);
}
