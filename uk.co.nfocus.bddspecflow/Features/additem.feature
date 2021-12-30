Feature: additem

Adding an item to the cart and view to see if item is added.

@additemtocart
Scenario: Add an item to the cart
	Given I am logged in
	And I am on the shop page
	When I select an item 
	And I add item to the cart
	Then Item is added to the cart
	


