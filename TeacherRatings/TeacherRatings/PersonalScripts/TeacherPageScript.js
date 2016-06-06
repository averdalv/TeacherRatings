var salesData = [
 { label: "Basic", color: "#3366CC" },
 { label: "Plus", color: "#DC3912" },
 { label: "Lite", color: "#FF9900" },
 { label: "Elite", color: "#109618" },
 { label: "Delux", color: "#990099" }
];

//var svg = d3.select("#firstTab").append("svg").attr("width",700).attr("height",300);
var svg = d3.select("#TabSvg").append("svg").attr("viewBox", "150 0 600 350");

svg.append("g").attr("id", "quotesDonut");


Donut3D.draw("quotesDonut", randomData(), 450, 150, 130, 100, 30, 0);

function changeData() {
    Donut3D.transition("quotesDonut", randomData(), 130, 100, 30, 0);
}

function randomData() {
    return salesData.map(function (d) {
        return { label: d.label, value: 1000 * Math.random(), color: d.color };
    });
}
$(function () {
    $("ul li").bind('click', function () {

        $(".voices").text("Всього голосів: " + Math.ceil((Math.random() * 40)));
        changeData();
        preventDefault();

    })
});