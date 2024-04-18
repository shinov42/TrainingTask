using RestSharp;
using System.Net;
using TestProject.Models;
using TestProject.Utils;


namespace TestProject.Tests.API
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            //create a pet using post request
            //move test data creation here
            PetStoreApiUtils.PostPet(
                new Pet(
                    ConfigReader.GetNumericalTestDataValue("petId"),
                    ConfigReader.GetTestDataValue("petName"),
                    ConfigReader.GetTestDataValue("petStatus")));
        }

        [Test]
        public void PetTest()
        {
            //validate that the name of the pet is as you passed in a previous step
            Assert.That(PetStoreApiUtils.GetPetById(
                ConfigReader.GetNumericalTestDataValue("petId")).Name,
                Is.EqualTo(ConfigReader.GetTestDataValue("petName")), "Pet name is not as expected");

            //update pet and change the name to a new one and validate that the request was successful
            RestResponse updateResponse = PetStoreApiUtils.PutPet(
                new Pet(
                    ConfigReader.GetNumericalTestDataValue("petId"),
                    ConfigReader.GetTestDataValue("newPetName"),
                    ConfigReader.GetTestDataValue("petStatus")));

            Assert.Multiple(() =>
            {
                Assert.That(updateResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Pet update request was not successful");
                //validate that the name of the pet is updated to a new one
                Assert.That(PetStoreApiUtils.GetPetById(
                    ConfigReader.GetNumericalTestDataValue("petId")).Name,
                    Is.EqualTo(ConfigReader.GetTestDataValue("newPetName")),
                    "Updated pet name is not as expected");
            }
           );
        }

        [TearDown]
        public void TearDown()
        {
            //delete a pet from the petstore
            //Created pet should be deleted after the test
            PetStoreApiUtils.DeletePetById(ConfigReader.GetTestDataValue("petId"));
        }
    }
}