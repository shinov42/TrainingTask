using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingTask.Utils;
using TrainingTask.Models;
using OpenQA.Selenium;
using BoDi;

namespace TrainingTask.StepDefinitions
{
    [Binding]
    public class PetStoreStepDefinitions
    {
        IObjectContainer objectcontainer;
        IWebDriver driver;


        public PetStoreStepDefinitions(IWebDriver driver, IObjectContainer objectcontainer) 
        {
            this.objectcontainer = objectcontainer;
            this.driver = driver;
        }
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
                     ConfigReader.GetTestDataValue("petStatus")));
        }
        [Then(@"I check '([^']*)' and Response Status")]
        public void ThenICheckAndResponseStatus(string putRequest)
        {
            if (putRequest == "putRequest")
            {
                PetStoreApiUtils.PutPetIsSuccessful(
                 new Pet(
                      ConfigReader.GetNumericalTestDataValue("petId"),
                     ConfigReader.GetTestDataValue("newPetName"),
                     ConfigReader.GetTestDataValue("petStatus")));
            }
            else if (putRequest == "responseNewPetName")
            {
                Assert.That(PetStoreApiUtils.GetPetById(
              ConfigReader.GetNumericalTestDataValue("petId")).Name,
              Is.EqualTo("Daisy"),
              "Pet name is not as expected");
            }
        }

    }
}
