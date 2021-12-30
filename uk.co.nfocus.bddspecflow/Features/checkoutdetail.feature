Feature: checkoutdetail

A short summary of the feature

@checkoutdetails
Scenario: Entering the billing details
	Given I am on the billing information page
	When I enter the coupon code
	Then Discount is applied to the total
