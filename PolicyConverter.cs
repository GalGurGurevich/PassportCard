using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace TestRating
{

    class PolicyConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Policy).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            string discriminator = (string)obj["type"];

            Policy policy;
            switch (discriminator)
            {
                case "Travel":
                    policy = new TravelPolicy();
                    break;
                case "Life":
                    policy = new LifeInsurancePolicy();
                    break;
                case "Health":
                    policy = new HealthPolicy();
                    break;
                default:
                    throw new NotImplementedException();
            }

            serializer.Populate(obj.CreateReader(), policy);

            return policy;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {

        }
    }
}