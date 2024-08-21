

//sidebar toggle



var sidebarOpen = false;

var sidebar = document.getElementById("sidebar");

function openSideabr() {

    if (!sidebarOpen) {
        sidebar.classList.add("sidebar-resposive");
        sidebarOpen = true;
    }
}

function closeSidebar() {
    if (sidebarOpen) {
        sidebar.classList.remove("sidebar-responsive");
        sidebarOpen = false;
    }
}



//---Charts---

var dataString = document.getElementById('myData').value;
var data = JSON.parse(dataString);


//--Bar Charts--
var barChartsOptions = {
    series: [{
        data: data
    }],
    chart: {
        type: 'bar',
        height: 350,
        toolbar: {
            show: false
        },
    },
    colors: [
        "#246dec",
        "#cc3c43",
        "#367952",
        "#f5b74f",
        "#4f35a1"

    ],
    plotOptions: {
        bar: {
            distributed: true,
            borderRadius: 4,
            horizontal: false,
            columnWidth: '40%',
        }
    },
    dataLabels: {
        enabled: false
    },
    legend: {
        show: false
    },
    xaxis: {
        categories: ["SMS", "ALL NETWORK DATA", "NIGHT SUFFER", "ALL NETWORK MINUTES"
        ],
    },
    yaxis: {
        title: {
            text: "count"
        }
    }
};

var barChart = new ApexCharts(document.querySelector("#bar-chart"), barChartsOptions);
barChart.render();




//--area chart--

var dataString = document.getElementById('myData1').value;
var data1 = JSON.parse(dataString);

var dataString = document.getElementById('myData2').value;
var data2 = JSON.parse(dataString);

var areaChart = {
    series: [{
        name: 'Happy',
        data: data1
    }, {
        name: 'UnHappy',
        data: data2
    }],
    chart: {
        height: 350,
        type: 'area',
        toolbar:{
            show: false,
        },
    },
    colors: ["#4f35a1", "#246dec"],
    dataLabels: {
        enabled:false,
    },
    stroke: {
        curve: 'smooth'
    },
    
    labels: ["SMS","ALL NETWORK DATA","ALL NETWORK MINUTES","NIGHT SUFFER"],
    markers: {
        size: 0
    },
    yaxis: [
        {
            title: {
                text: 'Happy Customers',
            },
        },
        {
            opposite: true,
            title: {
                text: 'Unhappy Customers',
            },
        },
    ],
    tooltip: {
        shared: true,
        intersect: false,
        
    }
};

var areaChart = new ApexCharts(document.querySelector("#area-chart"), areaChart);
areaChart.render();

//-------------Double Bar Chart

