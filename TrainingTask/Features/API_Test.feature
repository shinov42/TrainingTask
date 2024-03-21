Feature: API test-Pet Shop

Automation training with Welcome to the-internet application
Background: Creating a Pet
Given I create a pet with get request


Scenario: Pet Store
When I GET a pet by Id
Then Pet is added with the specified name
When I update a pet from previous step and change the name to a new one
Then I check '<RequestOrProperty>' and Response Status
@TestCaseId_1
Examples: 
| RequestOrProperty  |
| putRequest         |
@TestCaseId_2
Examples: 
| RequestOrProperty  |
| responseNewPetName |
