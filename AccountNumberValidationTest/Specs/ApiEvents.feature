Feature: ApiEvents
	Simple calculator for adding two numbers

@BankAccountNumberVerification
Scenario: BankAccountVerification_PositiceCase
	Given I have API URL https://api-test.afterpay.dev/api/v3/validate/bank-account
	And the XAuthKey is <XAuthKey>
	When I verify the AccountNumber <AccountNumber>
	Then isValid in Responce is <isValid>

	Scenarios: 
	| ScenarioId       | XAuthKey                                 | AccountNumber          | isValid  |
	| ValidAccNumber   | Q7DaxRnFls6IpwSW1SQ2FaTFOf7UdReAFNoKY68L | GB09HAOE91311808002317 | True     |
	| InValidAccNumber | Q7DaxRnFls6IpwSW1SQ2FaTFOf7UdReAFNoKY68L | GB09HAOE913118080023G3 | False    |