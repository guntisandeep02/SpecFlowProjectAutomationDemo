Feature: Deposit Account


Scenario: Deposit account with valid data
	Given The account Number details with "X123"
	And The amount 2000
	When User sends the PUT request to deposit account
	Then Verify the success response code and the success message for Deposit Account