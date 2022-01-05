Feature: Secure access into the website

Successfully logging into a registered account

Scenario: Login with valid username and password
	Given I am on the login page
	When I use a valid <username> and <password>
	Then I am logged in 

Examples: 
| username              | password      |
| imanneupane@yahoo.com | Neupane@12345 |

