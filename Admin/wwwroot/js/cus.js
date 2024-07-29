
$(".quickSubmit").click(function () {
    debugger
    $.ajax({
        type: 'POST',
        url: "/menu/create", success: function (result) {
            
            showToast(result.message, result.status)
        }
    });
    return false;
        /*showToast("ạdkbcjká", "success")*/
});
function showToast(message, type) {
    toastr.options.positionClass = 'toast-top-right'; // Customize position
    toastr.options.closeButton = true;
    toastr.options.progressBar = true;
    toastr.options.timeOut = 50000;
    toastr.options.extendedTimeOut = 12000;

    toastr[type](message);
}