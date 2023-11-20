Feature: Create New Account


Scenario: Create a new account
	Given The account initial amount 1000
	And The Account Name is "Sandeep Gunti"
	And The address is "Bangalore, Karnataka"
	When User sends the POST request to create new account
	Then Verify the success response code and the success message