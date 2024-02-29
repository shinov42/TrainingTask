using TestProject.Models;
using RestSharp;
using System.Text.Json;

namespace TestProject.Utils
{
    internal class PetStoreApiUtils
    {
        private static readonly string GetEndpoint = "pet/";
        private static readonly string PostEndpoint = "pet/";

        public static Pet GetPetById(long id)
        {
            return DeserializePetResponse(
                ApiUtils.SendGetRequest(GetEndpoint + id));
        }

        public static RestResponse PostPet(Pet pet)
        {
            return ApiUtils.SendPostRequest(PostEndpoint, pet);
        }


        public static bool PostPetIsSuccessful(Pet pet)
        {

            //implement a logic of sending a post request with a verification of success
            DeserializePetResponse(ApiUtils.SendPostRequest(PostEndpoint, pet));
            return false;
        }
        public static bool PutPetIsSuccessful(Pet pet)
        {
            //implement a logic of sending a post request with a verification of success
            DeserializePetResponse(ApiUtils.SendPutRequest(PostEndpoint, pet));
            return false;
        }
        public static void DeletePetById(string id)
        {
            ApiUtils.SendDeleteRequest(PostEndpoint + id);
        }


        private static Pet DeserializePetResponse(RestResponse petResponse)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<Pet>(petResponse.Content!, options)!;
        }
        public static RestResponse PutPetById(Pet pet)
        {
            return ApiUtils.SendPutRequest(PostEndpoint, pet);
        }

    }
}
