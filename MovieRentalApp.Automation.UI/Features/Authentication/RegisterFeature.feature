@registerFeature
Feature: Register
	In order to access the application Cheapflix
	As a new user/administrator
	I should be able to register with valid credentials

@smoke @positive
Scenario: Check Register with valid credentials
	Given I have navigated to the web application
	And I see the application opened
	Then I click Register link
	When I enter the valid details and click Register button
	| UserName      | Password | ConfirmPassword | Email              | Name     | DOB          |
	| leonardo      | password | password        | leonardo@gmail.com | Leonardo | "10/20/1998" |
	Then I should see the register username with welcome