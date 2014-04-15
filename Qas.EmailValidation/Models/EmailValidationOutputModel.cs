using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.ConstrainedExecution;
using Qas.EmailValidation.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Qas.EmailValidation.Models
{
    public class EmailValidationOutputModel
    {
        public string Email { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Certainty Certainty { get; set; }

        public string Message { get; set; }

        public List<string> Corrections { get; set; }

        [JsonIgnore]
        public bool Success { get; set; }

        [JsonIgnore]
        public bool IsValidEmail
        {
            get { return Certainty == Certainty.Unknown || Certainty == Certainty.Verified; }

        }

    }
}
