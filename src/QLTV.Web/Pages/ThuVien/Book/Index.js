document.querySelector('.fa-book').nextElementSibling.style.color = 'var(--blue-color)' // css

$(function () {
    
    var l = abp.localization.getResource('QLTV');

    
    var createModal = new abp.ModalManager(abp.appPath + 'ThuVien/Book/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'ThuVien/Book/EditModal');

    
        
    var dataTable = $('#BooksTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            searching: false,
            scrollX: true,
            ordering: false,
            ajax: abp.libs.datatables.createAjax(qLTV.thuVien.book.getList),
            columnDefs: [
                
                {
                    title: l('STT'),
                    render: function (data, type, full, meta) {
                        var table = $('#BooksTable').DataTable();
                        var info = table.page.info();
                        return info.page * table.page.len() + meta.row + 1;
                    },
                    className: "text-center p-2",
                    width: "5%"
                },
                {
                    title: l('Name'),
                    data: "nameBook",
                    className: "text-center",
                    width: "18%"
                },
                {
                    title: l('PublishDate'),
                    data: "datePublish",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString();
                    },
                    className: "text-center",
                    width: "12%"
                },
                {
                    title: l('Price'),
                    data: "price",
                    className: "text-center",
                    width: "10%"
                },
                {
                    title: l('NumberBook'),
                    data: "numberBook",
                    className: "text-center",
                    width: "10%"
                },
                {
                    title: l('CategoryBook'),
                    data: "categoryBook",
                    className: "text-center",
                    width: "10%"
                },
                {
                    title: l('AuthorBook'),
                    data: "authorBook",
                    className: "text-center",
                    width: "15%"
                },
                {
                    title: l('BlockBook'),
                    data: "blockBook",
                    className: "text-center",
                    width: "15%"
                },
                {
                    className: "action_table",
                    data: "id", render: function (data) {
                        var htmlRender = '';
                        if (abp.auth.isGranted('QLTV.Book.Delete')) {
                            htmlRender += '<button title="Xóa" class="btn-action btn-delete" _type="delete" type="button" _id="'
                                + data + '"><i class="fa fa-trash-o"></i> </button>';
                        }
                        return htmlRender;
                    },
                    width: "5%",
                    className: "text-center p-2"
                }
            ],
            "fnDrawCallback": function (oSettings) {
                if ($('#BooksTable').DataTable().page.info().pages < 2) {
                    $('.dataTable_footer').hide();
                } else {
                    $('.dataTable_footer').show();
                }
            }
        })
    )
    //---------------------------
    function Search() {
        dataTable.destroy();
        var input = {
            'keyword': $("#keyword").val(),
            'SkipCount': 10,
            'MaxResultCount': 10
        }
        dataTable = $('#BooksTable').DataTable(abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            searching: false,
            scrollX: true,
            ordering: false,
            ajax: abp.libs.datatables.createAjax(qLTV.thuVien.book.search, function () {
                return input;
            }),
            columnDefs: [
                {
                    title: l('STT'),
                    render: function (data, type, full, meta) {
                        var table = $('#BooksTable').DataTable();
                        var info = table.page.info();
                        return info.page * table.page.len() + meta.row + 1;
                    },
                    className: "text-center p-2",
                    width: "5%",
                },
                
                {
                    title: l('Name'),
                    data: "nameBook",
                    className: "text-center",
                    width: "18%",
                },
                {
                    title: l('PublishDate'),
                    data: "datePublish",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString();
                    },
                    className: "text-center",
                    width: "12%",
                },
                {
                    title: l('Price'),
                    data: "price",
                    className: "text-center",
                    width: "10%",
                },
                {
                    title: l('NumberBook'),
                    data: "numberBook",
                    className: "text-center",
                    width: "10%",
                },
                {
                    title: l('CategoryBook'),
                    data: "categoryBook",
                    className: "text-center",
                    width: "10%",
                },
                {
                    title: l('AuthorBook'),
                    data: "authorBook",
                    className: "text-center",
                    width: "15%",
                },
                {
                    title: l('BlockBook'),
                    data: "blockBook",
                    className: "text-center",
                    width: "15%",
                },
                {
                    className: "action_table",
                    data: "id", render: function (data) {
                        
                        var htmlRender = '';
                        if (abp.auth.isGranted('QLTV.Book.Delete')) {
                            htmlRender += '<button title="Xóa" class="btn-action btn-delete" _type="delete" type="button" _id="'
                                + data + '"><i class="fa fa-trash-o"></i> </button>';
                        }
                        return htmlRender;
                    },
                    width: "5%",
                    className: "text-center p-2"
                }
            ],
            "fnDrawCallback": function (oSettings) {
                if ($('#BooksTable').DataTable().page.info().pages < 2) {
                    $('.dataTable_footer').hide();
                } else {
                    $('.dataTable_footer').show();
                }
            }
        })

        )
    };
    //-------------------------
    function AdvancedSearch() {
        dataTable.destroy();
        var input = {
            'keyword': $("#keyword").val(),
            'category':$('#selectCategory').val(),
            'minPrice': $("#hidden_minimum_price").val(),
            'maxPrice': $("#hidden_maximum_price").val(),
            'SkipCount': 10,
            'MaxResultCount': 10
        };
        dataTable = $('#BooksTable').DataTable(abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            searching: false,
            scrollX: true,
            ordering: false,
            ajax: abp.libs.datatables.createAjax(qLTV.thuVien.book.advancedSearch, function () {
                return input;
            }),
            columnDefs: [
                {
                    title: l('STT'),
                    render: function (data, type, full, meta) {
                        var table = $('#BooksTable').DataTable();
                        var info = table.page.info();
                        return info.page * table.page.len() + meta.row + 1;
                    },
                    className: "text-center p-2",
                    width: "5%"
                },

                {
                    title: l('Name'),
                    data: "nameBook",
                    className: "text-center",
                    width: "18%"
                },
                {
                    title: l('PublishDate'),
                    data: "datePublish",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString();
                    },
                    className: "text-center",
                    width: "12%"
                },
                {
                    title: l('Price'),
                    data: "price",
                    className: "text-center",
                    width: "10%"
                },
                {
                    title: l('NumberBook'),
                    data: "numberBook",
                    className: "text-center",
                    width: "10%"
                },
                {
                    title: l('CategoryBook'),
                    data: "categoryBook",
                    className: "text-center",
                    width: "10%"
                },
                {
                    title: l('AuthorBook'),
                    data: "authorBook",
                    className: "text-center",
                    width: "15%"
                },
                {
                    title: l('BlockBook'),
                    data: "blockBook",
                    className: "text-center",
                    width: "15%"
                },
                {
                    className: "action_table",
                    data: "id", render: function (data) {
                        var htmlRender = '';
                        if (abp.auth.isGranted('QLTV.Book.Delete')) {
                            htmlRender += '<button title="Xóa" class="btn-action btn-delete" _type="delete" type="button" _id="'
                                + data + '"><i class="fa fa-trash-o"></i> </button>';
                        }
                        return htmlRender;
                    },
                    width: "5%",
                    className: "text-center p-2"
                }
            ],
            "fnDrawCallback": function (oSettings) {
                if ($('#BooksTable').DataTable().page.info().pages < 2) {
                    $('.dataTable_footer').hide();
                } else {
                    $('.dataTable_footer').show();
                }
            }
        })

        )
    }

    //------------------------
    $('#Search').click(function () {
        //Search();
        AdvancedSearch();
    });
    $('#AdvancedSearch').click(function () {
        AdvancedSearch();
    })
    $('#keyword').keypress(function (event) {
        var keycode = (event.keyCode ? event.keyCode : event.which);
        if (keycode == '13') {
           // Search();
            AdvancedSearch();
        }
    });
    $('#NewBook').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
    createModal.onResult(function () {
        dataTable.ajax.reload();
        //Search();
        abp.notify.success(l('SuccessfullyCreated'));
    });
    editModal.onResult(function () {
        dataTable.ajax.reload();
        abp.notify.success(l('SuccessfullyEdited'));
    });
    $('#BooksTable tbody').on('click', 'button', function () {
        var id = $(this).attr("_id");
        qLTV.thuVien.book.changeNumberBookForDelete(id);
        if ($(this).attr("_type") === "delete") {
            abp.message.confirm(
                l('MsgDelete'),
                l('MsgDeleteTitle'),
                function (isConfirmed) {
                    if (isConfirmed) {
                        qLTV.thuVien.book
                            .delete(id)
                            .then(function () {
                                abp.notify.success(l('SuccessfullyDeleted'));
                                dataTable.ajax.reload();
                            });
                    }
                });
        }

    });
    $('#BooksTable').on('dblclick', 'tbody tr', function () {
        if (abp.auth.isGranted('QLTV.Book.Update'))
        {
            var id = dataTable.row(this).data()['id'];
            editModal.open({ id: id });
        }
        
        
    });
    $('#selectCategory').on('change', function () {
        //alert(this.value);
        AdvancedSearch();
    });
    //-----------------------------
    var sLider = $('#price_range').slider({
        range: true,
        min: 0,
        max: 500000,
        values: [0, 500000],
        step: 50000,
        stop: function (event, ui)
        {
            
            $('#price_show').html(ui.values[0] / 1000 + '&nbsp; K &emsp; &emsp; &emsp; &emsp; &emsp; &emsp; &emsp; &emsp; &emsp; &emsp; &emsp; &emsp;' + ui.values[1] / 1000 + "&nbsp;K");
            $('#hidden_minimum_price').val(ui.values[0]);
            $('#hidden_maximum_price').val(ui.values[1]);
            
            AdvancedSearch();
            
        }
    });

    //-------------------------------

    

});
//--------------------------------------
document.querySelector('#selectCategory option').innerText = "" // FirstOption is ""