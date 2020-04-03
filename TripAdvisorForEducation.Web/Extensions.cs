using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Text.Json;

namespace TripAdvisorForEducation.Web
{
    public static class Extensions
    {
        public static string ToJson(this object soonToBeJsonObject) => 
            JsonConvert.SerializeObject(soonToBeJsonObject,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    Converters = { new StringEnumConverter() },
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

        public static JsonResult ToJsonResult(this object soonToBeJsonResult) =>
            new JsonResult(soonToBeJsonResult)
            {
                ContentType = "application/json",
                Value = soonToBeJsonResult.ToJson()
            };
    }
}
