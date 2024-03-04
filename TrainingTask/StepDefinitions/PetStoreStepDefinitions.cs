using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingTask.Utils;
using TrainingTask.Models;

namespace TrainingTask.Tests.Pages.StepDefinitions
{
    [Binding]
    public class PetStoreStepDefinitions
    {
        [Given(@"I create a pet with get request")]
        public void GivenICreateAPetWithGetRequest()
        {
            PetStoreApiUtils.PostPet(
                new Pet(
                    ConfigReader.GetNumericalTestDataValue("petId"),
                    ConfigReader.GetTestDataValue("petName"),
                    ConfigReader.GetTestDataValue("petStatus")));
        }

        [When(@"I GET a pet by Id")]
        public void WhenIGETAPetById()
        {
            PetStoreApiUtils.GetPetById(ConfigReader.GetNumericalTestDataValue("petId"));
        }

        [Then(@"Pet is added with the specified name")]
        public void ThenPetIsAddedWithTheSpecifiedName()
        {
            Assert.That(PetStoreApiUtils.GetPetById(
                ConfigReader.GetNumericalTestDataValue("petId")).Name,
                Is.EqualTo("Mister Pickles"));
        }
        [When(@"I update a pet from previous step and change the name to a new one")]
        public void WhenIUpdateAPetFromPreviousStepAndChangeTheNameToANewOne()
        {
            PetStoreApiUtils.PutPetIsSuccessful(
                 new Pet(
                      ConfigReader.GetNumericalTestDataValue("petId"),
                     ConfigReader.GetTestDataValue("newPetName"),
                     ConfigReader.GetTestDataValue("asleep")));
        }

        [Then(@"Request was successful & the name is updated")]
        public void ThenRequestWasSuccessfulTheNameIsUpdated()
        {
            Assert.That(PetStoreApiUtils.GetPetById(
               ConfigReader.GetNumericalTestDataValue("petId")).Name,
               Is.EqualTo(ConfigReader.GetTestDataValue("newPetName")),
               "Pet name is not as expected");
        }

        [Then(@"I delete a pet from a pet store")]
        public void ThenIDeleteAPetFromAPetStore()
        {
            PetStoreApiUtils.DeletePetById(ConfigReader.GetTestDataValue("petId"));
        }

    }
}
