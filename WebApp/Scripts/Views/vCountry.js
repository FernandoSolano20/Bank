function vCountry() {

    this.tblCountryId = 'tblCountry';
    this.service = 'country';
    this.ctrlActions = new ControlActions();
    this.columns = "Value";

    this.RetrieveAll = function () {
        var functionCallback = {};

        this.ctrlActions.FillTable(this.service, this.tblCountryId, false, false);
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblCountryId, true);
    }

    this.Create = function () {
        var customerData = {};
        customerData = this.ctrlActions.GetDataForm('frmEdition');
        customerData.Value = btoa(unescape(encodeURIComponent(customerData.Value)));
        //Hace el post al create
        this.ctrlActions.PostToAPI(this.service, customerData, function (response) {
            var ctrlActions = new ControlActions();
            ctrlActions.ShowMessage('I', response.Message);
            var self = new vCountry();
            ctrlActions.FillTable(self.service, self.tblCountryId, true);
        });
        //Refresca la tabla
        this.ReloadTable();
    }

    this.Update = function () {

        var customerData = {};
        customerData = this.ctrlActions.GetDataForm('frmEdition');
        customerData.Value = btoa(unescape(encodeURIComponent(customerData.Value)));
        this.ctrlActions.PutToAPI(this.service, customerData, function (response) {
            var ctrlActions = new ControlActions();
            ctrlActions.ShowMessage('I', response.Message);
            var self = new vCountry();
            ctrlActions.FillTable(self.service, self.tblExchangeRateId, true);
        });
        //Refresca la tabla


    }

    this.Delete = function () {

        var customerData = {};
        customerData = this.ctrlActions.GetDataForm('frmEdition');
        customerData.Value = btoa(unescape(encodeURIComponent(customerData.Value)));
        //Hace el post al create
        this.ctrlActions.DeleteToAPI(this.service, customerData, function (response) {
            var ctrlActions = new ControlActions();
            ctrlActions.ShowMessage('I', response.Message);
            var self = new vCountry();
            ctrlActions.FillTable(self.service, self.tblCountryId, true);
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

    var vcustomer = new vCountry();
    vcustomer.RetrieveAll();
});