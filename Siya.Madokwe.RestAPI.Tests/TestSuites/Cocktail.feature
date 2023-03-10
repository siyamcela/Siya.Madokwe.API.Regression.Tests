Feature: Cocktail

A short summary of the feature


Scenario: I want to get result if Cocktail exist
	Given I search cocktail using '<Name>'
	Then I verify cocktail search result match search
@regression
Examples:
	| Name      |
	| Margarita |


Scenario: I want to search result if Cocktail not exist
	Given I search cocktail using '<Name>'
	Then I verify search does not exit
@regression
Examples:
	| Name      |
	| Margarito |


Scenario: I want to search result if Cocktail input is Case sensitive
	Given I search cocktail using '<Name>'
	Then I verify cocktail search result match search
@regression
Examples:
	| Name      |
	| MarGarita |
