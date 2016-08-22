// Ozaj len "nastrel" z .js chcelo by to potom krajsie prepisat do full.ts
var wStoreViewModel = (function () {
    function wStoreViewModel() {
        var _this = this;
        this.storeItemsUri = "/api/storeItems/";
        this.authorsUri = "/api/authors/";
        this.newStoreItem = {
            Author: ko.observable(),
            Title: ko.observable(),
            Description: ko.observable(),
            Created: ko.observable()
        };
        this.addStoreItem = function (formElement) {
            var storeItem = {
                AuthorId: this.newStoreItem.Author().Id,
                Title: this.newStoreItem.Title(),
                Description: this.newStoreItem.Description(),
                Created: this.newStoreItem.Created(),
            };
            var self = this;
            this.ajaxHelper(this.storeItemsUri, 'POST', storeItem).done(function (item) {
                self.storeItems.push(item);
            });
        };
        this.getStoreItemDetail = function (item) {
            var self = _this;
            _this.ajaxHelper(_this.storeItemsUri + item.Id, 'GET').done(function (data) {
                self.detail(data);
            });
        };
        this.deleteStoreItem = function (item) {
            var self = _this;
            _this.ajaxHelper(_this.storeItemsUri + item.Id, 'DELETE').done(function (data) {
                self.getAllStoreItems();
            });
        };
        this.storeItems = ko.observableArray();
        this.error = ko.observable();
        this.detail = ko.observable();
        this.authors = ko.observableArray();
        this.getAllStoreItems();
        this.getAuthors();
    }
    wStoreViewModel.prototype.ajaxHelper = function (uri, method, data) {
        if (data === void 0) { data = null; }
        var self = this;
        this.error('');
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(jqXHR.responseText); //  errorThrown);
        });
    };
    wStoreViewModel.prototype.getAllStoreItems = function () {
        var self = this;
        this.ajaxHelper(this.storeItemsUri, 'GET').done(function (data) {
            self.storeItems(data);
        });
    };
    wStoreViewModel.prototype.getAuthors = function () {
        var self = this;
        this.ajaxHelper(this.authorsUri, 'GET').done(function (data) {
            self.authors(data);
        });
    };
    return wStoreViewModel;
}());
ko.applyBindings(new wStoreViewModel());
//# sourceMappingURL=ts-model.js.map