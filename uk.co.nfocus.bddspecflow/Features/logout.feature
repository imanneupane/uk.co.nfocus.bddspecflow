Feature: logout

If i am logged in, I should be able to log out  

@tag1
Scenario: Logout of account
	Given  I am logged in to an account
	When I am in my account page
	Then I can log out 

