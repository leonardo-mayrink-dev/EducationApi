using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EducationApi.Util
{
    public static class ObjectSerializerUtil
    {

        public static string ObjectSerializerRest(object obj, NullValueHandling nullValueHandling = NullValueHandling.Include)
        {
            string result;

            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy
                {
                    OverrideSpecifiedNames = false,
                }
            };

            result = JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented,
                NullValueHandling = nullValueHandling
            });


            return result;
        }
    }
}
