Feature: Withdraw Amount from the account


Scenario: Withdraw amount from the account
	Given The account Number details with "X123"
	And Withdraw the amount 500
	When User sends the PUT request to withdraw amount
	Then Verify the success response code and the success message for Withdraw Amount