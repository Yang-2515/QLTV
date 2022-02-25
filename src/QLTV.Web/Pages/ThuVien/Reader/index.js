document.querySelector('.fa-book-reader').nextElementSibling.style.color = 'var(--blue-color)' // css

$(function () {
    var l = abp.localization.getResource('QLTV');

    var createModal = new abp.ModalManager(abp.appPath + 'ThuVien/Reader/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'ThuVien/Reader/EditModal');

    var dataTable = $('#ReaderTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        serverSide: true,
        paging: true,
        order: [[1, "asc"]],
        searching: false,
        scrollX: true,
        ordering: false,
        ajax: abp.libs.datatables.createAjax(qLTV.thuVien.reader.getList),
        columnDefs: [
            {
                render: function (data, type, full, meta) {
                    var table = $('#ReaderTable').DataTable();
                    var info = table.page.info();
                    return info.page * table.page.len() + meta.row + 1;
                },
                className: "text-center p-2",
                width: "5%"
            },

            { data: "nameReader", width: "25%", className: "text-center" },
            { data: "age", width: "5%", className: "text-center" },
            { data: "address", width: "15%", className: "text-center" },
            { data: "phone", width: "10%", className: "text-center" },
            { data: "email", width: "25%", className: "text-center" },
            { data: "idCard", width: "10%", className: "text-center" },
            {
                className: "action_table",
                data: "id", render: function (data) {
                    var htmlRender = '';

                    if (abp.auth.isGranted('QLTV.Reader.Delete')) {
                        htmlRender += '<button title="Xóa" class="btn-action btn-delete" _type="delete" type="button" _id="'
                            + data + '"><i class="fa fa-trash-o"></i> </button>';
                    }
                    return htmlRender;
                },
                width: "5%", className: "text-center p-2"
            },
        ],
        "fnDrawCallback": function (oSettings) {
            if ($('#ReaderTable').DataTable().page.info().pages < 2) {
                $('.dataTable_footer').hide();
            } else {
                $('.dataTable_footer').show();
            }
        }
    }));

    $('#ReaderTable tbody').on('click', 'button', function () {
        var id = $(this).attr("_id");
        if ($(this).attr("_type") === "delete") {
            abp.message.confirm(
                l('MsgDelete'),
                l('MsgDeleteTitle'),
                function (isConfirmed) {
                    if (isConfirmed) {
                        qLTV.thuVien.reader
                            .delete(id)
                            .then(function () {
                                abp.notify.success(l('SuccessfullyDeleted'));
                                dataTable.ajax.reload();
                            });
                    }
                });
        }

    });

    $('#ReaderTable').on('dblclick', 'tbody tr', function () {
        if (abp.auth.isGranted('QLTV.Reader.Update')) {
            var id = dataTable.row(this).data()['id'];
            editModal.open({ id: id });
        }


    });

    createModal.onResult(function () {
        abp.notify.success(l('SuccessfullyCreated'));
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        abp.notify.success(l('SuccessfullyEdited'));
        dataTable.ajax.reload(null, false);
    });

    $('#NewReader').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

    $('#Search').click(function () {
        Search();
    });

    $('#keyword').keypress(function (event) {
        var keycode = (event.keyCode ? event.keyCode : event.which);
        if (keycode == '13') {
            Search();
        }
    });


    function Search() {
        dataTable.destroy();
        var input = {
            'keyword': $("#keyword").val(),
            'SkipCount': 0,
            'MaxResultCount': 10
        }
        dataTable = $('#ReaderTable').DataTable(abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            searching: false,
            scrollX: true,
            ordering: false,
            ajax: abp.libs.datatables.createAjax(qLTV.thuVien.reader.search, function () {
                return input;
            }),
            columnDefs: [
                {
                    render: function (data, type, full, meta) {
                        var table = $('#ReaderTable').DataTable();
                        var info = table.page.info();
                        return info.page * table.page.len() + meta.row + 1;
                    },
                    className: "text-center p-2",
                    width: "5%"
                },
                { data: "nameReader", width: "25%", className: "text-center" },
                { data: "age", width: "5%", className: "text-center" },
                { data: "address", width: "15%", className: "text-center" },
                { data: "phone", width: "10%", className: "text-center" },
                { data: "email", width: "25%", className: "text-center" },
                { data: "idCard", width: "10%", className: "text-center" },
                {
                    className: "action_table",
                    data: "id", render: function (data) {
                        var htmlRender = '';

                        if (abp.auth.isGranted('QLTV.Reader.Delete')) {
                            htmlRender += '<button title="Xóa" class="btn-action btn-delete" _type="delete" type="button" _id="'
                                + data + '"><i class="fa fa-trash-o"></i> </button>';
                        }
                        return htmlRender;
                    },
                    width: "5%", className: "text-center p-2"
                },

            ],
            "fnDrawCallback": function (oSettings) {
                if ($('#ReaderTable').DataTable().page.info().pages < 2) {
                    $('.dataTable_footer').hide();
                } else {
                    $('.dataTable_footer').show();
                }
            }
        }));
    }

    //Check tránh trường hợp nhập khoảng trắng
    $("input").on('change', function () {
        $(this).val($(this).val().trim());
    });

});
