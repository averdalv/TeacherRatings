
    var salesData = [
 { label: "voice1", color: "#3366CC" },
 { label: "voice2", color: "#DC3912" },
 { label: "voice3", color: "#FF9900" },
 { label: "voice4", color: "#109618" },
 { label: "voice5", color: "#990099" }
    ];

    //var svg = d3.select("#firstTab").append("svg").attr("width",700).attr("height",300);
    var svg = d3.select("#TabSvg").append("svg").attr("viewBox", "150 0 600 350");

    svg.append("g").attr("id", "quotesDonut");


    Donut3D.draw("quotesDonut", initData(), 450, 150, 130, 100, 30, 0);
    var str = "Всього голосів: " + $("#CountVoices").text();
    $("#firstVoices").append(str);

function changeData() {
    Donut3D.transition("quotesDonut", AjaxData(), 130, 100, 30, 0);
}

function initData() {
    return salesData.map(function (d) {
        var str = "#" + d.label;
        return{label:d.label,value:+$(str).text(),color:d.color}
    })
}


function AjaxData(values) {
    return salesData.map(function (d) {
        return { label: d.label, value: seles, color: d.color };
    });
}

function OnSuccess(data)
{
    var results = salesData.map(function (d,i) {
        return { label: d.label, value: data.voices[i], color: d.color };
    });
    Donut3D.transition("quotesDonut", results, 130, 100, 30, 0);
    var str = "Всього голосів: " + data.CountVoices;
    $("#firstVoices").empty().append(str);
}