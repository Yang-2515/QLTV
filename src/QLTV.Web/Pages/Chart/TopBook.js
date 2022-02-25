var NumberBookBorrowedInTopBook = []
var IsReturn = [] // 2 giá trị : giá trị đầu là chưa trả, giá trị thứ 2 là đã trả rồi
var TopBookTable = $('#TopBookTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
    ajax: abp.libs.datatables.createAjax(qLTV.thuVien.borrow.getListTopBook, {}, function (result) {
        for (var i = 0; i < result.items.length; i++) {
            NumberBookBorrowedInTopBook.push(result.items[i].countBorrow)
        }

        return {
            data: result.items
        }
    }),
    columnDefs: [
        {
            render: function (data, type, full, meta) {
                var table = $('#TopBookTable').DataTable();
                var info = table.page.info();
                var IndexTable = info.page * table.page.len() + meta.row + 1
                return IndexTable.toString();
            },
            className: "text-center",
            width: "10%"

        },
        { data: "book.nameBook", className: "text-center m-0", width: "50%" },
        { data: "book.authorBook", className: "text-center", width: "20%" },
        { data: "book.categoryBook", className: "text-center", width: "20%" },
    ],
    createdRow: function (row, data, index) {
        $(row).addClass("STT_" + (index + 1).toString());
        if (index == 0)
            $(row).addClass("_1st_top-category");
        if (index == 1)
            $(row).addClass("_2nd_top-category");
        if (index == 2)
            $(row).addClass("_3rd_top-category");
        if (index == 3)
            $(row).addClass("_4th_top-category");
        if (index == 4)
            $(row).addClass("_5th_top-category");
    },

    "fnDrawCallback": function (oSettings) {
        if ($('#TopBookTable').DataTable().page.info().page < 2) {
            $('.dataTable_footer').hide();
        } else {
            $('.dataTable_footer').show();
        }
    }
}));

var config_TopBook_Bar = {
    type: 'bar',

    data: {
        labels: ['Top 1', 'Top 2', 'Top 3', 'Top 4', 'Top 5'],
        datasets: [{
            label: 'Number Of Books Borrowed',
            data: NumberBookBorrowedInTopBook,
            backgroundColor: ['rgba(230, 0, 57, 0.6)',
                            'rgba(27, 189, 49, 0.6)',
                            'rgba(255, 218, 0, 0.6)',
                            'rgba(2, 56, 252, 0.6)',
                            'rgba(255, 112, 10, 0.6)'],
            borderColor: ['rgba(230, 0, 57, 1)',
                        'rgba(27, 189, 49, 1)',
                        'rgba(255, 218, 0, 1)',
                        'rgba(2, 56, 252, 1)',
                        'rgba(255, 112, 10, 1)'],
            borderWidth: 2
        }],
    },

    options: {
        plugins: {
            title: {
                display: true,
                text: 'Top Books To Borrow',
                font: {
                    size: 20,
                },
            },
            legend: {
                display: false,
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

var TopBookChartElement = document.getElementById('TopBookChart').getContext('2d');
new Chart(TopBookChartElement, config_TopBook_Bar);


qLTV.thuVien.borrow.getIsReturnBookOnTime({}).then(function (result) {
    for (var i of result)
        IsReturn.push(i)
})

setTimeout(function () {
    var config_TopBook_IsReturn = {
        type: 'pie',

        data: {
            labels: ['Delay', 'On Time'],
            datasets: [
                {
                    label: 'Dataset 1',
                    data: IsReturn,
                    backgroundColor: ['rgba(230, 0, 57, 0.9)',
                        'rgba(2, 56, 252, 0.6)'],
                    borderColor: ['rgba(230, 0, 57, 1)',
                        'rgba(2, 56, 252, 1)'],
                    borderWidth: 2
                }
            ]
        },

        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                legend: {
                    position: 'bottom',
                    labels: {
                        font: {
                            size: 16,
                        },
                        padding: 40
                    },
                },
                title: {
                    display: true,
                    text: 'Number Of Books Returned On Time / Delay',
                    font: {
                        size: 20,
                    },
                    padding: {
                        top: 20,
                        bottom: 20
                    }
                },
            }
        },
    }

    var TopBookChart_IsReturnElement = document.getElementById('TopBookChart_IsReturn').getContext('2d');
    new Chart(TopBookChart_IsReturnElement, config_TopBook_IsReturn);
}, 1000)