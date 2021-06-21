using System.Web.Script.Serialization;

namespace SearchFight.Transversal.Helpers
{
    /// <summary>
    /// Handle JSON Notation
    /// </summary>
    public static class JsonHelper
    {
        public static T Deserialize<T>(this string json)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize<T>(json);
        }
    }
}
