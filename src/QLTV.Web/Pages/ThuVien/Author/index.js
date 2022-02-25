document.querySelector('.fa-user-edit').nextElementSibling.style.color = 'var(--blue-color)' // css

$(function () {
    var l = abp.localization.getResource('QLTV');

    var createModal = new abp.ModalManager(abp.appPath + 'ThuVien/Author/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'ThuVien/Author/EditModal');

    var dataTable = $('#AuthorTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ordering: false, 
            ajax: abp.libs.datatables.createAjax(qLTV.thuVien.author.getList),
            columnDefs: [
                {
                    render: function (data, type, full, meta) {
                        var table = $('#AuthorTable').DataTable();
                        var info = table.page.info();
                        return info.page * table.page.len() + meta.row + 1;
                    },
                    className: "text-center p-2",
                    width: "5%",
                },
                
                {
                    data: "nameAuthor",
                    width: "15%",
                    className: "text-center",
                },
                {
                    data: "dateOfBirth",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toFormat('dd/MM/yyyy');
                    },
                    className: "text-center",
                    width: "15%"
                },
                {
                    data: "descriptionAuthor",
                    width: "60%"
                },
                
                {
                    className: "action_table",
                    data: "id", render: function (data) {
                        var htmlRender = '';
                        if (abp.auth.isGranted('QLTV.Author.Delete')) {
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
                if ($('#AuthorTable').DataTable().page.info().pages < 2) {
                    $('.dataTable_footer').hide();
                } else {
                    $('.dataTable_footer').show();
                }
            }
        })
    );

    $('#AuthorTable tbody').on('click', 'button', function () {
        var id = $(this).attr("_id");
        if ($(this).attr("_type") === "delete") {
            abp.message.confirm(
                l('MsgDelete'),
                l('MsgDeleteTitle'),
                function (isConfirmed) {
                    if (isConfirmed) {
                        qLTV.thuVien.author
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

    $('#NewAuthor').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

    $('#Search').click(function () {
        Search();
    });

    $('#AuthorTable').on('dblclick', 'tbody tr', function () {
        if (abp.auth.isGranted('QLTV.Author.Update')) {
            var id = dataTable.row(this).data()['id'];
            editModal.open({ id: id });
        }
    });

    function Search() {
        dataTable.destroy();
        var input = {
            'keyword': $("#keysearch").val(),
            'skipCount': 0,
            'maxResultCount': 10
        }
        dataTable = $('#AuthorTable').DataTable(abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ordering: false,
            ajax: abp.libs.datatables.createAjax(qLTV.thuVien.author.search, function () {
                return input;
            }),
            columnDefs: [
                {
                    render: function (data, type, full, meta) {
                        var table = $('#AuthorTable').DataTable();
                        var info = table.page.info();
                        return info.page * table.page.len() + meta.row + 1;
                    },
                    className: "text-center p-2",
                    width: "5%"
                },

                {
                    data: "nameAuthor",
                    width: "15%"
                },
                {
                    data: "dateOfBirth",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toFormat('dd/MM/yyyy');
                    },
                    className: "text-center",
                    width: "15%"
                },
                { data: "descriptionAuthor", width: "60%" },

                {
                    className: "action_table",
                    data: "id", render: function (data) {
                        var htmlRender = '';
                        if (abp.auth.isGranted('QLTV.Author.Delete')) {
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
                if ($('#AuthorTable').DataTable().page.info().pages < 2) {
                    $('.dataTable_footer').hide();
                } else {
                    $('.dataTable_footer').show();
                }
            }
        }));
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