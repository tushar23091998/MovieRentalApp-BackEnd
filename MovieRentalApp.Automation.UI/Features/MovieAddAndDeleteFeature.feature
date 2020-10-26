@movieAddDeleteFeature
Feature: MovieAddAndDelete
	In order to check admin functionalities
	As an admin
	I want to be able to add and delete movies.

@smoke @positive
Scenario: Add and Delete Movie
	Given I have navigated to the web application
	And I see the application opened
	Then I click Sign In link
	When I enter UserName and Password and click login button
	| UserName | Password |
	| john     | password |
	#Then I should see the login username with welcome
	Then I open Edit Profile Page from dropdown button on Navbar
	When I click admin button
	And  I add a movie
	| MovieTitle			   | MovieDescription																																																																				 | MovieDuration | MovieRentalRate   | MoviePurchaseRate | MovieRating | MovieImageLink																	   | MovieTrailerLink					 | MovieGenre | MovieWideImageLink																																										|
	| The Shawshank Redemption | In 1947 Portland, Maine, banker Andy Dufresne is convicted of murdering his wife and her lover and is sentenced to two consecutive life sentences at the Shawshank State Penitentiary. He is befriended by Ellis Red Redding, an inmate and prison contraband smuggler serving a life sentence. | 142 min	     | 25				 | 50				 | 5		   | https://upload.wikimedia.org/wikipedia/en/8/81/ShawshankRedemptionMoviePoster.jpg | //www.youtube.com/embed/NmzuHjWmXOc | Drama	  | https://imagesvc.meredithcorp.io/v3/mm/image?q=85&c=sc&poi=face&w=2000&h=1047&url=https%3A%2F%2Fstatic.onecms.io%2Fwp-content%2Fuploads%2Fsites%2F6%2F2019%2F07%2Fshawshankred-2000.jpg |
	Then I check the newly added movie on Movie List Page
	And I open Edit Profile Page from dropdown button on Navbar
	When I click admin button
	And I delete the movie
	Then I should not see the deleted movie in Movie List Page
