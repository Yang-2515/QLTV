var NameCategory = []
var CountBorrow = []
var NumberBookInCategory = []
var ColorForCategory_TopCategory_RGB = []
var ColorForCategory_TopCategory_RGBA = []
var MaxCountBorrow = 0
$(function () {
    qLTV.thuVien.borrow.getListTopCategory({}).then(function (result) {
        for (var item of result) {
            NameCategory.push(item.category.nameCategory)
            CountBorrow.push(item.countBorrow)
            NumberBookInCategory.push(item.numberBookInCategory)
            ColorForCategory_TopCategory_RGB.push(ColorForCategory_RGB[item.category.nameCategory])
            ColorForCategory_TopCategory_RGBA.push(ColorForCategory_RGBA[item.category.nameCategory])

            if (MaxCountBorrow < item.countBorrow) {
                MaxCountBorrow = item.countBorrow
            }
        }
    })
})

setTimeout(function () {
    var config_TopCategory_PolarArea = {
        type: 'polarArea',

        data: {
            labels: NameCategory,
            datasets: [{
                label: 'Reader',
                data: CountBorrow,
                backgroundColor: ColorForCategory_TopCategory_RGB,
            }],
        },

        plugins: [ChartDataLabels],
        options: {
            //maintainAspectRatio: false,
            layout: {
                padding: {
                    top: 30
                }
            },

            plugins: {
                datalabels: {
                    display: true,
                    color: 'black',
                    align: 'center',
                    anchor: 'center',
                    font: {
                        weight: 'bold',
                        size: 16,
                    }
                },

                title: {
                    display: true,
                    text: 'Number Of Books Borrowed By Category',
                    font: {
                        size: 20,
                    },
                    padding: {
                        bottom: 30
                    }
                },

                legend: {
                    position: 'right',
                    labels: {
                        font: {
                            size: 16,
                        },
                        padding: 40
                    },
                },
            },

            scales: {
                r: {
                    display: true,

                    ticks: {
                        display: false,
                        stepSize: 10,
                        backgroundColor: 'white',
                        labels: {
                            font: {
                                size: 40,
                            },
                        },
                        font: {
                            size: 40,
                            color: '#05bae4',
                            backgroundColor: '#05bae4'
                        },
                        fontSize: 40,
                    },
                    min: 0,
                    max: MaxCountBorrow,
                },
            }
        },
    }

    var TopCategoryChartElement = document.getElementById('TopCategoryChart').getContext('2d');
    new Chart(TopCategoryChartElement, config_TopCategory_PolarArea);

    var config_TopCategoryDetail = {
        type: 'bar',

        data: {
            labels: NameCategory,
            datasets: [
                {
                    label: 'Number Of Books In Category',
                    data: NumberBookInCategory,
                    backgroundColor: ColorForCategory_TopCategory_RGB,
                },
                {
                    label: 'Number Of Books Borrowed',
                    data: CountBorrow,
                    backgroundColor: ColorForCategory_TopCategory_RGBA,
                    borderColor: ColorForCategory_TopCategory_RGB,
                    borderWidth: 2
                },
            ],
        },
        options: {
            plugins: {
                title: {
                    display: true,
                    text: 'Distributing Borrowed Books In Categories',
                    font: {
                        size: 20,
                    },
                    //color: '#05bae4',
                },
                legend: {
                    display: false,
                },
            },
            scales: {
                x: {
                    beginAtZero: false,
                    //stacked: true,
                    grid: {
                        borderColor: 'white',
                        color: 'black',
                    },
                },
                y: {
                    beginAtZero: true,
                    //stacked: true,
                    grid: {
                        borderColor: 'white',
                        color: 'black',
                    },
                    ticks: {
                        stepSize: 5,
                    },
                }
            }
        },
    }

    var TopCategoryDetail_Chart = document.getElementById('TopCategoryChart_Detail').getContext('2d');
    new Chart(TopCategoryDetail_Chart, config_TopCategoryDetail);
}, 1000)


