using RestSharp;

namespace TestProject.Utils
{
    internal class ApiUtils
    {
        private static readonly RestClient client = new(ConfigReader.GetConfigValue("baseRequestUrl"));

        public static RestResponse SendGetRequest(string resource)
        {
            //implement a simple get request
            return client.Execute(new RestRequest(resource, Method.Get)
            { RequestFormat = DataFormat.None });

            //return null;
        }

        public static RestResponse SendPostRequest(string resource, Object body)
        {

            return client.Execute(new RestRequest(resource, Method.Post)
            { RequestFormat = DataFormat.Json }
                .AddBody(body));
        }
        public static RestResponse SendPutRequest(string resource, Object body)
        {

            return client.Execute(new RestRequest(resource, Method.Put)
            { RequestFormat = DataFormat.Json }
                .AddBody(body));
        }
        public static RestResponse SendDeleteRequest(string resource)
        {

            return client.Execute(new RestRequest(resource, Method.Delete)
            { RequestFormat = DataFormat.Json });
        }
    }
}
