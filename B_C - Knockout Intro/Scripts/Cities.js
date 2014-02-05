
function Cities() {
    var self = this;
    
    self.allCities = ko.observableArray([]);

    self.allCountries = ko.observableArray([]);

    self.selectedCountry = ko.observable({});
    self.newCityName = ko.observable();

    self.newCity = function () {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/v1/Cities',
            contentType: "application/json",
            data: JSON.stringify({
                Name: self.newCityName(),
                CountryCode: self.selectedCountry().Code
            }), 
            success: function () { }
        });
    };

    self.loadingCities = ko.computed(function () {
        return self.allCities().length == 0;
    });
    self.loadingCountries = ko.computed(function () {
        return self.allCountries().length == 0;
    });

    $.get('/v1/Cities', function (data) {
        self.allCities(data);
    });
    $.get('/v1/Countries', function (data) {
        self.allCountries(data);
    });
}
