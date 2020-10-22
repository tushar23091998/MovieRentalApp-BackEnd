@userEdit
Feature: UserEdit
	In order to update user details
	As a user
	I should be able to the edit the user details

@positive
Scenario: Edit user details
	Given I have navigated to the web application
	And I see the application opened
	Then I click Sign In link
	When I enter UserName and Password and click login button
	| UserName | Password |
	| john     | password |
	Then I should see the login username with welcome
	When I open Edit Profile Page from dropdown button on Navbar
	And I update the user details
	| Name		  | Address		 | Number	  |
	| John Doeeee | Baker Street | 9123456789 |
	Then the name change John Doeeee should be reflected on the user details page
	When I open Edit Profile Page from dropdown button on Navbar
	And I update the user details
	| Name		  | Address		 | Number	  |
	| John Doe	  | Beverlyhills | 9987654321 |
	Then the name change John Doe should be reflected on the user details page