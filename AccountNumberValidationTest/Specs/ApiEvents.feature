Feature: ApiEvents
	

@BankAccountNumberVerification_PositiveScenario
Scenario: BankAccountVerification_PositiveCase
	Given I have API URL https://api-test.afterpay.dev/api/v3/validate/bank-account
	And the XAuthKey is <XAuthKey>
	When I verify the AccountNumber <AccountNumber>
	Then isValid in Responce is <isValid>
	And Responce StatusCode is <StatusCode>

	Scenarios: 
	| ScenarioId		    | XAuthKey                                 | AccountNumber                                | isValid | StatusCode |
	| ValidAccNumber	    | Q7DaxRnFls6IpwSW1SQ2FaTFOf7UdReAFNoKY68L | GB09HAOE91311808002317                       | True    | 200        |
	| WrongAccNumber	    | Q7DaxRnFls6IpwSW1SQ2FaTFOf7UdReAFNoKY68L | GB09HAOE913118080023G3                       | False   | 200        |
	| AccNumberExceedLength | Q7DaxRnFls6IpwSW1SQ2FaTFOf7UdReAFNoKY68L | GB09HAOE93436364436436313118080023G34534534G |         | 400        |


@BankAccountNumberVerification_NegativeScenario
Scenario: BankAccountVerification_NegativeCase
	Given I have API URL https://api-test.afterpay.dev/api/v3/validate/bank-account
	And the XAuthKey is <XAuthKey>
	When I verify the AccountNumber <AccountNumber>
	Then Responce StatusCode is <StatusCode>

	Scenarios: 
	| ScenarioId    | XAuthKey                                 | AccountNumber          | StatusCode |
	| NoJWTToken    |                                          | GB09HAOE913118080023G3 | 401        |
	| WrongJWTToken | Q7DaxRnFls6IpwSW1SQ2FaTFOf7UdReAFNoKY688 | GB09HAOE913118080023G3 | 401        |