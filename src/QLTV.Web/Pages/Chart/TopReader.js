Chart.defaults.color = "#ffffff";
var NumberBookInTopReader = []
var NameTopReader = []
var NameOfCategory_TopReader = []
var NumberBookOfCategory_TopReader = []
var IdReader = []

var ColorOfCategory_TopReader = []
$(function () {
    var TopReaderTable = $('#TopReaderTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: true,
        fixedColumns: true,
        fixedHeader: true,
        bLengthChange: false,
        scrollCollapse: true,
        ordering: false,
        pageLength: 5,
        ajax: abp.libs.datatables.createAjax(qLTV.thuVien.borrow.getListTopReader, {}, function (result) {
            for (var i = 0; i < result.items.length; i++) {
                NumberBookInTopReader.push(result.items[i].countBorrow)
                NameTopReader.push(result.items[i].reader.nameReader)
                IdReader.push(result.items[i].reader.id)
            }
            
            return {
                data: result.items
            }
        }),
        columnDefs: [
            {
                render: function (data, type, full, meta) {
                    var table = $('#TopReaderTable').DataTable();
                    var info = table.page.info();
                    var IndexTable = info.page * table.page.len() + meta.row + 1
                    if (IndexTable == 1)
                        return '<i class="fas fa-crown mr-2"></i>' + IndexTable.toString();
                    else if (IndexTable == 2) {
                        return '<i class="fab fa-draft2digital  mr-2"></i>' + IndexTable.toString();
                    }
                    else if (IndexTable == 3) {
                        return '<i class="fas fa-signal  mr-2"></i>' + IndexTable.toString();
                    }
                    else {
                        return IndexTable.toString();
                    }
                },
                className: "text-center",
                width: "13%"
            },
            { data: "reader.nameReader", className: "text-center m-0", width: "35%" },
            { data: "reader.age", className: "text-center", width: "14%" },
            { data: "reader.email", className: "text-center", width: "38%" },
        ],
        createdRow: function (row, data, index) {
            $(row).addClass("STT_" + (index+1).toString());
            if (index == 0)
                $(row).addClass("_1st_top-reader");
            if (index == 1)
                $(row).addClass("_2nd_top-reader");
            if (index == 2)
                $(row).addClass("_3rd_top-reader");
        },

        "fnDrawCallback": function (oSettings) {
            if ($('#TopReaderTable').DataTable().page.info().page < 2) {
                $('.dataTable_footer').hide();
            } else {
                $('.dataTable_footer').show();
            }
        }
    }));

})

