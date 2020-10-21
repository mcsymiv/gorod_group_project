Feature: Advertisement
	In order to gain money from sells
	As a user of gorod.dp.ua website
	I want to manage my advertisements on the gorod.dp.ua

	Background: 
	Given I on the ad page
	When I want to login to my account with my mcsymiv 123456789

@createAd
Scenario: Successful create car sell ad
	Given I want to add my ad
	When I fill in all necessary fields
	When I click on add ad
	Then I see thank you message on the page

@error_on_submit
Scenario: Error on skipping necessary fields
	Given Ad form is open
	When User leaves necessary field empty
	Then User see red error message

@edit_ad
Scenario: Edit information of my ad
	When I go to page my ads
	Then I see title on the page my ads
	When I click on the edit button
	Then I see title placing a new ad
	When I edit text and the address of an ad
	When I click on the share ad
	Then I see text information like please wait admin accepting

@delete_ad
Scenario: Successfuly delete user ad
	Given One ad is created by user	
	When User delete this specific ad
	Then User ad count is zero

@edit_profile_info
Scenario: Update user profile information on form
	Given User is on profile page
	When User updates their phone number
	When User opens ad form for creation
	Then Phone field is pre-filled with updated data

@ad_preview
Scenario: Look at ad preview
	Given ad form is prefilled with user data
	When User click on preview button
	Then User's ad is shown on the page

