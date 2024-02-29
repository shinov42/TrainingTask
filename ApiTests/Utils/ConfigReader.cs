using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TestProject.Utils
{
    internal class ConfigReader
    {
        public static string GetTestDataValue(string key)
        {
            var data = JsonConvert.DeserializeObject(File.ReadAllText("Resources/testdata.json")) as JObject;
            return data![key]!.Value<string>()!;
        }

        public static long GetNumericalTestDataValue(string key)
        {
            var data = JsonConvert.DeserializeObject(File.ReadAllText("Resources/testdata.json")) as JObject;
            return Convert.ToInt64(data![key]!.Value<string>()!);
        }

        public static string GetConfigValue(string key)
        {
            var data = JsonConvert.DeserializeObject(File.ReadAllText("Resources/config.json")) as JObject;
            return data![key]!.Value<string>()!;
        }
        public static long GetConfigTestDataValue(string key)
        {
            var data = JsonConvert.DeserializeObject(File.ReadAllText("Resources/config.json")) as JObject;
            return Convert.ToInt64(data![key]!.Value<string>()!);
        }

    }
}