//========================================
setTimeout(async function () {
    for (var i = 0; i < IdReader.length; i++) {
        await qLTV.thuVien.borrow.getListCategoryForReader(IdReader[i]).done(function (DataCategory) {
            var TempName = [], TempNumber = [], TempColor = []
            for (var j = 0; j < DataCategory.length; j++) {
                TempName.push(DataCategory[j].category.nameCategory)
                TempNumber.push(DataCategory[j].countBorrow)
                TempColor.push(ColorForCategory_RGB[DataCategory[j].category.nameCategory])
            }
            NameOfCategory_TopReader.push(TempName)
            NumberBookOfCategory_TopReader.push(TempNumber)
            ColorOfCategory_TopReader.push(TempColor)
        })
    }

    function Detail_TopReader(IndexReader = 0) {
        return {
            type: 'doughnut',

            data: {
                labels: NameOfCategory_TopReader[IndexReader],
                datasets: [{
                    data: NumberBookOfCategory_TopReader[IndexReader],
                    backgroundColor: ColorOfCategory_TopReader[IndexReader],
                    borderWidth: 1
                }],
            },

            options: {
                maintainAspectRatio: false,
                layout: {
                    padding: {
                        left: 250,
                        right: 250,
                    }
                },
                plugins: {
                    title: {
                        display: true,
                        text: `Details Of The Number Of Books Borrowed From "${NameTopReader[IndexReader]}"`,
                        font: {
                            size: 20,
                        },
                        padding: {
                            top: 10,
                            bottom: 30
                        },
                    },

                    legend: {
                        position: 'right',
                        labels: {
                            
                            font: {
                                size: 16,
                            },
                        }
                    },

                    scales: {
                        x: {
                            beginAtZero: true,
                        }
                    },
                },

            },

        }
    }

    var OnLeaveMyBuild_TopReader = {
        id: 'OnLeaveMyBuild_TopReader',
        beforeDraw: chart => {
            var ctx = chart.ctx;
            ChartEffectElement = document.querySelector('.ChartEffect')

            if (chart.tooltip._active && chart.tooltip._active.length) { // Kiểm tra xem có hover vào các cột ko

                if (ChartEffectElement) {
                    ChartEffectElement.classList.remove('ChartEffect')
                    document.querySelector(".STT_" + (chart.tooltip._active[0].index + 1).toString()).classList.add('ChartEffect');
                    $('#TopReaderChart_Detail').remove();
                    $('#text-show-info').remove();
                    $('#div_chart_detail').append('<canvas id="TopReaderChart_Detail"></canvas>');
                    var TopReaderChart_DetailElement = document.getElementById('TopReaderChart_Detail').getContext('2d');
                    var TopReaderChart_Detail = new Chart(TopReaderChart_DetailElement, Detail_TopReader(chart.tooltip._active[0].index));
                }
                else {
                    document.querySelector(".STT_" + (chart.tooltip._active[0].index + 1).toString()).classList.add('ChartEffect');
                }
            }
            else {
                if (ChartEffectElement)
                    ChartEffectElement.classList.remove('ChartEffect')
            }
        }
    }

    var config_TopReader_Bar = {
        type: 'bar',

        data: {
            labels: ['Top 1', 'Top 2', 'Top 3', 'Top 4', 'Top 5'],
            datasets: [{
                label: 'Number Of Books Borrowed',
                data: NumberBookInTopReader,
                backgroundColor: '#ef0078',
                borderWidth: 0
            }],
        },

        plugins: [OnLeaveMyBuild_TopReader],

        options: {
            plugins: {
                title: {
                    display: true,
                    text: 'Top Readers To Borrow Books',
                    font: {
                        size: 20,
                    },
                },

                tooltip: {
                    callbacks: {
                        label: function (context) {
                            var label = " "
                            label += context.dataset.label || '';
                            ChartEffectElement = document.querySelector('.ChartEffect')

                            if (label) {
                                label += ': ';
                            }
                            if (context.parsed.y !== null) {
                                label += context.parsed.y;
                            }
                            return label;
                        }
                    }
                },

            },

            scales: {
                x: {
                    beginAtZero: false,
                    grid: {
                        borderColor: 'white',
                        color: 'black',
                    },
                },
                y: {
                    beginAtZero: true,
                    grid: {
                        borderColor: 'white',
                        color: 'black',
                    },
                    ticks: {
                        stepSize: 1,
                    }
                }
            },
        },

    }

    var TopReaderChartElement = document.getElementById('TopReaderChart').getContext('2d');
    var TopReaderChart = new Chart(TopReaderChartElement, config_TopReader_Bar);

    var RowTopReaderTableElements = document.querySelectorAll('#TopReaderTable tr')
    for (var i = 1; i < RowTopReaderTableElements.length; i++) {
        RowTopReaderTableElements[i].addEventListener('mouseenter', function (e) {
            $('#TopReaderChart_Detail').remove();
            $('#div_chart_detail').append('<canvas id="TopReaderChart_Detail"></canvas>');
            var TopReaderChart_DetailElement = document.getElementById('TopReaderChart_Detail').getContext('2d');
            var TopReaderChart_Detail = new Chart(TopReaderChart_DetailElement, Detail_TopReader(e.target.classList[0][4] - 1));
            $('#text-show-info').remove();
        })
        //RowTopReaderTableElements[i].addEventListener('mouseleave', function (e) {
        //    console.log("roif i", i)
        //    $('#topreaderchart_detail').remove();
        //    //$('#div_chart_detail').append('<canvas id="topreaderchart_detail"></canvas>');
        //    //var TopReaderChart_DetailElement = document.getElementById('TopReaderChart_Detail').getContext('2d');
        //    //var TopReaderChart_Detail = new Chart(TopReaderChart_DetailElement, Detail_TopReader(0));
        //    //console.log(i)
        //})
    }
}, 1000)

//====================================================
