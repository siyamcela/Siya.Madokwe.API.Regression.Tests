Feature: Ingredients

A short summary of the feature


Scenario: I want to get result if Ingredient exist
	Given I search ingredient using '<Name>'
	When I verify ingridien search result match search
@regression
Examples:
	| Name  |
	| vodka |
	| water |

Scenario: I want to get result if Ingredient is case sensitive
	Given I search ingredient using '<Name>'
	When I verify ingridien search result match search
@regression
Examples:
	| Name  |
	| vodka |
	| VODKA |
	| vOdKA |

Scenario: I want to search for alcholic ingredients
	Given I search ingredient using '<Name>'
	When I verify ingridien search result match search
	Then I want to verify if ingredient is alcholic
@regression
Examples:
	| Name  |
	| vodka |
	| water |

Scenario: I want to search for non alcholic ingredients
	Given I search ingredient using '<Name>'
	When I verify ingridien search result match search
	Then I want to verify if ingredient is non alcholic
@regression
Examples:
	| Name  |
	| water |
	| vodka |