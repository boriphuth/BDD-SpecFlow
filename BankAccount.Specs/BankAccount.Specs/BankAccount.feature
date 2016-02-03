Feature: Transferring money between accounts
	In order to manage my money more efficiently
	As a bank clietn
	I want to transfer funds between my accounts whenever I need to

Scenario: Transferring money to a savings account
	Given my Current account has a balance of 1000.00
	And my Savings account has a balance of 2000.00
	When I transfer 500.00 from my Current account to my Savings account
	Then I should have 500.00 in my Current account
	And I should have 2500.00 in my Savings account

Scenario: Transferring with insufficient funds
	Given my Current account has a balance of 1000.00
	And my Savings account has a balance of 2000.00
	When I transfer 1500.00 from my Current account to my Savings account
	Then I should receive an 'insufficient funds' error
	And I should have 1000.00 in my Current account
	And I should have 2000.00 in my Savings account

Scenario Outline: Earning interest
	Given I have an account of <account-type> with a balance of <initial-balance>
	And I have earned at an annual interest rate of <interest-rate>
	When the monthly interest is calculated
	And I should have a new balance of <new-balance>
	Examples: 
	| initial-balance | account-type | interest-rate | new-balance |
	| 10000.00        | current      | 1             | 10008.33    |
	| 10000.00        | savings      | 3             | 10025.00    |
	| 10000.00        | supersaver   | 5             | 10041.67    |