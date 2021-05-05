Feature: AP_SignIn
	As a registred user of the automation website
	I want to be able to sign in to my account 
	So that i can buy items

@sad_path
Scenario: Invalid password - too short
	Given I am on the sign in page
	And I have entered the email "testing@snailmail.ccm"
	And I have entered the password <password>
	When I click the sign in button
	Then I should see an alert containing the error message "Invalid password"
Examples:
| password |
| four     |
| 1234     |


@sad_path
Scenario: Invalid email address
	Given I am on the sign in page
	And I have entered the email "testingsnailmail.ccm"
	When I click the sign in button
	Then I should see an alert containing the error message "Invalid email address"


@sad_path
Scenario: Empty email address
	Given I am on the sign in page
	And I have entered the password four
	When I click the sign in button
	Then I should see an alert containing the error message "An email address required."


@happy_path
Scenario: Navigate to Sign in page
	Given I am on the home page
	When I click the sign in link
	Then I should be able to navigate to the sign in page

@happy_path
Scenario: Navigate to Forgot password page
	Given I am on the sign in page
	When I click the forgot password link
	Then I should be able to navigate to the Forgot password page
