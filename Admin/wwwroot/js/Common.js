var Common = {
    CustAjaxCall: function (someData, method, url, datatype, ssCallBack, errCallback) {
        debugger;
        $.ajax({
            async: false,
            data: someData,
            method: method,
            dataType: datatype,//'json'
            url: url//'/controller/action/'
        }).done(function (data) {
            // If successful
            if (typeof (ssCallBack) === "function")
                ssCallBack(data);
        }).fail(function (jqXHR, textStatus, errorThrown) {
            // If fail
            alert(textStatus + ': ' + errorThrown);
            if (typeof (errCallback) === "function") {
                errCallback();
            }
        });
    },

    ShowNotifyMsg: function (msgType, msgContent) {
        if (msgType != undefined)
            msgType = msgType.toLowerCase();
        let bgClass = "";
        if (msgType === "success")
            bgClass = 'bg-success';
        else if (msgType === "error")
            bgClass = 'bg-danger';
        else if (msgType === "warning")
            bgClass = 'bg-warning';
        else if (msgType === "info")
            bgClass = 'bg-info';

        if (!CommonJs.IsEmpty(bgClass)) {
            $(document).Toasts('create', {
                class: bgClass,
                autohide: true,//res.type === "Success",
                delay: 5000,
                position: 'bottomRight',
                title: "Thông báo",
                body: msgContent
            });
        }
        return false;
    },
}