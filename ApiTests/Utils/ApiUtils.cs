using RestSharp;

namespace TestProject.Utils
{
    internal class ApiUtils
    {
        private static readonly RestClient client = new(ConfigReader.GetConfigValue("baseRequestUrl"));

        public static RestResponse SendGetRequest(string resource)
        {
            try
            {
                return client.Execute(new RestRequest(resource, Method.Get) { RequestFormat = DataFormat.Json });
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new RestResponse() { IsSuccessStatusCode = false};
            }
        }

        public static RestResponse SendPostRequest(string resource, Object body)
        {
            try
            {
                return client.Execute(new RestRequest(resource, Method.Post)
                { RequestFormat = DataFormat.Json }
                .AddBody(body));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new RestResponse() { IsSuccessStatusCode = false };
            }
        }

        public static RestResponse SendPutRequest(string resource, Object body)
        {
            try
            {
                return client.Execute(new RestRequest(resource, Method.Put)
                { RequestFormat = DataFormat.Json }
                .AddBody(body));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new RestResponse() { IsSuccessStatusCode = false };
            }
        }

        public static void SendDeleteRequest(string resource)
        {
            try
            {
                client.Execute(new RestRequest(resource, Method.Delete));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
