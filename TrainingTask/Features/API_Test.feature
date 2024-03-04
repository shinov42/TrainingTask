Feature: API test-Pet Shop

Automation training with Welcome to the-internet application
Background: Creating a Pet
Given I create a pet with get request

@TestCaseId_1
Scenario: Pet Store
When I GET a pet by Id
Then Pet is added with the specified name
When I update a pet from previous step and change the name to a new one
Then Request was successful & the name is updated
Then I delete a pet from a pet store
