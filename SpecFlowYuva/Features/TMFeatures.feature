Feature: Calculator
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](SpecFlowYuva/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

Background: 
	Given user logs into turnup portal 'hari' '123123'
	When user navigates to TM page

Scenario: Verify user is able to create TM record
	And user creates a new TM record 'January2024-Yuva' 'Automation Testing- Yuva' '100'
	Then TM record should be saved

	Scenario Outline: Verify user is able to edit TM record
	And user edits a TM record '<code>' '<description>' '<price>'
	Then TM record should be Edited

	Examples: 
	| code              | description       | price |
	| January2024-Yuva1 | Automation Testing- Yuva1 | 50    |
	#| January2024-Yuva2 | Automation Testing- Yuva2 | 75    |

	Scenario: Verify user is able to delete TM record
	And user deletes a  TM record
	Then TM record should be deleted