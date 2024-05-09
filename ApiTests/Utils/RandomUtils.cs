namespace TestProject.Utils
{
    public class RandomUtils
    {
        private static readonly string randomValue = Guid.NewGuid().ToString();
        public static string GetRandomValue()
        {
            return randomValue;
        }
    }
}
