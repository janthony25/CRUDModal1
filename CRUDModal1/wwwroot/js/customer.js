$(document).ready(function () {
    GetCustomers();
});

// Populate customer table
function GetCustomers() {
    $.ajax({
        url: '/customer/GetCustomers',
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8',
        success: function (response) {
            let tableRows = '';

            if (response == null || response == undefined || response.length == 0) {
                tableRows = `
                    <tr>
                        <td class="text-center" colspan="5">Customers not available</td>
                    </tr>`;
            }
            else {
                // loop through customers
                $.each(response, function (index, item) {
                    const dateAdded = new Date(item.dateAdded).toLocaleDateString();

                    tableRows += `
                        <tr>
                            <td>${item.customerId}</td>
                            <td>${item.customerName}</td>
                            <td>${item.customerEmail}</td>
                            <td>${item.customerNumber}</td>
                            <td>${dateAdded}</td>
                            <td>
                                <a href="#" class="btn btn-primary btn-sm" onclick=Edit(${item.customerId}) >Edit</a>
                                <a href="#" class="btn btn-danger btn-sm" onclick=Delete(${item.customerId}) >Delete</a>
                            </td>
                        </tr>`;
                });
                $('#tblBody').html(tableRows);
            }
        },
        error: function () {
            alert('Unable to read data');
        }
    });
}

$('#addBtn').click(function () {
    $('#ProductModal').modal('show');
    $('#modalTitle').text('Add Customer');
});

// Add Customer
function Insert() {
    var formData = new Object();
    formData.customerId = $('#CustomerId').val();
    formData.customerName = $('#CustomerName').val();
    formData.customerEmail = $('#CustomerEmail').val();
    formData.customerNumber = $('#CustomerNumber').val();
    formData.dateAdded = $('#DateAdded').val();

    $.ajax({
        url: '/customer/Insert',
        data: formData,
        type: 'post',
        success: function (response) {
            if (response == null || response == undefined || response.length == 0) {
                alert('Unable to save customer');
            }
            else {
                GetCustomers();
                alert(response);
            }
        },
        error: function () {
            alert('Unable to save customer');
        }
    });
}