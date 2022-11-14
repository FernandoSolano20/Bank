function vConversion() {

    this.service = 'exchangeRate';
    this.ctrlActions = new ControlActions();

    this.RetrieveOptionDropDown = function (url, select, accessData, callback) {
        this.ctrlActions.GetToApi(url, function (response) {
            select.innerHTML = ""
            var option = document.createElement("option");
            option.innerText = "Eliga una opción";
            select.appendChild(option);
            callback(response).forEach(x => {
                var option = document.createElement("option");
                var data = accessData(x);
                option.value = data;
                option.innerText = data;
                select.appendChild(option);
            });
        });
    }

    this.Conversion = function() {
        var valueDest = btoa(unescape(encodeURIComponent(document.getElementById("drpDestinationCountry").value)));
        var valueOrig = btoa(unescape(encodeURIComponent(document.getElementById("drpOriginCountry").value)));
        var valueToConvert = document.getElementById("txtMoney");
        var drpDate = document.getElementById("drpDate");

        this.ctrlActions.GetToApi(this.service + "?dateRequest=" + drpDate.value
            + "&originCountry=" + encodeURIComponent(valueOrig)
            + "&destCountry=" + encodeURIComponent(valueDest)
            + "&value=" + valueToConvert.value, function (response) {
                alert("El tipo de cambio es dia es de " + response.Value);
                alert("El tipo de cambio es de " + response.Value * valueToConvert.value);
            
        });
    }
}


//ON DOCUMENT READY
$(document).ready(function () {
    
    var vcustomer = new vConversion();
    var originCountryDrp = document.getElementById("drpOriginCountry");
    var destCountryDrp = document.getElementById("drpDestinationCountry");
    var drpDate = document.getElementById("drpDate");

    vcustomer.RetrieveOptionDropDown(vcustomer.service, originCountryDrp, function(data) {
        return data.OriginCountry.Value;
    },
        function getUnique(arr) {

            var unique = arr
                .map(e => e.OriginCountry.Value)

                // store the keys of the unique objects
                .map((e, i, final) => final.indexOf(e) === i && i)

                // eliminate the dead keys & store unique objects
                .filter(e => arr[e]).map(e => arr[e]);

            return unique;
        });

    originCountryDrp.addEventListener("change", function() {
        var value = btoa(unescape(encodeURIComponent(this.value)));
        vcustomer.RetrieveOptionDropDown(vcustomer.service + "?originCountry=" + encodeURIComponent(value), destCountryDrp, function (data) {
            return data.DestinationCountry.Value;
        },
            function getUnique(arr) {

                var unique = arr
                    .map(e => e.DestinationCountry.Value)

                    // store the keys of the unique objects
                    .map((e, i, final) => final.indexOf(e) === i && i)

                    // eliminate the dead keys & store unique objects
                    .filter(e => arr[e]).map(e => arr[e]);

                return unique;
            });
    });

    destCountryDrp.addEventListener("change", function () {
        var valueDest = btoa(unescape(encodeURIComponent(this.value)));
        var valueOrig = btoa(unescape(encodeURIComponent(document.getElementById("drpOriginCountry").value)));
        vcustomer.RetrieveOptionDropDown(vcustomer.service + "?originCountry=" + encodeURIComponent(valueOrig)
            + "&destCountry=" + encodeURIComponent(valueDest), drpDate, function (data) {
                return data.Day;
        },
            function getUnique(arr) {

                var unique = arr
                    .map(e => e.Day)

                    // store the keys of the unique objects
                    .map((e, i, final) => final.indexOf(e) === i && i)

                    // eliminate the dead keys & store unique objects
                    .filter(e => arr[e]).map(e => arr[e]);

                return unique;
            });
    });
});

