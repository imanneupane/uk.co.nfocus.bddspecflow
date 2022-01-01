Feature: orderplaced

Checking the order is being placed

@displayorder
Scenario: check thr order number is displayed
	Given I have placed an order
	When I am on my order page
	Then The order number is displayed
