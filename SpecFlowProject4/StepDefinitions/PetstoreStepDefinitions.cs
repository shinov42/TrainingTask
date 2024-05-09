using NUnit.Framework;
using RestSharp;
using System.Net;
using TestProject.Models;
using TestProject.Tests.API;
using TestProject.Utils;

namespace SpecFlowProject4.StepDefinitions
{
    [Binding]
    public sealed class PetstoreStepDefinitions
    {
        readonly Tests tests = new();
        private readonly ScenarioContext scenarioContext;
        public PetstoreStepDefinitions(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [Given(@"A pet with ID '(.*)' is created with name '(.*)' and status '(.*)'")]
        public void GivenAPetWithIDPetIdIsCreatedWithNamePetNameAndStatusPetStatus(string petId, string petName, string petStatus)
        {
            tests.Setup(petId, petName, petStatus);
            scenarioContext["petId"] = petId;
            scenarioContext["petName"] = petName;
            scenarioContext["petStatus"] = petStatus;
        }


        [When(@"I Get a pet by ID '(.*)' from precondition")]
        public void WhenIGetAPetByIDFromPrecondition(string petId)
        {
            var gettedPetId = ConfigReader.GetNumericalTestDataValue(petId);
            var pet = PetStoreApiUtils.GetPetById(gettedPetId);
            scenarioContext["pet"] = pet;
        }

        [Then(@"Pet is added with the name '(.*)'")]
        public void ThenPetIsAddedWithTheName(string petName)
        {
            var expectedPetName = ConfigReader.GetTestDataValue(petName);
            var pet = (Pet)scenarioContext["pet"];
            Assert.That(pet.Name, Is.EqualTo(expectedPetName), "Pet name is not as expected");
        }

        [When(@"I Update a pet with data '(.*)', '(.*)' to a new name '(.*)'")]
        public void WhenIUpdateAPetWithDataToANewName(string petId, string petStatus, string newPetName)
        {
            RestResponse updateResponse = PetStoreApiUtils.PutPet(
                new Pet(
                    ConfigReader.GetNumericalTestDataValue(petId),
                    ConfigReader.GetTestDataValue(newPetName),
                    ConfigReader.GetTestDataValue(petStatus)));
            scenarioContext["updateResponse"] = updateResponse;
        }

        [Then(@"Request was successful")]
        public void ThenRequestWasSuccessful()
        {
            var updateResponse = (RestResponse)scenarioContext["updateResponse"];
            Assert.That(updateResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Pet update request was not successful");
        }

        [Then(@"The pet name is '(.*)'")]
        public void ThenTheNameIs(string newPetName)
        {
            var expectedUpdatePetName = ConfigReader.GetTestDataValue(newPetName);
            var petId = ConfigReader.GetNumericalTestDataValue("petId");
            var updatedPet = PetStoreApiUtils.GetPetById(petId);
            scenarioContext["updatedPet"] = updatedPet;
            Assert.That(updatedPet.Name, Is.EqualTo(expectedUpdatePetName),
            $"Updated pet name is not as expected {newPetName}");
        }

        [Then(@"I Delete a pet from a pet with id '(.*)' store")]
        public static void ThenIDeletedAPetFromAPetStore(string petId)
        {
            PetStoreApiUtils.DeletePetById(ConfigReader.GetTestDataValue(petId));
        }
    }
}
