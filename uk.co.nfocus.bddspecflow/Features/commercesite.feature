Feature: commercesite test

The test will login to an e-commerce site as a registered user, purchase an item of clothing, apply a 
discount code and check that the total is correct after the discount & shipping is applied. It will then 
place the order. Once placed it will go into the My Orders section in the users account and check the 
order number is present.

Background: 
Given I am logged in with 'imanneupane@yahoo.com' and 'Neupane@12345'

Scenario Outline: purcahse an item
	When I add an item to the cart
	And I apply the <coupon> discount code 
	Then Coupon takes <discount> off
	When I have purchased an item
	Then Order number displayed is same to my orders

Examples:
| coupon    | discount |
| edgewords | 15       |
	
