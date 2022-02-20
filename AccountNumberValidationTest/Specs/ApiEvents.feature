Feature: ApiEvents
	Simple calculator for adding two numbers

@BankAccountNumberVerification
Scenario: BankAccountVerification
	Given I have API URL https://api-test.afterpay.dev/api/v3/validate/bank-account
	And the XAuthKey is Q7DaxRnFls6IpwSW1SQ2FaTFOf7UdReAFNoKY68L
	When I verify the AccountNumber GB09HAOE91311808002317
	Then isValid in Responce is True