/// <reference path="../../knockout.js" />


var EmployeeModel = function (item) {
    var self = this;
    item = item || {};
    self.id = ko.observable(item.id || 0);
    self.fullname = ko.observable(item.fullname || "");
    self.gender = ko.observable(item.gender || "");
    self.hireddate = ko.observable(item.hireddate || "");
    self.address = ko.observable(item.address || "");
    self.branch = ko.observable(item.branch || "");
    self.salary = ko.observable(item.salary || ""); 
    self.departmentId = ko.observable(item.departmentId || 0); 
}