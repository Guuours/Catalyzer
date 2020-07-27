using Newtonsoft.Json;

namespace Catalyzer.Serialization
{
    public static class Extension
    {
        public static T Clone<T>(this T @object)
        {
            try
            {
                var json = JsonConvert.SerializeObject(@object);
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch
            {
                return default;
            }
        }
    }
}