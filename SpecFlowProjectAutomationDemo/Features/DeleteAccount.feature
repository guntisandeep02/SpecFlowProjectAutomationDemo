Feature: Delete Account


Scenario: Delete account with Account Id
	Given The endpoint for account deletion 
	When User sends the DELETE request to delete account
	Then the account with ID should be deleted successfully