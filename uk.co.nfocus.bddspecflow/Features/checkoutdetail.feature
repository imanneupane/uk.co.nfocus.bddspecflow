Feature: checkoutdetail

Entering the shipping details after proceeding to the checkout after adding item to the cart and appling discount

@checkoutdetails
Scenario: Entering the billing details
	Given I have proceeded to checkout
	And I am on the billing information page
	When I enter my shipping details 
	Then I can place my order
