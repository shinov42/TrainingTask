using RestSharp;

namespace TestProject.Utils
{
    internal class ApiUtils
    {
        private static readonly RestClient client = new(ConfigReader.GetConfigValue("baseRequestUrl"));

        public static RestResponse SendGetRequest(string resource)
        {
            //implement a simple get request
            return null;
        }

        public static RestResponse SendPostRequest(string resource, Object body)
        {

            return client.Execute(new RestRequest(resource, Method.Post)
            { RequestFormat = DataFormat.Json }
                .AddBody(body));
        }
    }
}
