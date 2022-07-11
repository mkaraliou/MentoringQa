Feature: IncorrectLogin

@tag1
Scenario: Verify incorrect password
	Given I go to login page of Report Portal
	And I enter login 'login'
	And I enter password 'password'
	When I click button Login
	Then Error message are appeared
