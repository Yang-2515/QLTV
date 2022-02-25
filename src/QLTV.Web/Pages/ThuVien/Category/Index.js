document.querySelector('.fa-th').nextElementSibling.style.color = 'var(--blue-color)' // css

$(function () {
    var l = abp.localization.getResource('QLTV');

    var createModal = new abp.ModalManager(abp.appPath + 'ThuVien/Category/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'ThuVien/Category/EditModal');

    var dataTable = $('#CategoriesTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        serverSide: true,
        paging: true,
        searching: false,
        scrollX: true,
        ordering: false,
        ajax: abp.libs.datatables.createAjax(qLTV.thuVien.category.getList),
        columnDefs: [
            {
                render: function (data, type, full, meta) {
                    var table = $('#CategoriesTable').DataTable();
                    var info = table.page.info();
                    return info.page * table.page.len() + meta.row + 1;
                },
                className: "text-center p-2",
                width: "5%"
            },
            {
                data: "nameCategory",
                width: "20%",
                className: "text-center"
            },
            {
                data: "descriptionCategory",
                width: "70%",
            },
            {
                className: "action_table",
                data: "id", render: function (data) {
                    var htmlRender = '';
                    if (abp.auth.isGranted('QLTV.Category.Delete')) {
                        htmlRender += '<button title="Xóa" class="btn-action btn-delete" _type="delete" type="button" _id="'
                            + data + '"><i class="fa fa-trash-o"></i> </button>';
                    }
                    return htmlRender;
                },
                width: "5%",
                className: "text-center p-2"
            },
        ],
        "fnDrawCallback": function (oSettings) {
            if ($('#CategoriesTable').DataTable().page.info().pages < 2) {
                $('.dataTable_footer').hide();
            } else {
                $('.dataTable_footer').show();
            }
        }
    }));

    $('#CategoriesTable tbody').on('click', 'button', function () {
        var id = $(this).attr("_id");
        if ($(this).attr("_type") === "delete") {
            abp.message.confirm(
                l('MsgDelete'),
                l('MsgDeleteTitle'),
                function (isConfirmed) {
                    if (isConfirmed) {
                        qLTV.thuVien.category
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

    $('#NewCategory').click(function (e) {
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
        dataTable = $('#CategoriesTable').DataTable(abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            searching: false,
            scrollX: true,
            ordering: false,
            ajax: abp.libs.datatables.createAjax(qLTV.thuVien.category.search, function () {
                return input;
            }),
            columnDefs: [
                {
                    render: function (data, type, full, meta) {
                        var table = $('#CategoriesTable').DataTable();
                        var info = table.page.info();
                        return info.page * table.page.len() + meta.row + 1;
                    },
                    className: "text-center p-2",
                    width: "5%",
                },
                {
                    data: "nameCategory",
                    width: "20%",
                    className: "text-center"
                },
                {
                    data: "descriptionCategory",
                    width: "60%",
                },
                {
                    className: "action_table",
                    data: "id", render: function (data) {
                        var htmlRender = '';
                        if (abp.auth.isGranted('QLTV.Category.Delete')) {
                            htmlRender += '<button title="Xóa" class="btn-action btn-delete" _type="delete" type="button" _id="'
                                + data + '"><i class="fa fa-trash-o"></i> </button>';
                        }
                        return htmlRender;
                    },
                    width: "10%",
                    className: "text-center p-2"
                },

            ],
            "fnDrawCallback": function (oSettings) {
                if ($('#CategoriesTable').DataTable().page.info().pages < 2) {
                    $('.dataTable_footer').hide();
                } else {
                    $('.dataTable_footer').show();
                }
            }
        }));
    }
    $('#CategoriesTable').on('dblclick', 'tbody tr', function () {
        if (abp.auth.isGranted('QLTV.Category.Update')) {
            var id = dataTable.row(this).data()['id'];
            editModal.open({ id: id });
        }


    });
    //Check tránh trường hợp nhập khoảng trắng
    $("input").on('change', function () {
        $(this).val($(this).val().trim());
    });
});