using System.Web.Script.Serialization;
namespace Services
{
    public static class JsonHelper
    {
        public static T Deserialize<T>(this string json)
        {
            var serialize = new JavaScriptSerializer();
            return serialize.Deserialize<T>(json);
        }
    }
}
