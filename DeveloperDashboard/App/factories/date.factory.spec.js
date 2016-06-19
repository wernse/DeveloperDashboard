'use strict';

describe('Factory: dateFactory', function () {

	var dateFactory;

	beforeEach(function () {

		module('date');

		inject(function (_dateFactory_) {
			dateFactory = _dateFactory_;
		});
	});

	// Specs here
	it('should return correct monday and sunday dates', function () {
	    var d = new Date("2016-05-05");

	    var dateRange = dateFactory.getDateRange(d);
	    var expectedRange = ['2016-05-02', '2016-05-03', '2016-05-04', '2016-05-05', '2016-05-06', '2016-05-07', '2016-05-08'];
	    expect(dateRange).toEqual(expectedRange)
	});

	it('should return correct monday and sunday dates for start edge dates', function () {
	    var d = new Date("2016-06-01");

	    var dateRange = dateFactory.getDateRange(d);
	    var expectedRange = ['2016-05-30', '2016-05-31', '2016-06-01', '2016-06-02', '2016-06-03', '2016-06-04', '2016-06-05'];
	    expect(dateRange).toEqual(expectedRange)
	});

	it('should return correct monday and sunday dates for end edge dates', function () {
	    var d = new Date("2016-06-30");

	    var dateRange = dateFactory.getDateRange(d);
	    var expectedRange = ['2016-06-27', '2016-06-28', '2016-06-29', '2016-06-30', '2016-07-01', '2016-07-02', '2016-07-03'];
	    expect(dateRange).toEqual(expectedRange)
	});
});