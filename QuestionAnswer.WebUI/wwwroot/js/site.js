document.getElementById("accordion").onclick = function () {
    var x = document.getElementById("collapseBody");
    if (x.style.display === "none") {
        x.style.display = "flex";
    } else {
        x.style.display = "none";
    }
};

document.getElementById("accordion1").onclick = function () {
    var x = document.getElementById("collapseBody1");
    if (x.style.display === "none") {
        x.style.display = "flex";
    } else {
        x.style.display = "none";
    }
};

document.getElementById("accordion2").onclick = function () {
    var x = document.getElementById("collapseBody2");
    if (x.style.display === "none") {
        x.style.display = "flex";
    } else {
        x.style.display = "none";
    }
};

$(document).ready(function () {
    var chooseDate = $("#chooseDate");
    var chooseDateForCategory = $("#chooseDateForCategory");

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

    chooseDateForCategory.change(function (e) {
        $("#disabledOption2").prop("disabled", true);
        $("#showMessage2").hide();
        var jsonData = JSON.stringify({
            DateForCategory: e.target.value
        });

        $.ajax({
            type: "POST",
            url: "/Stats/Index",
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            data: jsonData,
            success: function (data) {
                drawChart2(data);
            }
        })
    });

    $(window).resize(function () {
        drawBasic();
        drawChart2();
        drawChart();
    });
});

google.charts.load('current', { packages: ['corechart', 'bar'] });
google.charts.setOnLoadCallback(drawBasic);

google.charts.load('current', { 'packages': ['corechart'] });
google.charts.setOnLoadCallback(drawChart);

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

//Kategorilere Göre Başarı Oranı Görüntüle
function drawChart2(data) {
    var arr = [];
    for (var i = 0; i < data.subCategoryNames.length; i++) {
        arr[i] = [data.subCategoryNames[i], data.successRate[i], "#1B9E77"]
    }

    var data = google.visualization.arrayToDataTable([
        ["Stats", "Başarı Oranınız", { role: "style" }],
        ...arr
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
        title: "Girilen Tarihe Göre Soru Kategorilerindeki Başarı Durumu",
        height: 400,
        is3D: true,
        vAxis: {
            format: '#'
        },
        bar: { groupWidth: "95%" },
        legend: { position: "none" },
    };

    var chart = new google.visualization.ColumnChart(document.getElementById("columnchart_values2"));
    chart.draw(view, options);
}

//Son Üç Teste Göre Değişimi Görüntüle
function drawChart() {
    var lastDate = document.getElementById("lastDate").value;
    var secondDate = document.getElementById("secondDate").value;
    var firstDate = document.getElementById("firstDate").value;
    var lastDatePoint = document.getElementById("lastDatePoint").value;
    var secondDatePoint = document.getElementById("secondDatePoint").value;
    var firstDatePoint = document.getElementById("firstDatePoint").value;

    var data = google.visualization.arrayToDataTable([
        ['Tarih', 'Not'],
        [firstDate, parseInt(firstDatePoint)],
        [secondDate, parseInt(secondDatePoint)],
        [lastDate, parseInt(lastDatePoint)]
    ]);

    var options = {
        title: 'Son Üç Test Sonuçları',
        hAxis: { title: 'Son Üç Test Tarihi', titleTextStyle: { color: '#333' } },
        height: 400,
        vAxis: { minValue: 0 }
    };

    var chart = new google.visualization.AreaChart(document.getElementById('chart_div'));
    chart.draw(data, options);
}