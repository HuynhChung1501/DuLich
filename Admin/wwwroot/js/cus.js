
$(".quickSubmit").click(function () {
    let obj = $(this);
    let form = obj.closest("form")
    var url = form.attr("action") || form.attr("href")

    $.ajax({
        type: 'POST',
        url: url, success: function (result) {
            
            showToast(result.message, result.status)
        }
    });
    return false;
});

jQuery(document).on("click", ".quickUpdate", function () {
    let btn = $(this);
    let form = btn.closest("form");
    let url = form.attr("action")
    let data = Common.GetSerialize(form); //trimspace

    $.ajax({
        url: url,
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(data),
        success: function (response) {
            showToast(response.message, response.status)
        },
        error: function (xhr, status, error) {
        }
    });
    return false;
});
jQuery(document).on("click", ".quickDelete", function () {
    let btn = $(this);
    let url = btn.attr("href") || btn.attr("data-href");
    let id = btn.attr("data-id")
    
    $.ajax({
        url: url,
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(id),
        success: function (response) {
            showToast(response.message, response.status)
        },
        error: function (xhr, status, error) {
        }
    });
    return false;
}),

jQuery(document).on("click", ".quickDeletes", function () {
    let btn = $(this);
    let url = btn.attr("href") || btn.attr("data-href");
    let lstCheckBoxItem = $("table .onCheckItem")
    var ids = [];
    lstCheckBoxItem.each(function(index, element) {
        if($(element).is(':checked')) {
            ids.push($(element).attr("id"))
        }
    });
    
    
    $.ajax({
        url: url,
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(ids),
        success: function (response) {
            showToast(response.message, response.status)
        },
        error: function (xhr, status, error) {
        }
    });
    return false;
}),

jQuery(document).on("change", ".onCheckGroup", function () {
    let obj = $(this);
    let table = obj.closest("table")
    let checkAll = obj.is(":checked")
    let lstCheckBoxItem = table.find(".onCheckItem")
    if(checkAll) {
        lstCheckBoxItem.each(function(index, element) {
            if(!$(element).is(':checked')) {
                $(element).prop("checked", true)
            }else {
                return true;
            }
        });
    }else {
        lstCheckBoxItem.each(function(index, element) {
            if($(element).is(':checked')) {
                $(element).prop("checked", false)
            }else {
                return true;
            }
        });
    }
}),

jQuery(document).on("change", ".onCheckItem", function () { 
    let obj = $(this);
    let table = obj.closest("table")
    let checkAll = table.find(".onCheckGroup")
    let lstCheckBoxItem = table.find(".onCheckItem")
    let countCheck = 0;
    let length = lstCheckBoxItem.length
    lstCheckBoxItem.each(function(index, element) {
        if(!$(element).prop('checked')) {
            checkAll.prop("checked", false)
            return false;
        }else {
            countCheck ++
        }
    });
    if(countCheck == length) {
        checkAll.prop("checked", true)
    }

}),


jQuery.fn.extend({
    reset: function () {
        try {
            this.each(function () {
                this.reset();
            });
            jQuery(jQuery(this).attr("data-html-reset")).html("");
        } catch (e) {
        }
        jQuery(this).find(".isNew").remove();
    },
    getData: function () {
        let data = {};
        try {
            this.each(function () {
                jQuery.each(this.attributes, function () {
                    let name = this.name.toLowerCase();
                    if (name.indexOf("data-") === 0) {
                        let k = "";
                        let args = name.split("-");
                        for (let n = 0; n < args.length; n++) {
                            if (n == 0) continue;
                            if (n == 1) {
                                k += args[n];
                            }
                            else {
                                k += args[n].capitalize()
                            }
                        }
                        data[k] = this.value;
                    }
                });
            });
        } catch (e) {
        }
        return data;
    },
    getDataUppername: function () {
        let data = {};
        try {
            this.each(function () {
                jQuery.each(this.attributes, function () {
                    let name = this.name.toLowerCase();
                    if (name.indexOf("data-") === 0) {
                        let k = "";
                        let args = name.split("-");
                        for (let n = 0; n < args.length; n++) {
                            if (n == 0) continue;
                            let v = args[n];
                            if (v == "id") {
                                k += v.toUpperCase();
                            }
                            else {
                                k += v.capitalize()
                            }
                        }
                        data[k] = this.value;
                    }
                });
            });
        } catch (e) {
        }
        return data;
    },
    replaceAll: function (str, find, replace) {
        return str.replace(new RegExp(find, 'g'), replace);
    }

});

function showToast(message, type, onLoad = true) {
    toastr.options.positionClass = 'toast-bottom-right'; // Customize position
    toastr.options.closeButton = true;
    toastr.options.progressBar = true;
    toastr.options.timeOut = 2000;
    toastr.options.extendedTimeOut = 2000;
    toastr[type](message);
    if (onLoad) {
    setTimeout(function () {
        window.location.reload();
    }, 2000);
    }
}