using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;

namespace TestRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        public decimal Rating { get; set; }
        public void Rate()
        {
            // log start rating
            Console.WriteLine("Starting rate.");

            Console.WriteLine("Loading policy.");

            // load policy - open file policy.json
            string policyJson = File.ReadAllText("policy.json");

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Converters.Add(new PolicyConverter());

            var policy = JsonConvert.DeserializeObject<Policy>(policyJson, settings);

            var valid = policy.Validate();
            if(!valid) return;
            Rating = policy.Rate();
        }
    }
}
