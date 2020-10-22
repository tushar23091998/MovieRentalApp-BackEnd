@placeOrderFeature
Feature: PlaceOrder
	In order to place an order
	As a user
	I want to be able to add movies to cart and checout

@smoke @positive
Scenario: Place Order
	Given I have navigated to the web application
	And I see the application opened
	Then I click Sign In link
	When I enter UserName and Password and click login button
	| UserName | Password |
	| john     | password |
	Then I should see the login username with welcome
	When I open Movie List page and add movies
	And I open Movie Carousel page and add movies
	Then I open the cart
	When I select the purchase type and I pay and checkout
	Then I should see the movies in user orders
