function vExchangeRate() {

    this.tblExchangeRateId = 'tblExchangeRate';
    this.service = 'exchangeRate';
    this.ctrlActions = new ControlActions();
    this.columns = "OriginCountry,DestinationCountry,Value,Day";

    this.RetrieveAll = function () {
        var objs = {};

        objs.Day = function (data) {
            return data.substring(0, data.indexOf('T'));
        }

        objs.OriginCountry = function (data) {
            return data + " Hola";
        }

        this.ctrlActions.FillTable(this.service, this.tblExchangeRateId, false, true, objs);
    }

    this.RetrieveAllCountries = function (select) {
        this.ctrlActions.GetToApi("country", function (response) {
            var option = document.createElement("option");
            option.innerText = "Eliga una opción";
            select.appendChild(option);
            response.forEach(x => {
                var option = document.createElement("option");
                option.value = x.Value;
                option.innerText = x.Value;
                select.appendChild(option);
            });
        });

    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblExchangeRateId, true);
    }

    this.Create = function () {
        var customerData = {};
        customerData = this.ctrlActions.GetDataForm('frmEdition');
        customerData.OriginCountry.Value = btoa(unescape(encodeURIComponent(customerData.OriginCountry.Value)));
        customerData.DestinationCountry.Value = btoa(unescape(encodeURIComponent(customerData.DestinationCountry.Value)));
        delete customerData.Id;
        //Hace el post al create
        this.ctrlActions.PostToAPI(this.service, customerData, function (response) {
            var ctrlActions = new ControlActions();
            ctrlActions.ShowMessage('I', response.Message);
            var self = new vExchangeRate();
            ctrlActions.FillTable(self.service, self.tblExchangeRateId, true);
        });
        //Refresca la tabla
        this.ReloadTable();
    }

    this.Update = function () {

        var customerData = {};
        customerData = this.ctrlActions.GetDataForm('frmEdition');
        customerData.OriginCountry.Value = btoa(unescape(encodeURIComponent(customerData.OriginCountry.Value)));
        customerData.DestinationCountry.Value = btoa(unescape(encodeURIComponent(customerData.DestinationCountry.Value)));
        //Hace el post al create
        this.ctrlActions.PutToAPI(this.service, customerData, function (response) {
            var ctrlActions = new ControlActions();
            ctrlActions.ShowMessage('I', response.Message);
            var self = new vExchangeRate();
            ctrlActions.FillTable(self.service, self.tblExchangeRateId, true);
        });
        //Refresca la tabla
        

    }

    this.Delete = function () {

        var customerData = {};
        customerData = this.ctrlActions.GetDataForm('frmEdition');
        customerData.OriginCountry.Value = btoa(unescape(encodeURIComponent(customerData.OriginCountry.Value)));
        customerData.DestinationCountry.Value = btoa(unescape(encodeURIComponent(customerData.DestinationCountry.Value)));
        //Hace el post al create
        this.ctrlActions.DeleteToAPI(this.service, customerData, function (response) {
            var ctrlActions = new ControlActions();
            ctrlActions.ShowMessage('I', response.Message);
            var self = new vExchangeRate();
            ctrlActions.FillTable(self.service, self.tblExchangeRateId, true);
        });
        //Refresca la tabla
        this.ReloadTable();

    }

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmEdition', data);
    }
}

//ON DOCUMENT READY
$(document).ready(function () {

    var vcustomer = new vExchangeRate();
    vcustomer.RetrieveAll();
    vcustomer.RetrieveAllCountries(document.getElementById("drpOriginCountry"));
    vcustomer.RetrieveAllCountries(document.getElementById("drpDestinationCountry"));
});