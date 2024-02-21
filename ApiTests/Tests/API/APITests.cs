using TestProject.Models;
using TestProject.Utils;

namespace TestProject.Tests.API
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            //move test data creation here
        }

        [Test]
        public void PetTest()
        {
            //create a pet using post request
            PetStoreApiUtils.PostPet(
                new Pet(
                    ConfigReader.GetNumericalTestDataValue("petId"),
                    ConfigReader.GetTestDataValue("petName"),
                    ConfigReader.GetTestDataValue("petStatus")));

            //validate that the name of the pet is as you passed in a previous step

            //update pet and change the name to a new one and validate that the request was successful

            //validate that the name of the pet is updated to a new one
            Assert.That(PetStoreApiUtils.GetPetById(
                ConfigReader.GetNumericalTestDataValue("petId")).Name,
                Is.EqualTo(ConfigReader.GetTestDataValue("newPetName")),
                "Pet name is not as expected");

            //delete a pet from the petstore
            PetStoreApiUtils.DeletePetById(ConfigReader.GetTestDataValue("petId"));
        }

        [TearDown]
        public void TearDown()
        {
            //Created pet should be deleted after the test
        }
    }
}