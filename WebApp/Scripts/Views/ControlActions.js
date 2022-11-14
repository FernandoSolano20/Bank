
function ControlActions() {

    this.URL_API = "https://localhost:44322/api/";

    this.GetUrlApiService = function (service) {
        return this.URL_API + service;
    }

    this.GetTableColumsDataName = function (tableId) {
        var val = $('#' + tableId).attr("ColumnsDataName");

        return val;
    }

    this.FillTable = function (service, tableId, refresh, isCustom, renderCallbacks) {

        if (!refresh) {
            columns = this.GetTableColumsDataName(tableId).split(',');
            var arrayColumnsData = [];


            $.each(columns, function (index, value) {
                var obj = {};
                obj.data = value;
                //Columna + RenderFunction
                if (isCustom && renderCallbacks[value.split(".")[0]]) {
                    obj.render = renderCallbacks[value.split(".")[0]];
                }
                arrayColumnsData.push(obj);
            });
            

            $('#' + tableId).DataTable({
                "processing": true,
                "ajax": {
                    "url": this.GetUrlApiService(service),
                    dataSrc: 'Data'
                },
                "columns": arrayColumnsData
            });
        } else {
            //RECARGA LA TABLA
            $('#' + tableId).DataTable().ajax.reload();
        }

    }

    this.FillTableCustom = function (service, tableId, refresh, callback) {

        if (!refresh) {
            columns = this.GetTableColumsDataName(tableId).split(',');
            var arrayColumnsData = [];


            $.each(columns, function (index, value) {
                var obj = {};
                obj.data = value;
                arrayColumnsData.push(obj);
            });

            $('#' + tableId).DataTable({
                "processing": true,
                "ajax": {
                    "url": this.GetUrlApiService(service),
                    dataSrc: 'Data',
                    "data": callback(data)
                },
                "columns": arrayColumnsData
            });
        } else {
            //RECARGA LA TABLA
            $('#' + tableId).DataTable().ajax.reload();
        }

    }

    this.GetSelectedRow = function () {
        var data = sessionStorage.getItem(tableId + '_selected');

        return data;
    };

    this.BindFields = function (formId, data) {

        $('#' + formId + ' *').filter(':input').each(function (input) {
            var columnDataName = $(this).attr("ColumnDataName");
            var localValue = data;
            var arrayColumn = columnDataName.split(".");

            for (var i = 0; i < arrayColumn.length; i++) {
                localValue = localValue[arrayColumn[i]];
            }
            if (this.type === "date")
                localValue = localValue.substring(0, localValue.indexOf('T'));
            this.value = localValue;
        });
    }

    this.GetDataForm = function (formId) {
        var data = {};

        $('#' + formId + ' *').filter(':input').each(function (input) {
            var columnDataName = $(this).attr("ColumnDataName");
            var localValue = data;
            var arrayColumn = columnDataName.split(".");

            var storeObject = {};
            for (var i = arrayColumn.length - 1; i >= 0; i--) {
                localValue = {};
                localValue[arrayColumn[i]] = {};
                if (arrayColumn.length - 1 === i) {
                    localValue[arrayColumn[i]] = this.value;
                    storeObject = localValue;
                } else {
                    localValue[arrayColumn[i]] = storeObject;
                    storeObject = localValue;
                }
            }

            Object.defineProperty(data, arrayColumn[0], {
                value: storeObject[arrayColumn[0]],
                writable: true,
                enumerable: true,
                configurable: true
            })

        });

        console.log(data);
        return data;
    }

    this.ShowMessage = function (type, message) {
        if (type == 'E') {
            $("#alert_container").removeClass("alert alert-success alert-dismissable")
            $("#alert_container").addClass("alert alert-danger alert-dismissable");
            $("#alert_message").text(message);
        } else if (type == 'I') {
            $("#alert_container").removeClass("alert alert-danger alert-dismissable")
            $("#alert_container").addClass("alert alert-success alert-dismissable");
            $("#alert_message").text(message);
        }
        $('.alert').show();
    };

    this.PostToAPI = function (service, data, successCallback) {
        data = JSON.stringify(data); 
        var jqxhr = $.ajax({
            url: this.GetUrlApiService(service),
            type: "POST",
            data: data,
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        })
            .done(successCallback)
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
                console.log(data);
            })
    };

    this.PutToAPI = function (service, data, successCallback) {
        var jqxhr = $.put(this.GetUrlApiService(service), data, successCallback)
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
                console.log(data);
            })
    };

    this.DeleteToAPI = function (service, data, successCallback) {
        var jqxhr = $.delete(this.GetUrlApiService(service), data, successCallback)
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
                console.log(data);
            })
    };


    this.GetToApi = function (service, callbackFunction) {
        var jqxhr = $.get(this.GetUrlApiService(service), function (response) {
            console.log("Response " + response);
            callbackFunction(response.Data);
        });
    }
}

//Custom jquery actions
$.put = function (url, data, callback) {
    if ($.isFunction(data)) {
        type = type || callback,
            callback = data,
            data = {}
    }
    return $.ajax({
        url: url,
        type: 'PUT',
        success: callback,
        data: JSON.stringify(data),
        contentType: 'application/json'
    });
}

$.delete = function (url, data, callback) {
    if ($.isFunction(data)) {
        type = type || callback,
            callback = data,
            data = {}
    }
    return $.ajax({
        url: url,
        type: 'DELETE',
        success: callback,
        data: JSON.stringify(data),
        contentType: 'application/json'
    });
}
