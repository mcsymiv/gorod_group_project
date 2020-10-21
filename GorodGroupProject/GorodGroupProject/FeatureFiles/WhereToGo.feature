Feature: Where to go module
	In order to find a place to go in the city
	As a user
	I want to have site section about places where to go

	Background: 
	Given Web-driver created 

	@search
Scenario: Search with one keyword
	Given Site Gorod.dp is open on restaurant page
	When put keyword into search input field
	Then search page has looked title 

	@cusin
Scenario: Choosing a cusin for restaurant
	Given Web-site open on restaurants page 
	When I choose cusine 
	Then I see list of restaurant for this cusin
	When I navigate to page of restaurant 
	Then I see cousin that I was choosing


Scenario: Switch to restaurants tab
	Given  Site Gorod.dp is open on where to go
	When go to page restorans
	Then went to the page restorans

Scenario: Restaurant tabs lead to the same page
	Given Site Gorod.dp is open on where to go
	When I click on the restaurants tab in the sidebar
	When Back to the page where to go
	When I click on the restaurants tab in the body
	Then Title of page that opens from side bar the same as title of page opened from body

@pagination
Scenario: Checking pagination for sport places
	Given Website open on sports page
	Then I am on first page of places list
	When I going to the next page
	Then Number of page where I am changed

	@filter
Scenario Outline: Checking correctness of filter works
	Given Web-site open on restaurants page 
	When I choose <letter> filter
	Then Name of first restaurant on the page started with choosen <letter>
	Then Name of last restaurant on the page started with choosen <letter>
	Examples: 
	| letter |
	| "А"    |
	| "Б"    |
	| "В"    |
	| "Г"    |