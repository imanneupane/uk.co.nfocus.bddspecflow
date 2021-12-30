Feature: checkout

This feature consist of multiple scenario during the checkout process

@additemtocart
Scenario: Add an item to the cart
	Given I am logged in
	And I am on the shop page
	When I select an item 
	And I add item to the cart
	Then Item is added to the cart
	
@applycoupon
Scenario: Apply coupon at checkout
	Given I am on the checkout page
	When I enter the coupon code
	Then Discount is applied to the total

@checkdiscount
Scenario: Discount applied
	Given I applied the coupon code 
	When discount is applied
	Then coupon takes off 15% off

@checkoutdetails
Scenario: Entering the billing details
	Given I am on the billing information page
	When I enter the coupon code
	Then Discount is applied to the total

@displayorder
Scenario: check thr order number is displayed
	Given I have placed an order
	When I am on my order page
	Then The order number is displayed
