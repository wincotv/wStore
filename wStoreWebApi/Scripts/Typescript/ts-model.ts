// Ozaj len "nastrel" z .js chcelo by to potom krajsie prepisat do full.ts

class wStoreViewModel {
    public storeItems: KnockoutObservableArray<{}>
    public error: KnockoutObservable<{}>
    public detail: KnockoutObservable<{}>
    public authors: KnockoutObservableArray<{}>

    storeItemsUri: string = "/api/storeItems/";
    authorsUri: string = "/api/authors/";

    newStoreItem = {
        Author: ko.observable(),
        Title: ko.observable(),
        Description: ko.observable(),
        Created: ko.observable()
    }

    addStoreItem = function (formElement) {
        var storeItem = {
            AuthorId: this.newStoreItem.Author().Id,
            Title: this.newStoreItem.Title(),
            Description: this.newStoreItem.Description(),
            Created: this.newStoreItem.Created(),
        };
        var self = this;

        this.ajaxHelper(
   
            this.storeItemsUri, 'POST', storeItem).done(
               function (item) {
                self.storeItems.push(item);
                });
    }
    

    constructor() {
        this.storeItems = ko.observableArray();
        this.error = ko.observable();
        this.detail = ko.observable();
        this.authors = ko.observableArray();
        this.getAllStoreItems();
        this.getAuthors();
    }


    ajaxHelper(uri, method, data = null) {
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
    }


    getAllStoreItems() {
        var self = this;
        this.ajaxHelper(this.storeItemsUri, 'GET').done(function (data) {
           self.storeItems(data);
        });
    }

    getStoreItemDetail = (item) => {
        var self = this;
        this.ajaxHelper(this.storeItemsUri + item.Id, 'GET').done(function (data) {
            self.detail(data);
        });
    }

    getAuthors() {
        var self = this;
        this.ajaxHelper(this.authorsUri, 'GET').done(function (data) {
            self.authors(data);
        });
    }

    deleteStoreItem = (item) => {
        var self = this;
        this.ajaxHelper(this.storeItemsUri + item.Id, 'DELETE').done(function (data) {
            self.getAllStoreItems();
        });
    }
}


ko.applyBindings(new wStoreViewModel());

