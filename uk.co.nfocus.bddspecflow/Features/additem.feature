Feature: additem

Navigate to the shop page, select an clothing item and add the item to cart

Scenario: Add an item to your cart
	Given I am on Shop page
	When I select an item 
	And I add an item to the cart
	Then Item is in the cart
