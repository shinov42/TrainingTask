using TestProject.Models;
using TestProject.Utils;

namespace TestProject.Tests.API
{
    public class Tests
    {
        public void Setup(string petId, string petName, string petStatus)
        {
            PetStoreApiUtils.PostPet(
                new Pet(
                    ConfigReader.GetNumericalTestDataValue(petId),
                    ConfigReader.GetTestDataValue(petName),
                    ConfigReader.GetTestDataValue(petStatus)));
        }

        [TearDown]
        public void TearDown()
        {
            PetStoreApiUtils.DeletePetById(ConfigReader.GetTestDataValue("petId"));
        }
    }
}
