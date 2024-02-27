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
           string baseUrl="petstore.swagger.io/v2";
           string petId="0";
            string petName="\"doggie\"";
            string petStatus= "\"available\"";
            string Payload = "{\r\n  \"id\": 0,\r\n  \"category\": {\r\n    \"id\": 0,\r\n    \"name\": \"string\"\r\n  },\r\n  \"name\": \"doggie\",\r\n  \"photoUrls\": [\r\n    \"string\"\r\n  ],\r\n  \"tags\": [\r\n    {\r\n      \"id\": 0,\r\n      \"name\": \"string\"\r\n    }\r\n  ],\r\n  \"status\": \"available\"\r\n}";
            
  
        }

        [Test]
        public void PetTest()
        {
            
            
            //create a pet using post request
            PetStoreApiUtils.PostPet(
                new Pet(
                    ConfigReader.GetNumericalTestDataValue("0"),
                    ConfigReader.GetTestDataValue("doggie"),
                    ConfigReader.GetTestDataValue("available")));

            //validate that the name of the pet is as you passed in a previous step
           PetStoreApiUtils.GetPetById(ConfigReader.GetNumericalTestDataValue("0"));
            Assert.That(PetStoreApiUtils.GetPetById(
                ConfigReader.GetNumericalTestDataValue("0")).Name,
                Is.EqualTo("doggie"));

            //update pet and change the name to a new one and validate that the request was successful
            PetStoreApiUtils.PutPetById(
                new Pet(
                     ConfigReader.GetNumericalTestDataValue("0"),
                    ConfigReader.GetTestDataValue("doggieUpdated"),
                    ConfigReader.GetTestDataValue("available")));
         /*   PetStoreApiUtils.GetPetById(ConfigReader.GetNumericalTestDataValue("0"));
            Assert.That(PetStoreApiUtils.GetPetById(
                ConfigReader.GetNumericalTestDataValue("0")).Name,
                Is.EqualTo("doggieUpdated")); 
         */



            //validate that the name of the pet is updated to a new one
            Assert.That(PetStoreApiUtils.GetPetById(
                ConfigReader.GetNumericalTestDataValue("0")).Name,
                Is.EqualTo(ConfigReader.GetTestDataValue("doggieUpdated")),
                "Pet name is not as expected");

            //delete a pet from the petstore
            PetStoreApiUtils.DeletePetById(ConfigReader.GetTestDataValue("0"));
        }

        [TearDown]
        public void TearDown()
        {
            //Created pet should be deleted after the test
            PetStoreApiUtils.DeletePetById(ConfigReader.GetTestDataValue("0"));

        }
    }
}