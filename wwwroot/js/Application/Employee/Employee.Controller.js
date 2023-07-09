
var EmployeeController = function (prop) {
    var self = this;

    const baseUrl = "/api/EmployeeAPI"
    self.Employees = ko.observableArray([]);

    self.SelectedEmployee = ko.observable(new EmployeeModel());
    self.NewEmployee = ko.observable(new EmployeeModel());
    self.mode = ko.observable(mode.create);
    self.IsUpdated = ko.observable(false);
   // self.IsPageFirst = ko.observable(false);
    self.skipCount = ko.observable(0);
    self.take = ko.observable(5);
    self.searchTerm = ko.observable("");
    console.log(this.searchTerm);
    self.Branchs = ko.observableArray(["Kathmandu", "Baglung", "Lalitpur", "Bhaktapur"]);

    var departmentController = new DepartmentController();
    // Assign the departments from DepartmentController to the EmployeeController
    self.departments = departmentController.departments;

    self.getData = function () {
        ajax.get(baseUrl + "?skipCount=" + ko.toJS(self.skipCount()) + "&take=" + ko.toJS(self.take())+ "&search=" + ko.toJS(self.searchTerm())).then(function (result) {
            self.Employees(result);
            var datas = ko.utils.arrayMap(result, function (item) {
                return new EmployeeModel(item);
            })
        });
    }
 
    self.getData();

    //Post
    self.AddEmployee = function () {
        switch (self.mode()) {
            case 1:
                console.log(ko.toJSON(self.NewEmployee()));
                ajax.post(baseUrl, ko.toJSON(self.NewEmployee()))
                    .done(
                        (result) => {
                            self.Employees.push(new EmployeeModel(result));
                            self.resetForm();
                        }).fail((err) => {
                            console.log(err);
                        });
                break;
            default:
                ajax.put(baseUrl + "/" + self.NewEmployee().id(), ko.toJSON(self.NewEmployee())).done(
                    (result) => {
                        self.Employees.replace(self.SelectedEmployee(), self.NewEmployee());
                        self.resetForm();
                    });
                break;
        }
    }
    self.DeleteEmployee = function (model) {
        ajax.delete(baseUrl + "/" + ko.toJS(model).id)
            .done((result) => {
                self.Employees.remove(model);
            });
    }
    self.resetForm = () => {
        self.NewEmployee(new EmployeeModel());
        self.SelectedEmployee(new EmployeeModel());
        self.mode(mode.create);
        self.IsUpdated(false);
    }
    self.SelectEmployee = (model) => {
        self.SelectedEmployee(model);
        console.log(model);
        self.NewEmployee(new EmployeeModel(ko.toJS(model)));
        self.IsUpdated(true);
        self.mode(mode.update);
    }
    self.PreviousData = function () {
       
        self.skipCount(self.skipCount() - 5);
        self.getData()
        
    }
    self.ClosedModel = function () {
        self.resetForm();
    }
    self.NextData = function () {
        //self.skipCount(self.skipCount() + 1);
        self.skipCount(self.skipCount() + 5);
        console.log(self.skipCount());
        var employeelength = self.Employees().length + 5;
        self.getData()
    }

    self.clickedSearch = function () {

        self.searchTerm(self.searchTerm());
        self.getData();
    }
    //self.Searched = function () {
    //    self.searchTerm(self.searchTerm());
    //    self.getData()
    //}
}

    var ajax = {
        get: function (url) {
            return $.ajax({
                method: "GET",
                url: url,
                async:false,

            });
        },
        post: function (url, data) {

            return $.ajax({
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                method: "POST",
                url: url,
                data: (data)
            });
        },
        put: function (url, data) {
            return $.ajax({
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                method: "PUT",
                url: url,
                data: data
            });
        },

        //put: function (url, data) {
        //    return $.ajax({
        //        headers: {
        //            'Accept': 'application/json',
        //            'Content-Type': 'application/json'
        //        },
        //        method: "PUT",
        //        url: url,
        //        data: data
        //    });
        //},
        delete: function (route) {
            return $.ajax({
                method: "DELETE",
                url: route,
           });

        }
}

    const mode = {
        create: 1,
        update: 2
    };