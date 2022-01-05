Feature: applycoupon

Discount is applied to the item when coupon is applied.

@applycoupon
Scenario: Apply coupon at checkout
	Given I have added an item to cart
	And I am on the Cart page
	When I enter the coupon code
	Then Discount is applied

@checkdiscount
Scenario: Discount applied
	Given I applied the coupon code 
	When Coupon takes off <discount>
	Then <discount> Discount is deducted from total

Examples: 
| discount |
| 15       |
