$(function () {

    var l = abp.localization.getResource('QLTV');

    var service = qLTV.thuVien.example;
    var createModal = new abp.ModalManager(abp.appPath + 'ThuVien/Example/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'ThuVien/Example/EditModal');

    var dataTable = $('#ExampleTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Edit'),
                                visible: abp.auth.isGranted('QLTV.Example.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('QLTV.Example.Delete'),
                                confirmMessage: function (data) {
                                    return l('ExampleDeletionConfirmationMessage', data.record.id);
                                },
                                action: function (data) {
                                    service.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l('SuccessfullyDeleted'));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
            {
                title: l('ExampleName'),
                data: "name"
            },
            {
                title: l('ExampleGhiChu'),
                data: "ghiChu"
            },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewExampleButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
