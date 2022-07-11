Feature: IncorrectLogin

@tag1
Scenario: Verify incorrect password
	Given I go to login page of Report Portal
	And I enter value strstr in Login field
	And I enter value 10 in Password field
	When I click button Login
	Then Error message are appeared
