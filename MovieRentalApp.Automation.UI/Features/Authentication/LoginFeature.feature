@loginFeature
Feature: Login
	In order to access the application Cheapflix
	As an user/administrator
	I should be able to login with valid credentials

@smoke @positive
Scenario: Check Login with correct username and password
	Given I have navigated to the web application
	And I see the application opened
	Then I click Sign In link
	When I enter UserName and Password and click login button
	| UserName | Password |
	| john     | password |
	Then I should see the login username with welcome
