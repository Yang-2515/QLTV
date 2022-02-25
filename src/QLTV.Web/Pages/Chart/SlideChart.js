Chart.defaults.color = "#ffffff";

var config_1 = {
    type: 'line',

    data: {
        labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May'],
        datasets: [{
            label: 'Reader',
            data: [3, 12, 6, 18, 15],
            backgroundColor: 'rgba(255, 99, 132, 1)',
            stack: 'combined',
            type: 'bar'
        },
        {
            label: 'Money',
            data: [5, 8, 4, 6, 8],
            backgroundColor: 'rgba(255, 254, 0, 1)',
            borderColor: 'rgba(255, 254, 0, 1)',
            stack: 'combined',
            type: 'line',
        }],
    },

    options: {
        scales: {
            y: {
                beginAtZero: true,
                ticks: {
                    stepSize: 3,
                }
            }
        }
    },
}

var Chart_1 = document.getElementById('slide-3-chart-1').getContext('2d');
new Chart(Chart_1, config_1);

var config_2 = {
    type: 'line',

    data: {
        labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May'],
        datasets: [{
            label: 'Reader',
            data: [3, 12, 6, 18, 15],
            borderColor: 'rgba(255, 99, 132, 1)',
            backgroundColor: 'rgba(255, 99, 132, 1)',
            cubicInterpolationMode: 'monotone',
        },
        {
            label: 'Money',
            data: [5, 8, 4, 6, 8],
            backgroundColor: 'rgba(255, 254, 0, 1)',
            borderColor: 'rgba(255, 254, 0, 1)',
            cubicInterpolationMode: 'monotone',
        },
        {
            label: 'Borrow',
            data: [5, 9, 10, 20, 16],
            borderColor: 'rgba(75, 192, 192, 1)',
            backgroundColor: 'rgba(75, 192, 192, 1)',
            cubicInterpolationMode: 'monotone',
        },
        ],
    },

    options: {
        scales: {
            y: {
                beginAtZero: true,
                ticks: {
                    stepSize: 3,
                }
            }
        }
    },
}

var Chart_2 = document.getElementById('slide-3-chart-2').getContext('2d');
new Chart(Chart_2, config_2);
