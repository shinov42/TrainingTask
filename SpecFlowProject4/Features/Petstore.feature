Feature: Petstore
Pet create, update, delete operations via API
See https://petstore.swagger.io/ for documentation

@api
Scenario: Create a pet using get request
	Given A pet with ID 'petId' is created with name 'petName' and status 'petStatus'
	When I Get a pet by ID 'petId' from precondition
	Then Pet is added with the name 'petName'
	When I Update a pet with data 'petId', 'petStatus' to a new name 'newPetName'
	Then Request was successful
	  And The pet name is 'newPetName'
	  And I Delete a pet from a pet with id 'petId' store
