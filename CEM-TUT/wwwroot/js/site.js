// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var dataString = document.getElementById('myData1').value;
var data1 = JSON.parse(dataString);
(async () => {
  
    const topology = await fetch(
        'https://code.highcharts.com/mapdata/countries/za/za-all.topo.json'
    ).then(response => response.json());

    // Prepare demo data. The data is joined to map using value of 'hc-key'
    // property by default. See API docs for 'joinBy' for more info on linking
    // data and map.
    const data = [
        ['za-ec', data1[0]], ['za-np', data1[1]], ['za-nl', data1[2]], ['za-wc', data1[3]],
        ['za-nc', data1[4]], ['za-nw', data1[5]], ['za-fs', data1[6]], ['za-gt', data1[7]],
        ['za-mp', data1[8]]
    ];

    // Create the chart
    Highcharts.mapChart('container', {
        chart: {
            map: topology
        },

        title: {
            text: 'Geographical alerts'
        },

        subtitle: {
            text: 'Reported  alerts'
        },

        mapNavigation: {
            enabled: true,
            buttonOptions: {
                verticalAlign: 'bottom'
            }
        },

        colorAxis: {
            min: 0
        },

        series: [{
            data: data,
            name: 'Reported Areas',
            states: {
                hover: {
                    color: '#BADA55'
                }
            },
            dataLabels: {
                enabled: true,
                format: '{point.name}'
            }
        }]
    });

})();