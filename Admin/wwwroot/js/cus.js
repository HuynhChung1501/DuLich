
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
    let url = "/Menu/Create"
    let form = btn.closest("form");
    let data = Common.GetSerialize(form); //trimspace

    //$(".quickSubmit").prop({ disabled: true });
    //if (form.hasClass("validateForm")) {
    //    let bootstrapValidator = form.data('bootstrapValidator');
    //    if (bootstrapValidator) {
    //        bootstrapValidator.validate();
    //        if (!bootstrapValidator.isValid(true)) {
    //            $(".quickSubmit").prop({ disabled: false });
    //            if (bootstrapValidator.$invalidFields.length > 0)
    //                $(bootstrapValidator.$invalidFields[0]).focus();

    //            return false;
    //        }
    //    }
    //}
    //jQuery(".field-validation-valid").html("");

    //{
    //    Name: $('#Name').val(),
    //    Url: $('#Url').val(),
    //    Icon: $('#Icon').val(),
    //    IDParent: $('#IDParent').val()
    //};

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





function showToast(message, type) {
    toastr.options.positionClass = 'toast-top-right'; // Customize position
    toastr.options.closeButton = true;
    toastr.options.progressBar = true;
    toastr.options.timeOut = 5000;
    toastr.options.extendedTimeOut = 1200;

    toastr[type](message);
}