
var dataString = document.getElementById('myData1').value;
var data1 = JSON.parse(dataString);

const ctx = document.getElementById('myChart');

new Chart(ctx, {
    type: 'bar',
    data: {
        labels: ['15-25', '25-35', '35-45', '45-55', '55-65', '65-75'],
        datasets: [{
            label: 'Number of Customers',
            data: data1,
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            y: {
                beginAtZero: true
            }
        }
    }
});

var dataString = document.getElementById('myData2').value;
var data2 = JSON.parse(dataString);

var donutChart = {
  
    series: data2,
    labels:["Male","Female"],
    chart: {
        type: 'donut',
    },
    responsive: [{
        breakpoint: 480,
        options: {
            chart: {
                width: 200
            },
            legend: {
                position: 'bottom'
            }
        }
    }]
};

var donutChart = new ApexCharts(document.querySelector("#donut-chart"), donutChart);
donutChart.render();