using TestProject.Models;
using TestProject.Utils;

namespace TestProject.Tests.API
{
    public class Tests
    {
        private Pet pet;

        [SetUp]
        public void Setup()
        {
            //move test data creation here
            pet = new Pet(420000, "Jake", "Alive");
        }

        [Test]
        public void PetTest()
        {
            //create a pet using post request
            PetStoreApiUtils.PostPet(pet);

            //validate that the name of the pet is as you passed in a previous step
            Assert.That(PetStoreApiUtils.GetPetById(pet.Id).Name,Is.EqualTo(pet.Name));

            //update pet and change the name to a new one and validate that the request was successful
            var newName = "Vanessa";
            pet.Name = newName;
            var updateRequest = PetStoreApiUtils.UpdatePet(pet);
            Assert.That(updateRequest.IsSuccessful, Is.True);

            //validate that the name of the pet is updated to a new one
            Assert.That(PetStoreApiUtils.GetPetById(pet.Id).Name,
                Is.EqualTo(newName),
                "Pet name is not as expected");

            //delete a pet from the petstore
            PetStoreApiUtils.DeletePetById(ConfigReader.GetTestDataValue("petId"));
        }

        [TearDown]
        public void TearDown()
        {
            //Created pet should be deleted after the test
            PetStoreApiUtils.DeletePetById((pet.Id).ToString());
        }
    }
}