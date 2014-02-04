
function Cities() {
    var self = this;
    
    self.allCities = ko.observableArray([]);

    self.loading = ko.computed(function () {
        return self.allCities().length == 0;
    });

    $.get('/v1/Cities', function (data) {
        self.allCities(data);
    });
}
