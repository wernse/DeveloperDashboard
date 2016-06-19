//Used to create maps from the requests
//Need it to get colours/names from ids since we dont want to join them into one single list
(function () {
	'use strict';
	angular.module('app')
        .factory('companyFactory', companyFactory);

	function companyFactory() {
	    var companyFactory = {
	        getCompanies: getCompanies,
            setCompanies: setCompanies,
			createCompanyMap: createCompanyMap,
		};

	    return companyFactory;

		function getCompanies() {
		    return this.companies;
		}
		function setCompanies(companies) {
		    this.companies = companies;
		}

        //creates a company map so lists can quickly find the color the company id is
		function createCompanyMap(companyArray) {
            var companyMap = {}
			companyArray.forEach(function (company) {
				companyMap[company.Id] = company.Colour;
			});
			companyFactory.companyMap = companyMap;
			return companyMap;
		}

	}
})();