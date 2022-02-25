document.querySelector('.fa-hands-helping').nextElementSibling.style.color = 'var(--blue-color)' // css

$(function () {
    var l = abp.localization.getResource('QLTV');

    var createModal = new abp.ModalManager(abp.appPath + 'ThuVien/Borrow/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'ThuVien/Borrow/EditModal');

    var dataTable = $('#BorrowTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[4, "asc"]],
            searching: false,
            scrollX: true,
            ordering: false,
            ajax: abp.libs.datatables.createAjax(qLTV.thuVien.borrow.getList),
            columnDefs: [
                {
                    title: l('No'),
                    render: function (data, type, full, meta) {
                        var table = $('#BorrowTable').DataTable();
                        var info = table.page.info();
                        return info.page * table.page.len() + meta.row + 1;
                    },
                    className: "text-center p-2",
                    width: "5%"
                },

                {
                    title: l('Date borrow'),
                    data: "dateBorrow",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toFormat('dd/MM/yyyy');
                    },
                    className: "text-center",
                    width: "16%"
                },
                {
                    title: l('Date return'),
                    data: "dateReturn",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toFormat('dd/MM/yyyy');
                    },
                    className: "text-center",
                    width: "16%"
                },
                {
                    title: l('Is return'),
                    data: "isReturnBook", render: function (data) {
                        var htmlRender = '';
                        if (data == true) {
                            htmlRender += '<div class="d-flex justify-content-center align-items-center"> <i class="fas fa-check"></i> </div>';
                        }
                        else  {
                            htmlRender += '<div class="d-flex justify-content-center align-items-center"> <i class="fas fa-times"></i> </div>';
                        }
                        return htmlRender;
                    },
                    className: "text-center",
                    width: "10%"
                },
                {
                    title: l('Book Borrow'),
                    data: "bookBorrow",
                    className: "text-center",
                    width: "24%"
                },
                {
                    title: l('Reader Borrow'),
                    data: "readerBorrow",
                    className: "text-center",
                    width: "24%"
                },
                {
                    className: "action_table",
                    data: "id", render: function (data) {
                        var htmlRender = '';
                        if (abp.auth.isGranted('QLTV.Borrow.Delete')) {
                            htmlRender += '<button title="Xóa" class="btn-action btn-delete" _type="delete" type="button" _id="'
                                + data + '"><i class="fa fa-trash-o"></i> </button>';
                        }
                        return htmlRender;
                    },
                    className: "text-center p-2",
                    width: "5%"
                }
            ],
            "fnDrawCallback": function (oSettings) {
                if ($('#BorrowTable').DataTable().page.info().pages < 2) {
                    $('.dataTable_footer').hide();
                } else {
                    $('.dataTable_footer').show();
                }
            }
        })
    );

    $('#BorrowTable tbody').on('click', 'button', function () {
        var id = $(this).attr("_id");
        if ($(this).attr("_type") === "delete") {
            abp.message.confirm(
                l('MsgDelete'),
                l('MsgDeleteTitle'),
                function (isConfirmed) {
                    if (isConfirmed) {
                        qLTV.thuVien.borrow
                            .delete(id)
                            .then(function () {
                                abp.notify.success(l('SuccessfullyDeleted'));
                                dataTable.ajax.reload();
                            });
                    }
                });
        }
    });

    createModal.onResult(function () {
        dataTable.ajax.reload();
        abp.notify.success(l('SuccessfullyCreated'));
    });

    editModal.onResult(function () {
        dataTable.ajax.reload(null, false);
        abp.notify.success(l('SuccessfullyEdited'));
    });

    $('#NewBorrow').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

    $('#Search').click(function () {
        Search();
    });

    $("#keywordCombobox").on('change', function () {
        Search();
    });

    $('#BorrowTable').on('dblclick', 'tbody tr', function () {
        if (abp.auth.isGranted('QLTV.Borrow.Update')) {
            var id = dataTable.row(this).data()['id'];
            editModal.open({ id: id });
        }
    });
    
    function Search() {
        dataTable.destroy();
        var input = {
            'keyword': $("#keysearch").val(),
            'skipCount': 0,
            'maxResultCount': 10,
            'keywordCombobox': $("#keywordCombobox").val(),
        }
        dataTable = $('#BorrowTable').DataTable(abp.libs.datatables.normalizeConfiguration({
                serverSide: true,
                paging: true,
                order: [[4, "asc"]],
                searching: false,
                scrollX: true,
                ordering: false,
                ajax: abp.libs.datatables.createAjax(qLTV.thuVien.borrow.getIsReturnBook, function () {
                    return input;
                }),
                columnDefs: [
                    {
                        title: l('No'),
                        render: function (data, type, full, meta) {
                            var table = $('#BorrowTable').DataTable();
                            var info = table.page.info();
                            return info.page * table.page.len() + meta.row + 1;
                        },
                        className: "text-center p-2",
                        width: "5%"
                    },

                    {
                        title: l('Date borrow'),
                        data: "dateBorrow",
                        render: function (data) {
                            return luxon
                                .DateTime
                                .fromISO(data, {
                                    locale: abp.localization.currentCulture.name
                                }).toFormat('dd/MM/yyyy');
                        },
                        className: "text-center",
                        width: "16%"
                    },
                    {
                        title: l('Date return'),
                        data: "dateReturn",
                        render: function (data) {
                            return luxon
                                .DateTime
                                .fromISO(data, {
                                    locale: abp.localization.currentCulture.name
                                }).toFormat('dd/MM/yyyy');
                        },
                        className: "text-center",
                        width: "16%"
                    },
                    {
                        title: l('Is return'),
                        data: "isReturnBook", render: function (data) {
                            var htmlRender = '';
                            if (data == true) {
                                htmlRender += '<div class="d-flex justify-content-center"> <i class="fas fa-check"></i> </div>';
                            }
                            else {
                                htmlRender += '<div class="d-flex justify-content-center"> <i class="fas fa-times"></i> </div>';
                            }
                            return htmlRender;
                        },
                        className: "text-center",
                        width: "10%"
                    },
                    {
                        title: l('Book Borrow'),
                        data: "bookBorrow",
                        className: "text-center",
                        width: "24%"
                    },
                    {
                        title: l('Reader Borrow'),
                        data: "readerBorrow",
                        className: "text-center",
                        width: "24%"
                    },
                    {
                        className: "action_table",
                        data: "id", render: function (data) {
                            var htmlRender = '';
                            if (abp.auth.isGranted('QLTV.Borrow.Delete')) {
                                htmlRender += '<button title="Xóa" class="btn-action btn-delete" _type="delete" type="button" _id="'
                                    + data + '"><i class="fa fa-trash-o"></i> </button>';
                            }
                            return htmlRender;
                        },
                        className: "text-center p-2",
                        width: "5%"
                    }
                ],
                "fnDrawCallback": function (oSettings) {
                    if ($('#BorrowTable').DataTable().page.info().pages < 2) {
                        $('.dataTable_footer').hide();
                    } else {
                        $('.dataTable_footer').show();
                    }
                }
            })
        );
    }

    $("input").on('keyup', function (e) {
        if (e.key === 'Enter' || e.keyCode === 13) {
            // Do something
            Search();
        }
    });

    //Check tránh trường hợp nhập khoảng trắng
    $("input").on('change', function () {
        $(this).val($(this).val().trim());
    });
})